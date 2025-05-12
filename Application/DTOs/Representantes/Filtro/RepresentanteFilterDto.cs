namespace Application.DTOs.Representantes.Filtro
{
    public class RepresentanteFilterDto
    {
        public Guid Id { get; set; }
        public Guid IdPessoa { get; set; }
        public bool Externo { get; set; }
        public decimal Comissao { get; set; }

    }
}