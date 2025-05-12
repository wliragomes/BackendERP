using SharedKernel.SharedObjects;

namespace Domain.Entities.Impostos
{
    public class Cofins : EntityIdNome
    {
        public string CofinsAmigavel { get; set; }
        public bool DescontaCofins { get; set; }

        public Cofins() { }


        public Cofins(string nome, string cofinsAmigavel, bool descontaCofins)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            CofinsAmigavel = cofinsAmigavel;
            DescontaCofins = descontaCofins;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, string cofinsAmigavel, bool descontaCofins)
        {
            SetNome(nome);
            CofinsAmigavel = cofinsAmigavel;
            DescontaCofins = descontaCofins;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
