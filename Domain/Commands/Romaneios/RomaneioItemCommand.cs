namespace Domain.Commands.Romaneios
{
    public class RomaneioItemCommand
    {
        public Guid IdOrdemFabricacaoItem { get; set; }
        public int SqRomaneioItem { get; set; }
        public int QtItem { get; set; }

        public RomaneioItemCommand()
        {

        }

        public RomaneioItemCommand(Guid idOrdemFabricacaoItem, int sqRomaneioItem, int qtItem)
        {
            IdOrdemFabricacaoItem = idOrdemFabricacaoItem;
            SqRomaneioItem = sqRomaneioItem;
            QtItem = qtItem;
        }
    }
}