namespace Application.DTOs.Vendas.Filtro
{
    public class OrdemFabricacaoGetDto
    {
        public Guid Id { get; set; }
        public Guid IdPessoa { get; set; }
        public string RazaoSocial { get; set; }
        public int SqOrdemFabricacaoCodigo { get; set; }
        public int SqOrdemFabricacaoAno { get; set; }
        public string Obra { get; set; }
    }
}
