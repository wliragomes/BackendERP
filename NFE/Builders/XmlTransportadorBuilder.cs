using Application.DTOs.NFes;

namespace NFE.Builders
{
    public class XmlTransportadorBuilder
    {
        public string CriaXmlTransportador(transportadorNFeDto transportadorDto)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            return util.transporta(transportadorDto.CNPJ, transportadorDto.CPF, transportadorDto.xNome, transportadorDto.IE, transportadorDto.xEnder, transportadorDto.xMun, transportadorDto.UF);
        }
    }
}
