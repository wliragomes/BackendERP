using SharedKernel.SharedObjects;

namespace Domain.Entities.Usuarios
{
    public class NivelAcesso : EntityIdNome
    {
        public string Codigo { get; private set; }

        public ICollection<RelacionaUsuarioFuncionalidadeNivelAcesso>? RelacionaUsuarioFuncionalidadeNivelAcesso { get; private set; }
        public ICollection<RelacionaFuncionalidadeNivelAcesso>? RelacionaFuncionalidadeNivelAcesso { get; private set; }

        public NivelAcesso(string codigo, string nome)
        {
            SetId(Guid.NewGuid());
            Codigo = codigo;
            SetNome(nome);

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string codigo, string nome)
        {
            Codigo = codigo;
            SetNome(nome);

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
