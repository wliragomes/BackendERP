using Application.DTOs.NFes;

namespace NFE.Builders
{
    public class XmlVolumeBuilder
    {
        public string CriaXmlVolume(volumeNFeDto volumeDto)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            return util.vol(volumeDto.qVol, volumeDto.esp, volumeDto.marca, volumeDto.nVol, volumeDto.pesoL, volumeDto.pesoB, volumeDto.lacres);
        }
    }
}
