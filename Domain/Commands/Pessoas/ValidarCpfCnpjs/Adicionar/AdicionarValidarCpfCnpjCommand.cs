using Domain.Commands.Pessoas.ValidarCpfCnpjs;

namespace Domain.Commands.ValidarCpfCnpjs.Adicionar
{
    public class AdicionarValidarCpfCnpjCommand : ValidarCpfCnpjCommand<AdicionarValidarCpfCnpjCommand>
    {
        public AdicionarValidarCpfCnpjCommand()
        {

        }

        public AdicionarValidarCpfCnpjCommand(string cpfCnpj)
            : base(cpfCnpj)
        {
        }
    }
}