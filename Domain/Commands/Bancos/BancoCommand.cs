using SharedKernel.MediatR;

namespace Domain.Commands.Bancos
{
    public abstract class BancoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool NaoSomar { get; set; }
        public string NumeroBanco { get; set; }

        public BancoCommand()
        {

        }

        public BancoCommand(Guid id, string? nome, bool naoSomar, string? numeroBanco)
        {
            Id = id;
            Nome = nome;
            NaoSomar = naoSomar;
            NumeroBanco = numeroBanco;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}