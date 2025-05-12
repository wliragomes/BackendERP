using SharedKernel.MediatR;

namespace Domain.Commands.MinimoCobrancas
{
    public class MinimoCobrancaCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorMinimoCobranca { get; set; }
        public List<MinimoCobrancaItemCommand> MinimoCobrancaItem { get; set; }

        public MinimoCobrancaCommand()
        {

        }

        public MinimoCobrancaCommand(Guid id, string descricao, decimal valorMinimoCobranca)
        {
            Id = id;
            Descricao = descricao;
            ValorMinimoCobranca = valorMinimoCobranca;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}