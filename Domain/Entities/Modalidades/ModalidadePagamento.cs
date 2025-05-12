using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Modalidade : EntityId
    {
        public string DescricaoModalidade { get; set; }
        public bool ExigeNumero { get; set; }

        public Modalidade(string descricaoModalidade, bool exigeNumero)
        {
            SetId(Guid.NewGuid());
            DescricaoModalidade = descricaoModalidade;
            ExigeNumero = exigeNumero;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string descricaoModalidade, bool exigeNumero)
        {
            DescricaoModalidade = descricaoModalidade;
            ExigeNumero = exigeNumero;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
