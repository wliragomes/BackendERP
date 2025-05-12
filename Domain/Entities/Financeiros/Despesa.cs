namespace Domain.Entities
{
    public class Despesa
    {
        public Guid Id { get; set; }
        public Guid IdCentroDeCusto { get; set; }
        public string SequenciaPlanoDeContas { get; set; }
        public string Descricao { get; set; }
    }
}