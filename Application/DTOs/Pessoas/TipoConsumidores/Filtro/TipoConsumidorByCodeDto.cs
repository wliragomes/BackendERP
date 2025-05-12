namespace Application.DTOs.Pessoas.TipoConsumidores.Filtro
{
    public class TipoConsumidorByCodeDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public bool? SomaItens { get; set; }
        public bool? SomaDespesasBaseIcms { get; set; }
        public bool? SomaIpiBaseIcms { get; set; }
        public bool? SomaDespesasBaseSt { get; set; }
        public bool? SomaIpiBaseSt { get; set; }
        public bool? SomaStBaseIcms { get; set; }
        public bool? Difal { get; set; }
        public bool? SubstituicaoIcms { get; set; }

    }
}
