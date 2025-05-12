using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Faturas
{
    public class FaturaItem : Entity
    {
        public Guid IdFatura { get; private set; }
        public int SequenciaItem { get; private set; }
        public string? DescricaoPedidoCliente { get; private set; }
        public string? NumeroItemPedidoCliente { get; private set; }
        public Guid IdProduto { get; private set; }
        public string DescricaoProduto { get; private set; }
        public Guid IdUnidadeMedida { get; private set; }
        public string? InformacoesAdicionais { get; private set; }
        public string? NumeroFCI { get; private set; }
        public decimal? ValorFCI { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal? PercentualDesconto { get; private set; }
        public decimal? ValorDesconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public Guid? IdCFOP { get; private set; }
        public Guid? IdNCM { get; private set; }
        public decimal AliquotaICMS { get; private set; }
        public decimal BaseCalculoICMS { get; private set; }
        public decimal ValorICMS { get; private set; }
        public decimal AliquotaIPI { get; private set; }
        public decimal ValorIPI { get; private set; }
        public decimal AliquotaST { get; private set; }
        public decimal BaseCalculoST { get; private set; }
        public decimal ValorST { get; private set; }
        public decimal? BaseCalculoPisCofins { get; private set; }
        public decimal? AliquotaPis{ get; private set; }
        public decimal? ValorPis{ get; private set; }
        public decimal? AliquotaCofins { get; private set; }
        public decimal? ValorCofins { get; private set; }

        public virtual Fatura Fatura { get; set; }
        public Produto? Produto { get; set; }

        public FaturaItem()
        {
        } 
        
        public FaturaItem(Guid idFatura, int sequenciaItem, string? descricaoPedidoCliente, string? numeroItemPedidoCliente, Guid idProduto, string descricaoProduto, Guid idUnidadeMedida,
                          string? informacoesAdicionais, string? numeroFCI, decimal? valorFCI, decimal quantidade, decimal valorUnitario, decimal? percentualDesconto, 
                          decimal? valorDesconto, decimal valorTotal, Guid? idCFOP, Guid? idNCM, decimal aliquotaICMS, decimal baseCalculoICMS, decimal valorICMS,
                          decimal aliquotaIPI, decimal valorIPI, decimal aliquotaST, decimal baseCalculoST, decimal valorST, decimal? baseCalculoPisCofins,
                          decimal? aliquotaPis, decimal? valorPis, decimal? aliquotaCofins, decimal? valorCofins)
        {
            IdFatura = idFatura;
            SequenciaItem = sequenciaItem;
            DescricaoPedidoCliente = descricaoPedidoCliente;
            NumeroItemPedidoCliente = numeroItemPedidoCliente;
            IdProduto = idProduto;
            DescricaoProduto = descricaoProduto;
            IdUnidadeMedida = idUnidadeMedida;
            InformacoesAdicionais = informacoesAdicionais;
            NumeroFCI = numeroFCI;
            ValorFCI = valorFCI;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            PercentualDesconto = percentualDesconto;
            ValorDesconto = valorDesconto;
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
            BaseCalculoPisCofins = baseCalculoPisCofins;
            AliquotaPis = aliquotaPis;
            ValorPis = valorPis;
            AliquotaCofins = aliquotaCofins;
            ValorCofins = valorCofins;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idFatura, int sequenciaItem, string descricaoPedidoCliente, string numeroItemPedidoCliente, Guid idProduto, string descricaoProduto, Guid idUnidadeMedida,
                          string informacoesAdicionais, string numeroFCI, decimal valorFCI, decimal quantidade, decimal valorUnitario, decimal percentualDesconto,
                          decimal valorDesconto, decimal valorTotal, Guid idCFOP, Guid idNCM, decimal aliquotaICMS, decimal baseCalculoICMS, decimal valorICMS,
                          decimal aliquotaIPI, decimal valorIPI, decimal aliquotaST, decimal baseCalculoST, decimal valorST, decimal baseCalculoPisCofins,
                          decimal aliquotaPis, decimal valorPis, decimal aliquotaCofins, decimal valorCofins)
        {
            IdFatura = idFatura;
            SequenciaItem = sequenciaItem;
            DescricaoPedidoCliente = descricaoPedidoCliente;
            NumeroItemPedidoCliente = numeroItemPedidoCliente;
            IdProduto = idProduto;
            DescricaoProduto = descricaoProduto;
            IdUnidadeMedida = idUnidadeMedida;
            InformacoesAdicionais = informacoesAdicionais;
            NumeroFCI = numeroFCI;
            ValorFCI = valorFCI;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            PercentualDesconto = percentualDesconto;
            ValorDesconto = valorDesconto;
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
            BaseCalculoPisCofins = baseCalculoPisCofins;
            AliquotaPis = aliquotaPis;
            ValorPis = valorPis;
            AliquotaCofins = aliquotaCofins;
            ValorCofins = valorCofins;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
