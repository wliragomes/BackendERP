using Application.DTOs.Pessoas;

namespace Application.DTOs.MovimentosEstoque.Atualizar
{
    public class AtualizarMovimentoEstoqueDto : PadraoDescricaoDto
    {
        public Guid Id { get; set; }
    }
}
