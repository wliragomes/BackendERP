namespace Domain.Commands.SegmentoClientes.Adicionar
{
    public class AdicionarSegmentoClienteCommand : SegmentoClienteCommand<AdicionarSegmentoClienteCommand>
    {
        public AdicionarSegmentoClienteCommand()
        {

        }

        public AdicionarSegmentoClienteCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}