namespace Domain.Commands.Funcionalidades.Atualizar
{
    public class AtualizarFuncionalidadeCommand : FuncionalidadeCommand<AtualizarFuncionalidadeCommand>
    {
        public AtualizarFuncionalidadeCommand(Guid id, string codigo, string nome, List<Guid> nivelAcesso)
            : base(id, codigo, nome, nivelAcesso)
        {
        }

        public AtualizarFuncionalidadeCommand()
        {

        }
    }
}