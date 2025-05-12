namespace Domain.Commands.SegmentoEstrategicos.Atualizar
{
    public class AtualizarSegmentoEstrategicoCommand : SegmentoEstrategicoCommand<AtualizarSegmentoEstrategicoCommand>
    {
        public AtualizarSegmentoEstrategicoCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarSegmentoEstrategicoCommand()
        {

        }
    }
}