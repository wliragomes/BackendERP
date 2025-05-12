using SharedKernel.SharedObjects;

namespace Domain.Entities.Empresas
{
    public class RelacionaEmpresaFaturaParametro : Entity
    {
        public Guid IdEmpresa { get; private set; }
        public Empresa? Empresa { get; private set; }
        public Guid IdFaturaParametro { get; private set; }
        public FaturaParametro? FaturaParametro { get; private set; }

        public RelacionaEmpresaFaturaParametro() { }

        public RelacionaEmpresaFaturaParametro(Guid idEmpresa, Guid idFaturaParametro)
        {
            IdEmpresa = idEmpresa;
            IdFaturaParametro = idFaturaParametro;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idEmpresa, Guid idFaturaParametro)
        {
            IdEmpresa = idEmpresa;
            IdFaturaParametro = idFaturaParametro;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
