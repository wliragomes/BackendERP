namespace Domain.Commands.Funcionalidades.Adicionar
{
    public class AdicionarFuncionalidadeCommand : FuncionalidadeCommand<AdicionarFuncionalidadeCommand>
    {
        public AdicionarFuncionalidadeCommand()
        {

        }

        public AdicionarFuncionalidadeCommand(Guid id, string? nome, string codigo, List<Guid> nivelAcesso)
            : base(id, nome, codigo, nivelAcesso)
        {
        }
    }
}
