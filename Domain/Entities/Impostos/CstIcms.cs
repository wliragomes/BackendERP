using SharedKernel.SharedObjects;

namespace Domain.Entities.Impostos
{
    public class CST_ICMS : EntityIdNome
    {
        public string CstIcmsAmigavel { get; set; }
        public bool DescontaIcms { get; set; }

        public CST_ICMS() { }


        public CST_ICMS(string nome, string csticmsamigavel, bool descontaicms)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            CstIcmsAmigavel = csticmsamigavel;
            DescontaIcms = descontaicms;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, string csticmsamigavel, bool descontaicms)
        {
            SetNome(nome);
            CstIcmsAmigavel = csticmsamigavel;
            DescontaIcms = descontaicms;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
