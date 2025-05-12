using Domain.Commands.Produtos.ClasseReajustes;

namespace Domain.Commands.Produtos.DesgastePolimentos.Adicionar
{
    public class AdicionarDesgastePolimentoCommand : DesgastePolimentoCommand<AdicionarDesgastePolimentoCommand>
    {
        public AdicionarDesgastePolimentoCommand()
        {

        }

        public AdicionarDesgastePolimentoCommand(Guid id, decimal espessuraVidroMinimo, decimal espessuraVidroMaximo,
                                                 decimal quantidadeDesgasteLado, decimal quantidadeDesgasteTotal)
            : base(id, espessuraVidroMinimo, espessuraVidroMaximo, quantidadeDesgasteLado, quantidadeDesgasteTotal)
        {
        }
    }
}
