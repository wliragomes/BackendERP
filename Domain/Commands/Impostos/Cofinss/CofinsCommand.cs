using SharedKernel.MediatR;

namespace Domain.Commands.Impostos.Cofinss
{
    public abstract class CofinsCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string CofinsAmigavel { get; set; }
        public string Nome { get; set; }
        public bool DescontaCofins { get; set; }

        public CofinsCommand()
        {

        }

        public CofinsCommand(Guid id, string nome, string cofinsAmigavel, bool descontaCofins)
        {
            Id = id;
            Nome = nome;
            CofinsAmigavel = cofinsAmigavel;
            DescontaCofins = descontaCofins;

        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
