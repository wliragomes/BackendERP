using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Moedas.Atualizar
{
    public class AtualizarMoedaCommandHandler : IRequestHandler<AtualizarMoedaCommand, FormularioResponse<AtualizarMoedaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarMoedaCommand> _validator;
        private const int _indice = 0;

        public AtualizarMoedaCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarMoedaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarMoedaCommand>> Handle(AtualizarMoedaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarMoedaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var MoedaUpdate = await _unitOfWork.MoedaRepository.ObterPorId(command.Id);
            MoedaUpdate!.Update(command.Nome, command.Negociavel);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarMoedaCommand(
                command.Id,
                command.Nome,
                command.Negociavel);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
