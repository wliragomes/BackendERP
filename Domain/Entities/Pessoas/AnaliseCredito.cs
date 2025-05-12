using SharedKernel.SharedObjects;

namespace Domain.Entities.Pessoas
{
    public class AnaliseCredito : EntityId
    {
        public Guid? IdPessoa { get; private set; }
        public DateTime? DataConsulta { get; private set; }
        public string OrgaoConsulta { get; private set; }
        public Guid IdResponsavelConsulta { get; private set; }
        public string Observacao { get; private set; }
        public Pessoa? Pessoa { get; private set; }
        public Pessoa? ResponsavelConsulta { get; private set; }

        public AnaliseCredito(Guid? idPessoa, DateTime? dataConsulta, string orgaoConsulta, Guid idResponsavelConsulta, string observacao)
        {
            SetId(Guid.NewGuid());
            IdPessoa = idPessoa;
            DataConsulta = dataConsulta;
            OrgaoConsulta = orgaoConsulta;
            IdResponsavelConsulta = idResponsavelConsulta;
            Observacao = observacao;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid? idPessoa, DateTime? dataConsulta, string orgaoConsulta, Guid idResponsavelConsulta, string observacao)
        {
            IdPessoa = idPessoa;
            DataConsulta = dataConsulta;
            OrgaoConsulta = orgaoConsulta;
            IdResponsavelConsulta = idResponsavelConsulta;
            Observacao = observacao;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
