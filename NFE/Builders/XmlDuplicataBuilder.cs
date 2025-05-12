using Application.DTOs.NFes;

namespace NFE.Builders
{
    public class XmlDuplicataBuilder
    {
        public string CriaXmlDuplicata(List<duplicataNFeDto> emitDto)
        {
            string Retorno = "";
            int nDup = 1;

            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            foreach (duplicataNFeDto row in emitDto)
            {
                Retorno += util.dup(nDup.ToString("D3"), Convert.ToDateTime(row.dVenc), row.vDup);
                nDup++;
            }

            return Retorno;
        }
    }
}
