using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class TipoFrete : EntityId
    {
        public int NFrete { get; set; }
        public string? Descricao { get; set; }
        public string? DescricaoResumida { get; set; }

        public TipoFrete() { }

        public TipoFrete(int nFrete, string descricao, string descricaoresumida)
        {
            SetId(Guid.NewGuid());
            NFrete = nFrete;
            Descricao = descricao;
            DescricaoResumida = descricaoresumida;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(int nFrete, string descricao, string descricaoresumida)
        {
            NFrete = nFrete;
            Descricao = descricao;
            DescricaoResumida = descricaoresumida;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
