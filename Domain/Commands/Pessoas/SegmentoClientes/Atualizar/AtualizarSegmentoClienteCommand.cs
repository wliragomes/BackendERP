namespace Domain.Commands.SegmentoClientes.Atualizar
{
    public class AtualizarSegmentoClienteCommand : SegmentoClienteCommand<AtualizarSegmentoClienteCommand>
    {
        public AtualizarSegmentoClienteCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarSegmentoClienteCommand()
        {

        }
    }
}