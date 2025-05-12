using SharedKernel.SharedObjects;

namespace Domain.Entities.Usuarios
{
    public class RelacionaFuncionalidadeNivelAcesso : Entity
    {
        public Guid IdFuncionalidade { get; private set; }
        public Funcionalidade? Funcionalidade { get; private set; }
        public Guid IdNivelAcesso { get; private set; }
        public NivelAcesso? NivelAcesso { get; private set; }

        public RelacionaFuncionalidadeNivelAcesso() { }

        public RelacionaFuncionalidadeNivelAcesso(Guid idFuncionalidade, Guid idNivelAcesso)
        {
            IdFuncionalidade = idFuncionalidade;
            IdNivelAcesso = idNivelAcesso;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idFuncionalidade, Guid idNivelAcesso)
        {
            IdFuncionalidade = idFuncionalidade;
            IdNivelAcesso = idNivelAcesso;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
