namespace Application.DTOs.OrdensFabricacoes.Filtro
{
    public class OrdemFabricacaoFilterDto
    {
        public Guid Id { get; set; }
        public int SqOrdemFabricacaoCodigo { get; set; }
        public int SqOrdemFabricacaoAno { get; set; }
        public Guid IdVenda { get; set; }
        public Guid IdPessoa { get; set; }
        public string NomeContato { get; set; }
    }
}
