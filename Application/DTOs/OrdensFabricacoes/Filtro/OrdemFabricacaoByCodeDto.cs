using Application.DTOs.OrdensFabricacoes.Filtro;

namespace Application.DTOs.OrdensFabricacoes
{
    public class OrdemFabricacaoByCodeDto
    {
        public Guid Id { get; set; }
        public Guid IdVenda { get; set; }
        public int SqOrdemFabricacaoCodigo { get; set; }
        public int SqOrdemFabricacaoAno { get; set; }
        public Guid IdStatus { get; set; }
        public Guid IdPessoa { get; set; }
        public decimal VidroModulado { get; set; }
        public bool Chapa { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEfetivacao { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public Guid IdEnderecoEntrega { get; set; }
        public string Obra { get; set; }
        public string Engenheiro { get; set; }
        public string Observacao { get; set; }
        public bool EtiquetaGrandeTemperado { get; set; }
        public bool DescargaCliente { get; set; }
        public int DiasEntrega { get; set; }
        public DateTime DataEntrega { get; set; }
        public List<OrdemFabricacaoArquivoFilterDto> OrdemFabricacaoArquivo { get; set; }
        public List<OrdemFabricacaoItemDto> OrdemFabricacaoItem { get; set; }        
    }
}