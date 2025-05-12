namespace Domain.Commands.NiveisAcessos.Atualizar
{
    public class AtualizarNivelAcessoCommand : NivelAcessoCommand<AtualizarNivelAcessoCommand>
    {
        public AtualizarNivelAcessoCommand(Guid id, string codigo, string nome)
            : base(id, codigo, nome)
        {
        }

        public AtualizarNivelAcessoCommand()
        {

        }
    }
}