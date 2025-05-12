

namespace Application.DTOs.Vendas
{
    public class VendaRecebimentoTipoDto
    {
        public bool PgtoAntecipado { get; set; }
        public bool Pedido { get; set; }
        public bool Ddl { get; set; }
        public bool Mensal { get; set; }
        public bool Digitada { get; set; }
        public bool Dias { get; set; }        
        public bool ParcelaImediata { get; set; }
        public bool ValidadePedido { get; set; }
    }
}