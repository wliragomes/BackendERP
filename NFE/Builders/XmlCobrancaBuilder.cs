using Application.DTOs.NFes;
using System.Runtime.Intrinsics.Arm;

namespace NFE.Builders
{
    public class XmlCobrancaBuilder
    {
        public string CriaXmlCobranca(cobrancaNFeDto cobrancaDto)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            return util.cobr(cobrancaDto.nFat, cobrancaDto.vOrig, cobrancaDto.vDesc, cobrancaDto.vLiq, cobrancaDto.dup);
        }
    }
}
