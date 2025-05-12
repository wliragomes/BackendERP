using Application.DTOs.Pessoas;

namespace Application.DTOs.Funcionalidades
{
    public class PessoaFuncionalidadeDto
    {
        public Guid IdFuncionalidade { get; set; }

        public List<PessoaNivelAcessoDto> NivelAcesso { get; set; }

    }
}
