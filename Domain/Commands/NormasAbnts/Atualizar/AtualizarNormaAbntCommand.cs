namespace Domain.Commands.NormasAbnts.Atualizar
{
    public class AtualizarNormaAbntCommand : NormaAbntCommand<AtualizarNormaAbntCommand>
    {
        public AtualizarNormaAbntCommand() { }

        public AtualizarNormaAbntCommand(Guid id, string nnbr, string descricao, string pedido, DateTime? validade, bool vencida)
            : base(id, nnbr, descricao, pedido, validade, vencida)
        {
        }
    }
}