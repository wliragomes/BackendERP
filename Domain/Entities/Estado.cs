using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Estado : EntityIdNome
    {
        public Guid IdPais { get; private set; }
        public string Sigla { get; private set; }
        public string? CodIBGE { get; private set; }
        public decimal? AliquotaIcmsInterestadual { get; private set; }
        public decimal? AliquotaIcmsInterna { get; private set; }
        public decimal? AliquotaIcmsDiferenca { get; private set; }
        public decimal? AliquotaFundoPobreza { get; private set; }
        public ICollection<Cidade>? Cidades { get; private set; }
        public Pais? Pais { get; private set; }

        public Estado(Guid idPais, string nome, string sigla, string? codIBGE, decimal? aliquotaIcmsInterestadual, decimal? aliquotaIcmsInterna, decimal? aliquotaIcmsDiferenca)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            IdPais = idPais;
            Sigla = sigla;
            CodIBGE = codIBGE;
            AliquotaIcmsInterestadual = aliquotaIcmsInterestadual;
            AliquotaIcmsInterna = aliquotaIcmsInterna;
            AliquotaIcmsDiferenca = aliquotaIcmsDiferenca;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idPais, string nome, string sigla, string? codIBGE, decimal? aliquotaIcmsInterestadual, decimal? aliquotaIcmsInterna, decimal? aliquotaIcmsDiferenca)
        {
            SetNome(nome);
            IdPais = idPais;
            Sigla = sigla;
            CodIBGE = codIBGE;
            AliquotaIcmsInterestadual = aliquotaIcmsInterestadual;
            AliquotaIcmsInterna = aliquotaIcmsInterna;
            AliquotaIcmsDiferenca = aliquotaIcmsDiferenca;
        }
    }
}
