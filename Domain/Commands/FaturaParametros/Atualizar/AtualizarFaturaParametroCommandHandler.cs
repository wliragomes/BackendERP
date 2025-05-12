using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.FaturaParametros.Atualizar
{
    public class AtualizarFaturaParametroCommandHandler : IRequestHandler<AtualizarFaturaParametroCommand, FormularioResponse<AtualizarFaturaParametroCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarFaturaParametroCommand> _validator;
        private const int _indice = 0;

        public AtualizarFaturaParametroCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarFaturaParametroCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarFaturaParametroCommand>> Handle(AtualizarFaturaParametroCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarFaturaParametroCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var FaturaParametroUpdate = await _unitOfWork.FaturaParametroRepository.ObterPorId(command.Id);
            FaturaParametroUpdate!.Update(command.Modelo, command.Serie, command.PrimeiroNumero);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarFaturaParametroCommand(
                command.Id,
                command.Modelo,
                command.Serie,
                command.PrimeiroNumero);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
