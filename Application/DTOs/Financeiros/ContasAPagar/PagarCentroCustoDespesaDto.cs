namespace Application.DTOs.ContasAPagar
{
    public class PagarCentroCustoDespesaDto
    {
            public int NItem { get; set; }
            public Guid? IdDespesa { get; set; }
            public Guid? IdCentroDeCusto { get; set; }
            public decimal? ValorDespesa { get; set; }      
    }
}
