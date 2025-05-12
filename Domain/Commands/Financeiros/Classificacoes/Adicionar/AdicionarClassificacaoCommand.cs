namespace Domain.Commands.Classificacoes.Adicionar
{
    public class AdicionarClassificacaoCommand : ClassificacaoCommand<AdicionarClassificacaoCommand>
    {
        public AdicionarClassificacaoCommand()
        {

        }

        public AdicionarClassificacaoCommand(Guid id, string? nome)
            : base(id, nome)
        {
        }
    }
}
