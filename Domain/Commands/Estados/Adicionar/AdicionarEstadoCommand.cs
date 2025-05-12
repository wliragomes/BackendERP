namespace Domain.Commands.Estados.Adicionar
{
    public class AdicionarEstadoCommand : EstadoCommand<AdicionarEstadoCommand>
    {
        public AdicionarEstadoCommand()
        {

        }

        public AdicionarEstadoCommand(Guid? id, Guid idPais, string? nome, string? sigla, string? codIBGE, decimal? aliquotaIcmsInterestadual, decimal? aliquotaIcmsInterna, decimal? aliquotaIcmsDiferenca)
            : base(id, idPais, nome, sigla, codIBGE, aliquotaIcmsInterestadual, aliquotaIcmsInterna, aliquotaIcmsDiferenca)
        {
        }
    }
}
