namespace Domain.Commands.Departamentos.Atualizar
{
    public class AtualizarDepartamentoCommand : DepartamentoCommand<AtualizarDepartamentoCommand>
    {
        public AtualizarDepartamentoCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarDepartamentoCommand()
        {

        }
    }
}