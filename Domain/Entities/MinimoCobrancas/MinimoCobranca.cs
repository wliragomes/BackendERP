using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class MinimoCobranca : EntityIdDescricao
    {
        public decimal ValorMinimoCobranca { get; set; }
        public List<MinimoCobrancaItem> MinimoCobrancaItem { get; set; }

        public MinimoCobranca(string descricao, decimal valorMinimoCobranca)
        {
            SetId(Guid.NewGuid());
            SetDescricao(descricao);
            ValorMinimoCobranca = valorMinimoCobranca;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string descricao, decimal valorMinimoCobranca)
        {
            SetDescricao(descricao);
            ValorMinimoCobranca = valorMinimoCobranca;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
