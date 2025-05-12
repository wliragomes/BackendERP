namespace Application.DTOs.NormasAbnts.Filtro
{
    public class NormaAbntFilterDto
    {
        public Guid Id { get; set; }     
        public string? NNbr { get; set; }        
        public string? Descricao { get; set; }               
        public string? Pedido { get; set; }               
        public DateTime? Validade { get; set; } 
        public bool Vencida { get; set; }      
        
    }
}
