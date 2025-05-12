using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Empresas
{
    public class RelacionaEmpresaSocio : Entity
    {
        public Guid IdEmpresa { get; private set; }
        public Empresa? Empresa { get; private set; }
        public Guid IdSocio { get; private set; }
        public Pessoa? Pessoa { get; private set; }

        public RelacionaEmpresaSocio() { }

        public RelacionaEmpresaSocio(Guid idEmpresa, Guid idSocio)
        {
            IdEmpresa = idEmpresa;
            IdSocio = idSocio;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idEmpresa, Guid idSocio)
        {
            IdEmpresa = idEmpresa;
            IdSocio = idSocio;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
