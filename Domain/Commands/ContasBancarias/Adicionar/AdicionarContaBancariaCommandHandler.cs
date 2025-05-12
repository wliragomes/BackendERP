using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasBancarias.Adicionar
{
    public class AdicionarContaBancariaCommandHandler : IRequestHandler<AdicionarContaBancariaCommand, FormularioResponse<AdicionarContaBancariaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarContaBancariaCommand> _validator;
        private const int _indece = 0;

        public AdicionarContaBancariaCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarContaBancariaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarContaBancariaCommand>> Handle(AdicionarContaBancariaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarContaBancariaCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            ContaBancaria contaBancaria = new
            (
                command.Descricao,
                command.IdBanco,
                command.Agencia,
                command.DigitoAgencia,
                command.Conta,
                command.DigitoConta,
                command.LimiteEspecial,
                command.ValorLimiteEspecial,
                command.ContaGarantida,
                command.ValorContaGarantida
            );
            {

                await _unitOfWork.ContaBancariaRepository.Adicionar(contaBancaria);
                response.Formulario!.SetId(contaBancaria.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
