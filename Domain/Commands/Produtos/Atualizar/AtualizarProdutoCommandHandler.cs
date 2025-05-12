using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Atualizar
{
    public class AtualizarProdutoCommandHandler : IRequestHandler<AtualizarProdutoCommand, FormularioResponse<AtualizarProdutoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarProdutoCommand> _validator;
        private const int _indice = 0;

        public AtualizarProdutoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarProdutoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarProdutoCommand>> Handle(AtualizarProdutoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarProdutoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var produtoUpdate = await _unitOfWork.ProdutoRepository.ObterPorId(command.Id);
            var precosTributacoesUpdate = await _unitOfWork.PrecoTributacaoRepository.ObterPorId(command.Id);
            var composicaoUpdate = await _unitOfWork.ComposicaoRepository.ObterPorId(command.Id);
            var relacionaProdutoFornecedorUpdate = await _unitOfWork.RelacionaProdutoFornecedorRepository.ObterPorId(command.Id);

            produtoUpdate!.Update(
                command.CodigoAmigavel,
                command.Nome,
                command.IdUnidadeMedida,
                command.Espessura,
                command.PesoBruto,
                command.PesoLiquido,
                command.IdSetorProduto,
                command.CodigoBarras,
                command.EstoqueMinimo,
                command.EstoqueMaximo,
                command.IdMateriaPrima,
                command.IdCodigoImportacao,
                command.CorteCerto,
                command.IdTipoProduto,
                command.IdGrupo,
                command.IdSubgrupo,
                command.IdFamilia,
                command.IdSetor,
                command.IdRua,
                command.IdPrateleira,
                command.Posicao,
                command.InformacoesComplementares,
                command.EdgeDeleton,
                command.Bloqueado,
                command.DataBloqueio);

            var precosTributacoesParaRemover = precosTributacoesUpdate
                .Where(p => !command.PrecosTributacoes.Any(novo => novo.IdNcm == p.IdNcm &&
                                                                   novo.IdOrigemMaterial == p.IdOrigemMaterial &&
                                                                   novo.IdTipoPreco == p.IdTipoPreco &&
                                                                   novo.IdClasseReajuste == p.IdClasseReajuste &&
                                                                   novo.PrecoCusto == p.PrecoCusto &&
                                                                   novo.PrecoVenda == p.PrecoVenda)).ToList();

            foreach (var precoTributacao in precosTributacoesParaRemover)
            {
                precoTributacao.ChangeRemoved(true);
            }

            foreach (var novoPrecoTributacao in command.PrecosTributacoes!)
            {
                var precoTributacaoExistente = precosTributacoesUpdate
                    .FirstOrDefault(p => p.IdNcm == novoPrecoTributacao.IdNcm &&
                    p.IdOrigemMaterial == novoPrecoTributacao.IdOrigemMaterial &&
                    p.IdTipoPreco == novoPrecoTributacao.IdTipoPreco &&
                    p.IdClasseReajuste == novoPrecoTributacao.IdClasseReajuste &&
                    p.PrecoCusto == novoPrecoTributacao.PrecoCusto &&
                    p.PrecoVenda == novoPrecoTributacao.PrecoVenda);


                if (precoTributacaoExistente != null)
                {
                    precoTributacaoExistente.Update(
                        novoPrecoTributacao.IdNcm,
                        novoPrecoTributacao.IdOrigemMaterial,
                        novoPrecoTributacao.IdTipoPreco,
                        novoPrecoTributacao.IdClasseReajuste,
                        novoPrecoTributacao.PrecoCusto,
                        novoPrecoTributacao.PrecoVenda,
                        novoPrecoTributacao.Inativo
                    );
                }
                else
                {
                    var novaEntidadePrecoTributacao = new PrecosTributacoes(command.Id, novoPrecoTributacao.IdNcm, novoPrecoTributacao.IdOrigemMaterial, novoPrecoTributacao.IdTipoPreco, novoPrecoTributacao.IdClasseReajuste, novoPrecoTributacao.PrecoCusto, novoPrecoTributacao.PrecoVenda, novoPrecoTributacao.Inativo);
                    await _unitOfWork.PrecoTributacaoRepository.Adicionar(novaEntidadePrecoTributacao);
                }
            }

            var composicoesParaRemover = composicaoUpdate
                .Where(c => !command.Composicao!.Any(nova => nova.IdProduto == c.IdComposicao))
                .ToList();

            foreach (var composicao in composicoesParaRemover)
            {
                composicao!.ChangeRemoved(true);
            }

            int SequenciaComposicao = 1;

            foreach (var novaComposicao in command.Composicao!)
            {
                var composicaoExistente = composicaoUpdate
                    .FirstOrDefault(p => p.IdComposicao == novaComposicao.IdProduto);

                if (composicaoExistente != null)
                {
                    composicaoExistente.Update(
                        novaComposicao.IdProduto,
                        SequenciaComposicao,
                        novaComposicao.PerfilH,
                        novaComposicao.PerfilL,
                        novaComposicao.Etiqueta
                    );
                }
                else
                {
                    var novaEntidadeComposicao = new Composicao(command.Id, novaComposicao.IdProduto, SequenciaComposicao, novaComposicao.PerfilH, novaComposicao.PerfilL, novaComposicao.Etiqueta);
                    await _unitOfWork.ComposicaoRepository.Adicionar(novaEntidadeComposicao);
                }
                SequenciaComposicao++;
            }

            //-----------Fornecedores
            await _unitOfWork.RelacionaProdutoFornecedorRepository.RemoverEmMassa(relacionaProdutoFornecedorUpdate!);

            var relacionaprodutoFornecedor = CriarRelacionaProdutoFornecedor(command.Fornecedor!, command.Id);

            await _unitOfWork.RelacionaProdutoFornecedorRepository.AdicionarEmMassa(relacionaprodutoFornecedor);
            //----- 

            try
            {
                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var teste = ex.Message;
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarProdutoCommand(
                produtoUpdate.Id,
                command.CodigoAmigavel,
                command.Nome,
                command.IdUnidadeMedida,
                command.Espessura,
                command.PesoBruto,
                command.PesoLiquido,
                command.CodigoLetra,
                command.IdSetorProduto,
                command.CodigoBarras,
                command.EstoqueMinimo,
                command.EstoqueMaximo,
                command.IdMateriaPrima,
                command.IdCodigoImportacao,
                command.CorteCerto,
                command.IdTipoProduto,
                command.IdGrupo,
                command.IdSubgrupo,
                command.IdFamilia,
                command.IdSetor,
                command.IdRua,
                command.IdPrateleira,
                command.Posicao,                
                command.InformacoesComplementares,
                command.EdgeDeleton ?? false,
                command.Bloqueado ?? false,
                command.DataBloqueio         
            );

            response.SetFormulario(commandAtualizado);
            return response;
        }

        private List<RelacionaProdutoFornecedor> CriarRelacionaProdutoFornecedor(List<RelacionaProdutoFornecedorCommand>? relacionaProdutoFornecedorCommand, Guid idProduto)
        {
            return (relacionaProdutoFornecedorCommand ?? new List<RelacionaProdutoFornecedorCommand>())
                .Select(e => new RelacionaProdutoFornecedor(e.IdFornecedor, idProduto, e.CodigoProdutoFornecedor!))
                .ToList();
        }
    }
}
