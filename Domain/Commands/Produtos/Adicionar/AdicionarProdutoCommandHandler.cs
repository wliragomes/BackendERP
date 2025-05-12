using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Adicionar
{
    public class AdicionarProdutoCommandHandler : IRequestHandler<AdicionarProdutoCommand, FormularioResponse<AdicionarProdutoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AdicionarProdutoCommand> _validator;
        private const int _indice = 0;

        public AdicionarProdutoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarProdutoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarProdutoCommand>> Handle(AdicionarProdutoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarProdutoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Produto produto = new Produto(
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
                command.Posicao!,
                command.InformacoesComplementares!,
                command.EdgeDeleton ?? false,
                command.Bloqueado ?? false,
                command.DataBloqueio
            );

            // Adiciona o produto ao repositório
            await _unitOfWork.ProdutoRepository.Adicionar(produto);

            // PrecosTributacoes
            var precosTributacoes = CriarPrecosTributacoes(command.PrecosTributacoes!, produto.Id);

            // Composicao
            var composicao = CriarComposicao(command.Composicao!, produto.Id);

            // Fornecedor           
            var relacionaprodutoFornecedor = CriarRelacionaProdutoFornecedor(command.Fornecedor!, produto.Id);

            await Task.WhenAll(
                _unitOfWork.PrecoTributacaoRepository.AdicionarEmMassa(precosTributacoes),
                _unitOfWork.ComposicaoRepository.AdicionarEmMassa(composicao),
                _unitOfWork.RelacionaProdutoFornecedorRepository.AdicionarEmMassa(relacionaprodutoFornecedor)
            );

            response.Formulario!.SetId(produto.Id);

            await _unitOfWork.ProdutoRepository.Adicionar(produto);
            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }

        private List<PrecosTributacoes> CriarPrecosTributacoes(List<PrecosTributacoesCommand> precosTributacoesCommand, Guid idProduto)
        {
            return precosTributacoesCommand.Select(e => new PrecosTributacoes(
            idProduto, e.IdNcm, e.IdOrigemMaterial, e.IdTipoPreco, e.IdClasseReajuste, e.PrecoCusto, e.PrecoVenda, e.Inativo)).ToList();
        }

        private List<Composicao> CriarComposicao(List<ComposicaoCommand> composicaoCommand, Guid idProduto)
        {
            return composicaoCommand.Select(e => new Composicao(
                idProduto, e.IdProduto, e.SequenciaComposicao, e.PerfilH, e.PerfilL, e.Etiqueta)).ToList();
        }

        private List<RelacionaProdutoFornecedor> CriarRelacionaProdutoFornecedor(List<RelacionaProdutoFornecedorCommand>? relacionaProdutoFornecedorCommand, Guid idProduto)
        {
            return (relacionaProdutoFornecedorCommand ?? new List<RelacionaProdutoFornecedorCommand>())
                .Select(e => new RelacionaProdutoFornecedor(e.IdFornecedor, idProduto, e.CodigoProdutoFornecedor!))
                .ToList();
        }    
    }
}