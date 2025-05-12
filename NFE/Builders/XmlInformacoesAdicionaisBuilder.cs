using Application.DTOs.NFes;

namespace NFE.Builders
{
    public class XmlInformacoesAdicionaisBuilder
    {
        public string CriaXmlInformacoesAdicionais(informacoesAdicionaisDtoNFeDto informacoesAdicionaisDto)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            return util.infAdic2G(informacoesAdicionaisDto.infAdFisco, informacoesAdicionaisDto.infCpl, informacoesAdicionaisDto.obsCont, informacoesAdicionaisDto.obsFisco, informacoesAdicionaisDto.procRef);
        }
    }
}
