using SharedKernel.SharedObjects;

namespace Domain.Entities.Impostos
{
    public class CstIpi : EntityId
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CstIpiAmigavel { get; set; }
        public bool CobraIpi { get; set; }
        public string EntradaSaida { get; set; }

        public CstIpi() { }


        public CstIpi(string nome, string cstipiamigavel, bool cobraipi, string entradasaida)
        {
            SetId(Guid.NewGuid());
            Nome = nome;
            CstIpiAmigavel = cstipiamigavel;
            CobraIpi = cobraipi;
            EntradaSaida = entradasaida;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, string cstipiamigavel, bool cobraipi, string entradasaida)
        {
            Nome = nome;
            CstIpiAmigavel = cstipiamigavel;
            CobraIpi = cobraipi;
            EntradaSaida = entradasaida;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}

