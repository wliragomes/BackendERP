using SharedKernel.SharedObjects;

namespace Domain.Entities.Usuarios
{
    public class RelacionaUsuarioFuncionalidadeNivelAcesso : Entity
    {
        public Guid IdUsuario { get; private set; }
        public Users? Usuario { get; private set; }
        public Guid IdFuncionalidade { get; private set; }
        public Funcionalidade? Funcionalidade { get; private set; }
        public Guid IdNivelAcesso { get; private set; }
        public NivelAcesso? NivelAcesso { get; private set; }

        public RelacionaUsuarioFuncionalidadeNivelAcesso() { }

        public RelacionaUsuarioFuncionalidadeNivelAcesso(Guid idUsuario, Guid idFuncionalidade, Guid idNivelAcesso)
        {
            IdUsuario = idUsuario;
            IdFuncionalidade = idFuncionalidade;
            IdNivelAcesso = idNivelAcesso;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idUsuario, Guid idFuncionalidade, Guid idNivelAcesso)
        {
            IdUsuario = idUsuario;
            IdFuncionalidade = idFuncionalidade;
            IdNivelAcesso = idNivelAcesso;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
