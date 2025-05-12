using Application.DTOs.NFes;

namespace NFE.Builders
{
    public class XmlChaveBuilder
    {
        public ChaveNFeDto GerarChaveNFe(ChaveNfeBuscaDto chaveDto)
        {
            var chaveNfe = new ChaveNFeDto();

            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            int resultado = util.CriaChaveNFe2G(chaveDto.cUF, chaveDto.Ano, chaveDto.Mes, chaveDto.CNPJ, chaveDto.Modelo, 
                chaveDto.serie, chaveDto.numero, chaveDto.tpEmis, chaveDto.codigoSeguranca, 
                out string msgResultado, out string cNF, out string cDV, out string chaveNFe);

            if (resultado == 5601)
            {
                chaveNfe.ChaveNFe = chaveNFe;
                chaveNfe.cNF = cNF;
                chaveNfe.cDV = cDV;
                chaveNfe.numero = chaveDto.numero;
            }

            return chaveNfe;
        }
    }
}
