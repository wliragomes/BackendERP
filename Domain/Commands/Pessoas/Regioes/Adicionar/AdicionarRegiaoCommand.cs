namespace Domain.Commands.Regioes.Adicionar
{
    public class AdicionarRegiaoCommand : RegiaoCommand<AdicionarRegiaoCommand>
    {
        public AdicionarRegiaoCommand()
        {

        }

        public AdicionarRegiaoCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}