using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;
using System.Text.RegularExpressions;

namespace Domain.Commands.ValidarCpfCnpjs.Adicionar
{
    public class AdicionarValidarCpfCnpjCommandHandler : IRequestHandler<AdicionarValidarCpfCnpjCommand, FormularioResponse<AdicionarValidarCpfCnpjCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarValidarCpfCnpjCommand> _validator;
        private const int _indece = 0;

        public AdicionarValidarCpfCnpjCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarValidarCpfCnpjCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarValidarCpfCnpjCommand>> Handle(AdicionarValidarCpfCnpjCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarValidarCpfCnpjCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            if (!ValidarCpfCnpj(command.CpfCnpj))
            {
                response.AddError("CpfCnpj", PessoaConstant.CPFCNPJ_INVALIDO, command.CpfCnpj);
            }

            return response;
        }        

        private bool ValidarCpfCnpj(string cpfCnpj) // Validação de Cpf e Cnpj por Caracteres
        {            
            cpfCnpj = Regex.Replace(cpfCnpj, "[^0-9]", "");

            switch(cpfCnpj.Length)
            {
                case 11:
                    return ValidarCpf(cpfCnpj);
                case 14:
                    return ValidarCnpj(cpfCnpj);
            }

            return false;
        }

        private bool ValidarCpf(string cpf)     // Verificar se o Cpf é valido atraves dos digitos
        {            
            if (cpf.Length != 11)
                return false;
            
            int[] pesos1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * pesos1[i];
            }
            int digito1 = (soma * 10) % 11;
            if (digito1 == 10) digito1 = 0;

            
            int[] pesos2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * pesos2[i];
            }
            int digito2 = (soma * 10) % 11;
            if (digito2 == 10) digito2 = 0;

            
            return cpf[9].ToString() == digito1.ToString() && cpf[10].ToString() == digito2.ToString();
        }

        private bool ValidarCnpj(string cnpj)
        {
            if (cnpj.Length != 14)
                return false;
                        
            int[] pesos1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(cnpj[i].ToString()) * pesos1[i];
            }
            int digito1 = 0;
            int resto = soma % 11;
            if (resto < 2)
                digito1 = 0;
            else
                digito1 = 11 - resto;
            
            int[] pesos2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(cnpj[i].ToString()) * pesos2[i];
            }
            int digito2 = 0;
            resto = soma % 11;
            if (resto < 2)
                digito2 = 0;
            else
                digito2 = 11 - resto;
            
            return cnpj[12].ToString() == digito1.ToString() && cnpj[13].ToString() == digito2.ToString();
        }
    }
}