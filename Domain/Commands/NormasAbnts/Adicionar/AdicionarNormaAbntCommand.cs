using Domain.Commands.NormasAbnts;

public class AdicionarNormaAbntCommand : NormaAbntCommand<AdicionarNormaAbntCommand>
{
    
    public AdicionarNormaAbntCommand() { }

    public AdicionarNormaAbntCommand(Guid id, string? nnbr, string? descricaoNorma, string? pedido, DateTime validade, bool vencida)
        : base(id, nnbr, descricaoNorma, pedido, validade, vencida)
    {
    }
}