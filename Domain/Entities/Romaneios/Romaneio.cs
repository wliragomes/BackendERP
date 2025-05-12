using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Romaneio : EntityId
    {
        public int SqRomaneioCodigo { get; private set; }
        public int SqRomaneioAno { get; private set; }
        public int QtdFrete { get; private set; }
        public ICollection<RomaneioItem> RomaneioItem { get; private set; }


        public Romaneio(int sqRomaneioCodigo, int sqRomaneioAno, int qtdFrete)
        {
            SetId(Guid.NewGuid());
            SqRomaneioCodigo = sqRomaneioCodigo;
            SqRomaneioAno = sqRomaneioAno;
            QtdFrete = qtdFrete;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(int sqRomaneioCodigo, int sqRomaneioAno, int qtdFrete)
        {
            SqRomaneioCodigo = sqRomaneioCodigo;
            SqRomaneioAno = sqRomaneioAno;
            QtdFrete = qtdFrete;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
