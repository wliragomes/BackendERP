using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class MinimoCobrancaItem : Entity
    {
        public Guid IdMinimoCobranca {  get; set; }
        public Guid IdSetorProduto {  get; set; }
        public string DescricaoSetorProduto {  get; set; }
        public MinimoCobranca MinimoCobranca { get; set; }

        public MinimoCobrancaItem(Guid idMinimoCobranca, Guid idSetorProduto, string descricaoSetorProduto)
        {
            IdMinimoCobranca = idMinimoCobranca;
            IdSetorProduto = idSetorProduto;
            DescricaoSetorProduto = descricaoSetorProduto;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idMinimoCobranca, Guid idSetorProduto, string descricaoSetorProduto)
        {
            IdMinimoCobranca = idMinimoCobranca;
            IdSetorProduto = idSetorProduto;
            DescricaoSetorProduto = descricaoSetorProduto;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
