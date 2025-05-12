namespace Domain.Commands.Departamentos.Adicionar
{
    public class AdicionarDepartamentoCommand : DepartamentoCommand<AdicionarDepartamentoCommand>
    {
        public AdicionarDepartamentoCommand()
        {

        }

        public AdicionarDepartamentoCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}