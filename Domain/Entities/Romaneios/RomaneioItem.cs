using Domain.Entities.Vendas;
using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class RomaneioItem : Entity
    {
        public Guid IdRomaneio { get; set; }
        public Guid IdOrdemFabricacaoItem { get; set; }
        public int SqRomaneioItem { get; set; }
        public int QtItem { get; set; }
        public Romaneio? Romaneio { get; set; }

        public RomaneioItem(Guid idRomaneio, Guid idOrdemFabricacaoItem, int sqRomaneioItem, int qtItem)
        {
            IdRomaneio = idRomaneio;
            IdOrdemFabricacaoItem = idOrdemFabricacaoItem;
            SqRomaneioItem = sqRomaneioItem;
            QtItem = qtItem;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idRomaneio, Guid idOrdemFabricacaoItem, int sqRomaneioItem, int qtItem)
        {
            IdRomaneio = idRomaneio;
            IdOrdemFabricacaoItem = idOrdemFabricacaoItem;
            SqRomaneioItem = sqRomaneioItem;
            QtItem = qtItem;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
