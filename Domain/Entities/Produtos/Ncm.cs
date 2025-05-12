using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class Ncm : EntityId
    {
        public string? NrNcm01 { get; set; }
        public string? NrNcm02 { get; set; }
        public string? NrNcm03 { get; set; }
        public string? NrNcmCompleta { get; set; }
        public string? Descricao { get; set; }   
        public decimal? Aliquota { get; set; }
        public bool? InsiteSt { get; set; }
        public decimal? AliquotaSt { get; set; }

        public Ncm() { }

        public Ncm(string? nrNcm01, string? nrNcm02, string? nrNcm03, string nrNcmCompleta, string descricao, decimal aliquota, bool insiteSt, decimal? aliquotaSt)
        {
            SetId(Guid.NewGuid());
            NrNcm01 = nrNcm01;
            NrNcm02 = nrNcm02;
            NrNcm03 = nrNcm03;
            NrNcmCompleta = nrNcmCompleta;
            Descricao = descricao;
            Aliquota = aliquota;
            InsiteSt = insiteSt;
            AliquotaSt = aliquotaSt;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string? nrNcm01, string? nrNcm02, string? nrNcm03, string nrNcmCompleta, string descricao, decimal aliquota, bool insiteSt, decimal aliquotaSt)
        {
            NrNcm01 = nrNcm01;
            NrNcm02 = nrNcm02;
            NrNcm03 = nrNcm03;
            NrNcmCompleta = nrNcmCompleta;
            Descricao = descricao;
            Aliquota = aliquota;
            InsiteSt = insiteSt;
            AliquotaSt = aliquotaSt;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
