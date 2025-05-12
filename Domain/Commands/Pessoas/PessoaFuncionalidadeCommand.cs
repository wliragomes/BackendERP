namespace Application.DTOs.Funcionalidades
{
    public class PessoaFuncionalidadeCommand
    {
        public Guid IdFuncionalidade { get; set; }

        public List<PessoaNivelAcessoCommand> NivelAcesso { get; set; }

    }

}

