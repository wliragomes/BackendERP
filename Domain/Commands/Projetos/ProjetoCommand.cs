using SharedKernel.MediatR;

namespace Domain.Commands.Projetos
{
    public abstract class ProjetoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Apitar { get; set; }
        public bool Tarja { get; set; }
        public bool Agrupar { get; set; }
        public bool FProjeto { get; set; }

        public ProjetoCommand()
        {

        }

        public ProjetoCommand(Guid id, string nome, bool apitar, bool tarja, bool agrupar, bool fProjeto)
        {
            Id = id;
            Nome = nome;
            Apitar = apitar;
            Tarja = tarja;
            Agrupar = agrupar;
            FProjeto = fProjeto;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}