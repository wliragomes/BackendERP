namespace Application.DTOs.Caminhoes
{
    public class CaminhaoByCodeDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public int CaminhaoCarreta { get; set; }
        public string Numero { get; set; }
        public string Placa { get; set; }
        public decimal Tara { get; set; }
        public decimal CapacidadeKg { get; set; }
        public decimal CapacidadeM3 { get; set; }
        public Guid IdPessoa { get; set; }
        public Guid IdTipoRodado { get; set; }
        public Guid IdTipoCarroceria { get; set; }
        public Guid IdEstado { get; set; }
        public bool Inativo { get; set; }

    }
}
