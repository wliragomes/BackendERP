namespace Domain.Commands.Estados.Atualizar
{
    public class AtualizarEstadoCommand : EstadoCommand<AtualizarEstadoCommand>
    {
        public AtualizarEstadoCommand(Guid? id, Guid idEstado, string? nome, string? sigla, string? codIBGE, decimal? aliquotaIcmsInterestadual, decimal? aliquotaIcmsInterna, decimal? aliquotaIcmsDiferenca)
            : base(id, idEstado, nome, sigla, codIBGE, aliquotaIcmsInterestadual, aliquotaIcmsInterna, aliquotaIcmsDiferenca)
        {
        }

        public AtualizarEstadoCommand()
        {

        }
    }
}