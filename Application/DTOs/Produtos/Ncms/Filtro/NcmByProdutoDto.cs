using Application.DTOs.Pessoas.Filtro;

namespace Application.DTOs.Produtos.Ncms.Filtro
{
    public class NcmByProdutoDto : PadraoIdDescricaoFilterDto
    {
        public decimal? AliquotaIPI { get; set; }
        public bool InsideST { get; set; }
        public decimal? AliquotaST { get; set; }
    }
}
