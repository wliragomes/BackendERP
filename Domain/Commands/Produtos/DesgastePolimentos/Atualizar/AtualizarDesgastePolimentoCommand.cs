using Domain.Commands.Produtos.ClasseReajustes;

namespace Domain.Commands.Produtos.AtualizarDesgastes.Atualizar
{
    public class AtualizarDesgastePolimentoCommand : DesgastePolimentoCommand<AtualizarDesgastePolimentoCommand>
    {
        public AtualizarDesgastePolimentoCommand(Guid id, decimal espessuraVidroMinimo, decimal espessuraVidroMaximo,
                                                    decimal quantidadeDesgasteLado, decimal quantidadeDesgasteTotal)
            : base(id, espessuraVidroMinimo, espessuraVidroMaximo, quantidadeDesgasteLado, quantidadeDesgasteTotal)
        {
        }

        public AtualizarDesgastePolimentoCommand()
        {

        }
    } 
}
