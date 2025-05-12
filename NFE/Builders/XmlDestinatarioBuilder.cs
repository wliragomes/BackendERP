using Application.DTOs.NFes;

namespace NFE.Builders
{
    public class XmlDestinatarioBuilder
    {
        public string CriaXmlDestinatario(destinatarioNFeDto destDto)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            return util.destinatario310(destDto.CNPJ, destDto.CPF, destDto.idEstrangeiro, destDto.xNome, destDto.xLgr, destDto.nro, 
                destDto.xCpl, destDto.xBairro, destDto.cMun, destDto.xMun, destDto.UF, destDto.CEP, destDto.cPais, destDto.xPais,
                destDto.fone, destDto.indIEDest, destDto.IE, destDto.IESUF, destDto.IM, destDto.eMail);
        }
    }
}
