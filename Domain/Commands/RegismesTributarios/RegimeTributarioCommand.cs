using SharedKernel.MediatR;

namespace Domain.Commands.RegimeTributarios
{
    public abstract class RegimeTributarioCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorPis { get; set; }
        public decimal ValorCofins { get; set; }

        public RegimeTributarioCommand()
        {

        }

        public RegimeTributarioCommand(Guid id, string? nome, decimal valorPis, decimal valorCofins)
        {
            Id = id;
            Nome = nome;
            ValorPis = valorPis;
            ValorCofins = valorCofins;            
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}