using SharedKernel.MediatR;

namespace Domain.Commands.Paises
{
    public abstract class PaisCommand<T> : CommandBase<T>
    {
        public Guid? Id { get; protected set; }
        public string? Nome { get; protected set; }
        public Guid? IdFusoHorario { get; set; }
        public Guid? IdDdi { get; set; }
        public Guid? IdMoedaPrincipal { get; set; }

        public PaisCommand()
        {

        }

        public PaisCommand(Guid? id, string? nome, Guid? idFusoHorario, Guid? idDdi, Guid? idMoedaPrincipal)
        {
            Id = id;
            Nome = nome;
            IdFusoHorario = idFusoHorario;
            IdDdi = idDdi;
            IdMoedaPrincipal = idMoedaPrincipal;
        }

        public void SetId(Guid? id)
        {
            Id = id;
        }
    }
}