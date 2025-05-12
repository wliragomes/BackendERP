using SharedKernel.MediatR;

namespace Domain.Commands.Pessoas.ValidarCpfCnpjs
{
    public abstract class ValidarCpfCnpjCommand<T> : CommandBase<T>
    {
        public string CpfCnpj { get; set; }

        public ValidarCpfCnpjCommand() { }

        public ValidarCpfCnpjCommand(string cpfCnpj) 
        {
            CpfCnpj = cpfCnpj;
        }

    }
}


