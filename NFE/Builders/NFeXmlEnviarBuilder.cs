using Application.DTOs.NFes;

namespace NFE.Builders
{
    public class NFeXmlEnviarBuilder
    {
        public retornoEnvioBuscaNfeDto EnviaNfe(string xmlFinal, string nomeCertificado, string licenca)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            var nfeAssinada = util.EnviaNFe2G("SP", ref xmlFinal, nomeCertificado, "4.00", out string msgDados, out string msgRetWS, out int cStat, out string msgResultado, 
                out string nroRecibo, out string dhRecbto, out string tMed, "", "", "", licenca);

            retornoEnvioBuscaNfeDto retorno = new retornoEnvioBuscaNfeDto
            {
                nfeAssinada = nfeAssinada,
                cStat = cStat,
                nroRecibo = nroRecibo,
                nroProtocolo = "",
                msgResultado = msgResultado
            };

            return retorno;
        }
    }
}
