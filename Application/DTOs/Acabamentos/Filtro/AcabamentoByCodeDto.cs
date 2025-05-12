using Application.DTOs.Acabamentos.Filtro;

namespace Application.DTOs.Acabamentos
{
    public class AcabamentoByCodeDto : AcabamentoDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool Tolerancia { get; set; }

    }
}