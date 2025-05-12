using SharedKernel.MediatR;

namespace Domain.Commands.Produtos.Ncms
{
    public abstract class NcmCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string? NrNcm01 { get; set; }
        public string? NrNcm02 { get; set; }
        public string? NrNcm03 { get; set; }
        public string NrNcmCompleta { get; set; }
        public string Descricao { get; set; }
        public decimal Aliquota { get; set; }
        public bool InsiteSt {  get; set; }
        public decimal AliquotaSt { get; set; }

        public NcmCommand()
        {

        }

        public NcmCommand(Guid id, string? nrNcm01, string? nrNcm02, string? nrNcm03, string nrNcmCompleta, string descricao, decimal aliquota, bool insiteSt, decimal aliquotaSt)        
        {
            Id = id;
            NrNcm01 = nrNcm01;
            NrNcm02 = nrNcm02;
            NrNcm03 = nrNcm03;
            NrNcmCompleta = nrNcmCompleta;
            Descricao = descricao;
            Aliquota = aliquota;
            InsiteSt = insiteSt;
            AliquotaSt = aliquotaSt;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
