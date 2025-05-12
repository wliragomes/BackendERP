using SharedKernel.SharedObjects;

namespace Domain.Entities.Impostos
{
    public class Pis : EntityIdNome
    {
        public string PisAmigavel { get; set; }
        public bool DescontaPis { get; set; }

        public Pis() { }


        public Pis(string nome, string pisAmigavel, bool descontaPis)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            PisAmigavel = pisAmigavel;
            DescontaPis = descontaPis;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, string pisAmigavel, bool descontaPis)
        {
            SetNome(nome);
            PisAmigavel = pisAmigavel;
            DescontaPis = descontaPis;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
