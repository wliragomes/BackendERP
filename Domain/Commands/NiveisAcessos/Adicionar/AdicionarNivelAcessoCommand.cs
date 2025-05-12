namespace Domain.Commands.NiveisAcessos.Adicionar
{
    public class AdicionarNivelAcessoCommand : NivelAcessoCommand<AdicionarNivelAcessoCommand>
    {
        public AdicionarNivelAcessoCommand()
        {

        }

        public AdicionarNivelAcessoCommand(Guid id, string? nome, string codigo)
            : base(id, nome, codigo)
        {
        }
    }
}
