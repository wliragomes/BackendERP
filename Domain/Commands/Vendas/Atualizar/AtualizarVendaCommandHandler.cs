﻿using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;
using Domain.Entities.Faturas;
using Domain.Entities.Vendas;
using Domain.Commands.Faturas;
using Domain.Entities.VendasItem;
using Domain.Entities.Enderecos;
using Domain.Entities;
using Domain.Commands.Pessoas;

namespace Domain.Commands.Vendas.Atualizar
{
    public class AtualizarVendaCommandHandler : IRequestHandler<AtualizarVendaCommand, FormularioResponse<AtualizarVendaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarVendaCommand> _validator;
        private const int _indice = 0;

        public AtualizarVendaCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarVendaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarVendaCommand>> Handle(AtualizarVendaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarVendaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            command.PagamentoParcelas!
               .Where(parcela => parcela.ValorParcela <= 0)
               .Select(parcela => new {
                   NomeCampo = "Valor da parcela " + parcela.SequenciaParcela,
                   Mensagem = "Nenhuma parcela pode ter valor menor ou igual a zero.",
                   Valor = parcela.ValorParcela
               })
               .ToList()
               .ForEach(erro => response.AddError(erro.NomeCampo, erro.Mensagem, erro.Valor));

            if (response.ExisteErro())
                return response;

            var vendaUpdate = await _unitOfWork.VendaRepository.ObterPorId(command.Id);

            var dataConversaoPedido = await MudouParaPedido(vendaUpdate.IdStatus.Value, command.IdStatus);

            var enderecoEntrega = CriarEndereco(command.EnderecoEntrega!);
            var enderecoCobranca = CriarEndereco(command.EnderecoCobranca!);

            Venda venda = new
            (
                vendaUpdate.IdEmpresa,
                vendaUpdate.CodigoVenda,
                vendaUpdate.AnoVenda,
                vendaUpdate.Release,
                command.IdStatus,
                vendaUpdate.DataCriacaoOrcamento,
                dataConversaoPedido.HasValue ? DateTime.Now : vendaUpdate.DataCriacaoPedido, //dataCriacaoPedido, Atualiza apenas se mudou para Pedido
                dataConversaoPedido, //dataConversaoPedido
                null, // dataFechamentoPedido, // Provavelmente será alimentado apenas quando o Jacinto Aprovar
                null, // fechamentoPedido, // Provavelmente será alimentado apenas quando o Jacinto Aprovar
                command.ValidadeOrcamentoData,
                command.ValidadePedidoData,
                command.OcultarTotal,
                command.Transporte.DetalhesFrete,
                command.NomeContato,
                command.EmailContato,
                command.TelefoneContato,
                command.DescricaoObra,
                command.Apfe,
                command.Transporte.ValorFrete,
                command.Totais.InformacoesAdicionais,
                null, //informacoesAdicionaisFisco,
                null, //percentualPis,
                null, //valorPis,
                null, //percentualCofins,
                null, //valorCofins,
                null, //cancelado,
                null, //dataCancelamento,
                null, //idMotivoCancelamentoPedidoOrcamento,
                null, //motivoCancelamentoOutrosMotivos,
                command.FaturaManual,
                command.VendaEntregaFutura,
                command.UsoConsumo,
                command.EnvioMedidas,
                null, //lancarOf,
                command.PedidoGuardian,
                command.OcutarVendedor,
                command.ImpressaoEspecial,
                command.IdCliente,
                command.IdResponsavelCompra,
                command.IdConstrutora,
                enderecoEntrega.Id,
                enderecoCobranca.Id,
                command.IdVendedor,
                command.Transporte.IdTransportadora,
                null, //engenheiro,
                command.Transporte.Retira,
                command.Transporte.Entrega,
                command.Observacao,
                null, //nomeProjeto,
                command.Totais.ValorSeguro,
                command.Totais.ValorOutrasDespesas,
                command.Totais.ValorBaseCalculoIcms,
                command.Totais.BaseCalculoSt,
                command.Totais.ValorIcms,
                command.Totais.ValorIpi,
                command.Totais.ValorTotal,
                null, //difal,
                command.Transporte.InicioEntrega,
                command.Transporte.TerminoEntrega,
                command.Transporte.FretesPrevistos,
                command.Totais.ValorFrete,
                command.PedidoCliente,
                command.Totais.Especie,
                command.Totais.QuantidadeItens,
                command.Totais.PesoBruto,
                command.Totais.PesoLiquido,
                command.Totais.ValorTotalProdutos,
                command.ComIpi,
                command.Transporte.ComFrete,
                command.Totais.NaturezaOperacao,
                command.Totais.ValorSt,
                command.Transporte.IdTipoFrete,
                command.Transporte.PlacaVeiculo,
                command.Transporte.IdUFVeiculo,
                command.IdTipoFechamento,
                command.Amostra
            );

            await _unitOfWork.VendaRepository.Adicionar(venda);
            var itens = CriarItens(command.Produtos!, venda.Id);

            var normasRelacionadas = new List<RelacionaNormaAbntVenda>();

            foreach (var item in command.NormaAbnt)
            {
                normasRelacionadas.Add(new RelacionaNormaAbntVenda(command.Id, item));
            }

            await _unitOfWork.NormaAbntRepository.AdicionarRelacionaNormaAbntEmMassa(normasRelacionadas);

            if (command.ImpressaoEspecial)
            {
                var impressaoEspecial = new ImpressaoEspecial(
                    venda.Id,
                    command.ImpressaoEspecialTexto
                );

                await _unitOfWork.ImpressaoEspecialRepository.Adicionar(impressaoEspecial);
            }

            var vendaOrdemParceiros = await CriarVendaOrdemParceiros(command.VendaOrdem!, venda.Id);
            await _unitOfWork.VendaOrdemParceiroRepository.AdicionarEmMassa(vendaOrdemParceiros);

            //pagamento | Verificar o jsn de Fatura, para fazer igual, aqui deve ter campos a mais sem necessidade
            VendaRecebimentoTipo pagamento = new VendaRecebimentoTipo(
                    command.Pagamento.QuantidadeParcelas,
                    command.Pagamento.PagamentoAntecipado,
                    command.Pagamento.ParcelasPartirPedido == true ? 1 : 2,
                    command.Pagamento.PeriodoMensal == true ? 1 : command.Pagamento.PeriodoDigitada == true ? 2 : 3,
                    command.Pagamento.PeriodoQuantidadeDias
                );
            await _unitOfWork.VendaRecebimentoTipoRepository.Adicionar(pagamento);

            RelacionaFaturaVendaRecebimentoTipo relacionaFaturaVendaRecebimentoTipo = new RelacionaFaturaVendaRecebimentoTipo(
                pagamento.Id, venda.Id, null
            );

            await _unitOfWork.RelacionaFaturaVendaRecebimentoTipoRepository.Adicionar(relacionaFaturaVendaRecebimentoTipo);

            //PagamentoParcelas
            var parcelas = CriarParcelas(command.PagamentoParcelas!, pagamento.Id);
            await _unitOfWork.VendaRecebimentoParcelaRepository.AdicionarEmMassa(parcelas);

            await _unitOfWork.VendaItemRepository.AdicionarEmMassa(itens);
            await _unitOfWork.EnderecoRepository.Adicionar(enderecoEntrega);
            await _unitOfWork.EnderecoRepository.Adicionar(enderecoCobranca);

            //TODO se for Pedido chamar procedure;

            await _unitOfWork.CommitAsync(cancellationToken);

            response.SetFormulario(command);
            return response;
        }

        private async Task<DateTime?> MudouParaPedido(Guid idStatusAnterior, Guid idStatusAtual)
        {
            var listaStatus = await _unitOfWork.VendaRepository.GetStatus();

            var statusOrcamento = listaStatus.FirstOrDefault(s => s.Numero == 1)?.Id;
            var statusPedido = listaStatus.FirstOrDefault(s => s.Numero == 2)?.Id;

            if (statusOrcamento.HasValue && statusPedido.HasValue)
            {
                if (idStatusAnterior == statusOrcamento.Value && idStatusAtual == statusPedido.Value)
                {
                    return DateTime.Now; // Mudou de Orçamento para Pedido → Retorna data atual
                }
                else if (idStatusAnterior == statusPedido.Value && idStatusAtual == statusOrcamento.Value)
                {
                    return null; // Mudou de Pedido para Orçamento → Retorna null
                }
            }

            return null; // Caso não seja nenhuma das transições esperadas
        }

        private List<VendaItem> CriarItens(List<FaturaProdutosCommand> itens, Guid idFatura)
        {
            return itens.Select(e => new VendaItem(
            idFatura, e.SequenciaItem, e.DescricaoPedidoCliente, e.NumeroItemPedidoCliente, e.IdProduto, e.DescricaoProduto, e.IdUnidadeMedida,
                          e.InformacoesAdicionais, e.Jumbo, e.NumeroFCI, e.ValorFCI, e.Quantidade, e.ValorUnitario,
                          e.ValorTotal, e.IdCFOP, e.idNCM, e.AliquotaICMS, e.BaseCalculoICMS, e.ValorICMS,
                          e.AliquotaIPI, e.ValorIPI, e.AliquotaST, e.BaseCalculoST, e.ValorST)).ToList();
        }

        private List<VendaRecebimentoParcela> CriarParcelas(List<FaturaPagamentoParcelasCommand> itens, Guid idVendaRecebimentoTipo)
        {
            return itens.Select(e => new VendaRecebimentoParcela(idVendaRecebimentoTipo, e.SequenciaParcela, e.NumeroDiasVencimento, e.DataVencimento, e.ValorParcela)).ToList();
        }

        private Endereco CriarEndereco(EnderecoCommand enderecoCommand)
        {
            if (enderecoCommand == null)
                return null;

            return new Endereco(
                enderecoCommand.IdTipoEndereco,
                enderecoCommand.EnderecoDescricao,
                enderecoCommand.Numero,
                enderecoCommand.Complemento!,
                enderecoCommand.IdCidade,
                enderecoCommand.Bairro,
                enderecoCommand.IdUf,
                enderecoCommand.Cep);
        }

        private async Task<List<VendaOrdemParceiro>> CriarVendaOrdemParceiros(List<VendaOrdemCommand> vendaOrdemList, Guid idVenda)
        {
            var parceiros = new List<VendaOrdemParceiro>();

            foreach (var item in vendaOrdemList)
            {
                // Cria e salva o endereço da venda à ordem
                var endereco = new Endereco(
                    item.Endereco.IdTipoEndereco,
                    item.Endereco.Logradouro,
                    item.Endereco.Numero,
                    item.Endereco.Complemento,
                    item.Endereco.IdCidade,
                    item.Endereco.Bairro,
                    item.Endereco.IdUf,
                    item.Endereco.Cep
                );

                await _unitOfWork.EnderecoRepository.Adicionar(endereco);

                // Cria o parceiro com o ID do endereço recém-criado
                var parceiro = new VendaOrdemParceiro(
                    idVenda,
                    item.CaixilheiroObra,
                    item.IdCliente,
                    endereco.Id,
                    item.Observacao
                );

                parceiros.Add(parceiro);
            }

            return parceiros;
        }
    }
}
