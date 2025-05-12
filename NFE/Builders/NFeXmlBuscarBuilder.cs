using Application.DTOs.NFes;

namespace NFE.Builders
{
    public class NFeXmlBuscarBuilder
    {
        public retornoEnvioBuscaNfeDto BuscaNfe(string nfeAssinada, string nroRecibo, int tipoAmbiente, string nomeCertificado, string licenca)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            var nfeBuscada = util.BuscaNFe2G("SP", tipoAmbiente, ref nfeAssinada, nroRecibo, nomeCertificado, "4.00", out string msgDados, out string msgRetWS, out int cStat, 
                out string msgResultado, out string nroProtocolo, out string dhProtocolo, out string cMsg, out string xMsg, "", "", "", licenca);
            
            retornoEnvioBuscaNfeDto retorno = new retornoEnvioBuscaNfeDto
            {
                nfeAssinada = nfeAssinada,
                cStat = cStat,
                nroRecibo = nroRecibo,
                nroProtocolo = "",
                msgResultado = msgResultado
            };

            retornoEnvioBuscaNfeDto xml = new retornoEnvioBuscaNfeDto
            {
                nfeBuscada = nfeBuscada,
                cStat = cStat,
                nroRecibo = nroRecibo,
                nroProtocolo = nroProtocolo,
                msgResultado = msgResultado
            };

            return retorno;
        }
    }
}
