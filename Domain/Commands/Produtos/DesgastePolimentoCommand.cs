using SharedKernel.MediatR;

namespace Domain.Commands.Produtos.ClasseReajustes
{
    public abstract class DesgastePolimentoCommand<T> : CommandBase<T>
    {

        public Guid Id { get; set; }
        public decimal EspessuraVidroMinimo { get; set; }
        public decimal EspessuraVidroMaximo { get; set; }
        public decimal QuantidadeDesgasteLado { get; set; }
        public decimal QuantidadeDesgasteTotal { get; set; }

        public DesgastePolimentoCommand()
        {
        }
        public DesgastePolimentoCommand(Guid id, decimal espessuraVidroMinimo, decimal espessuraVidroMaximo,
                                        decimal quantidadeDesgasteLado, decimal quantidadeDesgasteTotal)
        {
            Id = id;
            EspessuraVidroMinimo = espessuraVidroMinimo;
            EspessuraVidroMaximo = espessuraVidroMaximo;
            QuantidadeDesgasteLado = quantidadeDesgasteLado;
            QuantidadeDesgasteTotal = quantidadeDesgasteTotal;
    }
    public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
