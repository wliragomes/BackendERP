using SharedKernel.MediatR;

namespace Domain.Commands.NiveisAcessos
{
    public abstract class NivelAcessoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }

        public string Codigo { get; set; }
        public string Nome { get; set; }

        public NivelAcessoCommand()
        {

        }

        public NivelAcessoCommand(Guid id, string? codigo, string nome)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
            ;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}