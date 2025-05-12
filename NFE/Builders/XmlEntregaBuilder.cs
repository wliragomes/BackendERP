using Application.DTOs.NFes;

namespace NFE.Builders
{
    public class XmlEntregaBuilder
    {
        public string CriaXmlEntrega(entregaNFeDto entregaDto)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            return util.localEntrega2G(entregaDto.CNPJ, entregaDto.CPF, entregaDto.xLgr, entregaDto.nro, entregaDto.xCpl, entregaDto.xBairro, entregaDto.cMun, entregaDto.xMun, entregaDto.UF);
        }
    }
}
