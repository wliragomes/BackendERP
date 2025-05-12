using Application.DTOs.Funcionalidades;

namespace Domain.Commands.Pessoas
{
    public class PermissaoCommand
    {
        public PessoaFuncionalidadeCommand Funcionalidade { get; set; }
    }
}
