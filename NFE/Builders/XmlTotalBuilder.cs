namespace NFE.Builders
{
    public class XmlTotalBuilder
    {
        public string CriaXmlTotal(string icmsTot)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            return util.total(icmsTot, "", ""); ;
        }
    }
}
