using Domain.Entities.Produtos;
using Domain.Entities.Vendas;
using SharedKernel.SharedObjects;

namespace Domain.Entities.VendasItem
{
    public class VendaItem : Entity
    {
        public Guid IdVenda { get; set; }
        public int SequenciaItem { get; set; }
        public Guid IdProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string InformacoesAdicionais { get; set; }
        public bool? Jumbo { get; set; }
        public string DescricaoPedidoCliente { get; set; }
        public string NumeroItemPedidoCliente { get; set; }
        public string? NumeroFci { get; set; }
        public decimal? ValorFci { get; set; }
        public Guid IdUnidadeMedida { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; private set; }
        public Guid? IdCFOP { get; set; }
        public Guid? IdNCM { get; private set; }
        public decimal IvaProduto { get; set; }
        public decimal AliquotaICMS { get; private set; }
        public decimal BaseCalculoICMS { get; private set; }
        public decimal ValorICMS { get; private set; }
        public decimal AliquotaIPI { get; private set; }
        public decimal ValorIPI { get; private set; }
        public decimal BaseCalculoST { get; private set; }
        public decimal AliquotaST { get; private set; }
        public decimal ValorST { get; private set; }

        public Venda? Venda { get; set; }
        public Produto? Produto { get; set; }
        public UnidadeMedida? UnidadeMedida { get; set; }

        public VendaItem()
        { 
        }

        public VendaItem(Guid idVenda, int sequenciaItem, string? descricaoPedidoCliente, string? numeroItemPedidoCliente, Guid idProduto, string descricaoProduto, Guid idUnidadeMedida,
                          string? informacoesAdicionais, bool? jumbo, string? numeroFci, decimal? valorFci, decimal quantidade, decimal valorUnitario, 
                          decimal valorTotal, Guid? idCFOP, Guid? idNCM, decimal aliquotaICMS, decimal baseCalculoICMS, decimal valorICMS,
                          decimal aliquotaIPI, decimal valorIPI, decimal aliquotaST, decimal baseCalculoST, decimal valorST)
        {
            IdVenda = idVenda;
            SequenciaItem = sequenciaItem;
            DescricaoPedidoCliente = descricaoPedidoCliente;
            NumeroItemPedidoCliente = numeroItemPedidoCliente;
            IdProduto = idProduto;
            DescricaoProduto = descricaoProduto;
            IdUnidadeMedida = idUnidadeMedida;
            InformacoesAdicionais = informacoesAdicionais;
            Jumbo = jumbo;
            NumeroFci = numeroFci;
            ValorFci = valorFci;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            ValorTotal = valorTotal;
            IdCFOP = idCFOP;
            IdNCM = idNCM;
            AliquotaICMS = aliquotaICMS;
            BaseCalculoICMS = baseCalculoICMS;
            ValorICMS = valorICMS;
            AliquotaIPI = aliquotaIPI;
            ValorIPI = valorIPI;
            AliquotaST = aliquotaST;
            BaseCalculoST = baseCalculoST;
            ValorST = valorST;

            SetCreateAtAndUpdateAtToNow();
        }

        public VendaItem(Guid idVenda, int vendaItemSequencia, Guid idProduto, string descricaoProduto,
                         string textoProdutoAdicional, bool jumbo, string numeroPedido, string numeroItemPedido,
                         string numeroFci, decimal valorFci,
                         Guid idUnidadeMedida, decimal quantidadeProduto, decimal valorProduto, Guid idCfop, decimal ivaProduto)
        {
            IdVenda = idVenda;
            SequenciaItem = vendaItemSequencia;
            IdProduto = idProduto;
            DescricaoProduto = descricaoProduto;
            InformacoesAdicionais = textoProdutoAdicional;
            Jumbo = jumbo;
            DescricaoPedidoCliente = numeroPedido;
            NumeroItemPedidoCliente = numeroItemPedido;
            NumeroFci = numeroFci;
            ValorFci = valorFci;
            IdUnidadeMedida = idUnidadeMedida;
            Quantidade = quantidadeProduto;
            ValorUnitario = valorProduto;
            IdCFOP = idCfop;
            IvaProduto = ivaProduto;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idVenda, int vendaItemSequencia, Guid idProduto, string descricaoProduto,
                           string textoProdutoAdicional, bool jumbo, string numeroPedido, string numeroItemPedido,
                           string numeroFci, decimal valorFci,
                           Guid idUnidadeMedida, decimal quantidadeProduto, decimal valorProduto, Guid idCfop, decimal ivaProduto)
        {
            IdVenda = idVenda;
            SequenciaItem = vendaItemSequencia;
            IdProduto = idProduto;
            DescricaoProduto = descricaoProduto;
            InformacoesAdicionais = textoProdutoAdicional;
            Jumbo = jumbo;
            DescricaoPedidoCliente = numeroPedido;
            NumeroItemPedidoCliente = numeroItemPedido;
            NumeroFci = numeroFci;
            ValorFci = valorFci;
            IdUnidadeMedida = idUnidadeMedida;
            Quantidade = quantidadeProduto;
            ValorUnitario = valorProduto;
            IdCFOP = idCfop;
            IvaProduto = ivaProduto;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
