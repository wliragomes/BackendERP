using SharedKernel.MediatR;

namespace Domain.Commands.Funcionalidades
{
    public abstract class FuncionalidadeCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }

        public string Codigo { get; set; }
        public string Nome { get; set; }
        public List<Guid> IdNivelAcesso { get; set; }

        public FuncionalidadeCommand()
        {

        }

        public FuncionalidadeCommand(Guid id, string? codigo, string nome, List<Guid> nivelAcesso)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
            IdNivelAcesso = nivelAcesso;


        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}