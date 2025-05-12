using SharedKernel.MediatR;

namespace Domain.Commands.Romaneios
{
    public class RomaneioCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public int SqRomaneioCodigo { get; set; }
        public int SqRomaneioAno { get; set; }
        public int QtdFrete { get; set; }
        public List<RomaneioItemCommand>? RomaneioItem { get; set; }


        public RomaneioCommand()
        {

        }

        public RomaneioCommand(Guid id, int sqRomaneioCodigo, int sqRomaneioAno, int qtdFrete)
        {
            Id = id;
            SqRomaneioCodigo = sqRomaneioCodigo;
            SqRomaneioAno = sqRomaneioAno;
            QtdFrete = qtdFrete;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}