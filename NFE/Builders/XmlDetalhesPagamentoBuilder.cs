namespace NFE.Builders
{
    public class XmlDetalhesPagamentoBuilder
    {
        public string CriaXmlDetalhesPagamento(string detalhesPagamentoDto)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            string tPag = detalhesPagamentoDto == "1" ? "90" : "15";
            return util.detPag("", tPag, 0, "", "", "", "");
        }
    }
}
