namespace Domain.Commands.Classificacoes.Atualizar
{
    public class AtualizarClassificacaoCommand : ClassificacaoCommand<AtualizarClassificacaoCommand>
    {
        public AtualizarClassificacaoCommand(Guid id, string nome)
            : base(id, nome)
        {
        }

        public AtualizarClassificacaoCommand()
        {

        }
    }
}