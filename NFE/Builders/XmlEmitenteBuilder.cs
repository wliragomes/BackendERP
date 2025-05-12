using Application.DTOs.NFes;

namespace NFE.Builders
{
    public class XmlEmitenteBuilder
    {
        public string CriaXmlEmitente(emitenteNFeDto emitDto)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            return util.emitente2G(emitDto.CNPJ, emitDto.CPF, emitDto.xNome, emitDto.xFant, emitDto.xLgr, emitDto.nro,
                emitDto.xCpl, emitDto.xBairro, emitDto.cMun, emitDto.xMun, emitDto.UF, emitDto.CEP, emitDto.cPais, 
                emitDto.xPais, emitDto.fone, emitDto.IE, emitDto.IEST, emitDto.IM, emitDto.CNAE, emitDto.CRT);
        }
    }
}
