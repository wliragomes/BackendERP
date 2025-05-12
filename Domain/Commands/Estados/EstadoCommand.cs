using SharedKernel.MediatR;

namespace Domain.Commands.Estados
{
    public abstract class EstadoCommand<T> : CommandBase<T>
    {
        public Guid? Id { get; protected set; }
        public Guid IdPais { get; set; }
        public string Nome { get; protected set; }
        public string Sigla { get; protected set; }
        public string? CodIBGE { get; private set; }
        public decimal? AliquotaIcmsInterestadual { get; private set; }
        public decimal? AliquotaIcmsInterna { get; private set; }
        public decimal? AliquotaIcmsDiferenca { get; private set; }

        public EstadoCommand() { }

        public EstadoCommand(Guid? id, Guid idPais, string nome, string sigla, string? codIBGE, decimal? aliquotaIcmsInterestadual, decimal? aliquotaIcmsInterna, decimal? aliquotaIcmsDiferenca)
        {
            Id = id;
            IdPais = idPais;
            Nome = nome;
            Sigla = sigla;
            CodIBGE = codIBGE;
            AliquotaIcmsInterestadual = aliquotaIcmsInterestadual;
            AliquotaIcmsInterna = aliquotaIcmsInterna;
            AliquotaIcmsDiferenca = aliquotaIcmsDiferenca;
        }

        public void SetId(Guid? id)
        {
            Id = id;
        }
    }
}