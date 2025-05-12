using Application.DTOs.NFes;

namespace NFE.Builders
{
    public class XmlTransporteBuilder
    {
        public string CriaXmlTransporte(transporteNFeDto transporteDto)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            return util.transportador2G(transporteDto.modFrete, transporteDto.transporta, transporteDto.retTransp, 
                transporteDto.veicTransp, transporteDto.reboque, transporteDto.vagao, transporteDto.balsa, transporteDto.vol);
        }
    }
}
