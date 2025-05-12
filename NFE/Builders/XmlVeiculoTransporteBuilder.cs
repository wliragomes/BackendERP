using Application.DTOs.NFes;

namespace NFE.Builders
{
    public class XmlVeiculoTransporteBuilder
    {
        public string CriaXmlVeiculoTransporte(veiculoTransporteNFeDto veiculoTransporteDto)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            return util.veicTransp(veiculoTransporteDto.placa, veiculoTransporteDto.UF, veiculoTransporteDto.RNTC);
        }
    }
}
