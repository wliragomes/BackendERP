using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasBancarias.Atualizar
{
    public class AtualizarContaBancariaCommandHandler : IRequestHandler<AtualizarContaBancariaCommand, FormularioResponse<AtualizarContaBancariaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarContaBancariaCommand> _validator;
        private const int _indice = 0;

        public AtualizarContaBancariaCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarContaBancariaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarContaBancariaCommand>> Handle(AtualizarContaBancariaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarContaBancariaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var ContaBancariaUpdate = await _unitOfWork.ContaBancariaRepository.ObterPorId(command.Id);
            ContaBancariaUpdate!.Update(
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

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarContaBancariaCommand(
                command.Id,
                command.Descricao,
                command.IdBanco,
                command.Agencia,
                command.DigitoAgencia,
                command.Conta,
                command.DigitoConta,
                command.LimiteEspecial,
                command.ValorLimiteEspecial,
                command.ContaGarantida,
                command.ValorContaGarantida);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
