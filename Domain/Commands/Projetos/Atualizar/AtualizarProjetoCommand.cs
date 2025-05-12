namespace Domain.Commands.Projetos.Atualizar
{
    public class AtualizarProjetoCommand : ProjetoCommand<AtualizarProjetoCommand>
    {
        public AtualizarProjetoCommand(Guid id, string nome, bool apitar, bool tarja, bool agrupar, bool fProjeto)
            : base(id, nome, apitar, tarja, agrupar, fProjeto)
        {
        }

        public AtualizarProjetoCommand()
        {

        }
    }
}