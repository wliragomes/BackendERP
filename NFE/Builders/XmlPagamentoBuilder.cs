namespace NFE.Builders
{
    public class XmlPagamentoBuilder
    {
        public string CriaXmlPagamento(string detalhesPagamento)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            return util.pagamento400(detalhesPagamento, 0);
        }
    }
}
