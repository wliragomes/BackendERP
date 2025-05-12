namespace Domain.Commands.SegmentoEstrategicos.Adicionar
{
    public class AdicionarSegmentoEstrategicoCommand : SegmentoEstrategicoCommand<AdicionarSegmentoEstrategicoCommand>
    {
        public AdicionarSegmentoEstrategicoCommand()
        {

        }

        public AdicionarSegmentoEstrategicoCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}