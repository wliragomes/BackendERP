namespace Application.DTOs.NFes
{
    public class retornoEnvioBuscaNfeDto
    {
        public string nfeAssinada { get; set; }
        public string nfeBuscada { get; set; }
        public int cStat { get; set; }
        public string nroRecibo { get; set; }
        public string nroProtocolo { get; set; }
        public string msgResultado { get; set; }
    }
}
