using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Pais : EntityIdNome
    {
        public Guid? IdFusoHorario { get; private set; }
        public Guid? IdDdi { get; private set; }
        public Guid? IdMoedaPrincipal { get; private set; }
        public ICollection<Estado>? Estados { get; private set; }

        public Pais(string nome, Guid? idFusoHorario, Guid? idDdi, Guid? idMoedaPrincipal)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            IdFusoHorario = idFusoHorario;
            IdDdi = idDdi;
            IdMoedaPrincipal = idMoedaPrincipal;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, Guid? idFusoHorario, Guid? idDdi, Guid? idMoedaPrincipal)
        {
            SetNome(nome);
            IdFusoHorario = idFusoHorario;
            IdDdi = idDdi;
            IdMoedaPrincipal = idMoedaPrincipal;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
