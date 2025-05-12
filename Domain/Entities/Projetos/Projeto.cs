using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Projeto : EntityIdNome
    {
        public bool Apitar { get; set; }
        public bool Tarja { get; set; }
        public bool Agrupar { get; set; }
        public bool FProjeto { get; set; }
        public virtual OrdemFabricacaoItem OrdemFabricacaoItem { get; set; }

        public Projeto(string nome, bool apitar, bool tarja, bool agrupar, bool fProjeto)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            Apitar = apitar;
            Tarja = tarja;
            Agrupar = agrupar;
            FProjeto = fProjeto;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, bool apitar, bool tarja, bool agrupar, bool fProjeto)
        {
            SetNome(nome);
            Apitar = apitar;
            Tarja = tarja;
            Agrupar = agrupar;
            FProjeto = fProjeto;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
