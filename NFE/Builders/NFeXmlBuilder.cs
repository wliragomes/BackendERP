namespace NFE.Builders
{
    public class NFeXmlBuilder
    {
        public string CriaXmlFinal(string Id, string ide, string emit, string dest, string retirada, string entrega, string detalhes, string total, string transp, string cobr, string pag, string infAdic)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            return util.NFe202006("4.00", Id, ide, emit, "", dest, retirada, entrega, detalhes, total, transp, cobr, pag, infAdic, "", "", "", "", "", "");
        }
    }
}
