using SharedKernel.MediatR;

namespace Domain.Commands.OrdensFabricacoes
{
    public class OrdemFabricacaoItemTemporariaCommand
    {
        public Guid Id { get; set; }
        public Guid IdVenda { get; set; }
        public int SqVendaItem { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public decimal ValorM2 { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorPeso { get; set; }
        public decimal ValorMLinearReal { get; set; }
        public decimal ValorMLinear { get; set; }

        public OrdemFabricacaoItemTemporariaCommand()
        {

        }

        public OrdemFabricacaoItemTemporariaCommand(Guid id, Guid idVenda, int sqVendaItem, decimal altura, decimal largura, decimal valorM2, int quantidade,
                                                    decimal valorPeso, decimal valorMLinearReal, decimal valorMLinear)
        {
            IdVenda = idVenda;
            SqVendaItem = sqVendaItem;
            Altura = altura;
            Largura = largura;
            ValorM2 = valorM2;
            Quantidade = quantidade;
            ValorPeso = valorPeso;
            ValorMLinearReal = valorMLinearReal;
            ValorMLinear = valorMLinear;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}