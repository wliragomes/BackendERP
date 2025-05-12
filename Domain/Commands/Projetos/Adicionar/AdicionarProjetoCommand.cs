namespace Domain.Commands.Projetos.Adicionar
{
    public class AdicionarProjetoCommand : ProjetoCommand<AdicionarProjetoCommand>
    {
        public AdicionarProjetoCommand()
        {

        }

        public AdicionarProjetoCommand(Guid id, string nome, bool apitar, bool tarja, bool agrupar, bool fProjeto)
            : base(id, nome, apitar, tarja, agrupar, fProjeto)
        {
        }
    }
}
