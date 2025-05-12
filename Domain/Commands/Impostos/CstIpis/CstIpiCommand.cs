using SharedKernel.MediatR;

namespace Domain.Commands.Impostos.CstIpis
{
    public abstract class CstIpiCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CstIpiAmigavel { get; set; }
        public bool CobraIpi { get; set; }
        public string EntradaSaida { get; set; }
        public CstIpiCommand()
        {

        }

        public CstIpiCommand(Guid id, string nome, string cstipiamigavel, bool cobraipi, string entradasaida)
        {
            Id = id;
            Nome = nome;
            CstIpiAmigavel = cstipiamigavel;
            CobraIpi = cobraipi;
            EntradaSaida = entradasaida;

        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
