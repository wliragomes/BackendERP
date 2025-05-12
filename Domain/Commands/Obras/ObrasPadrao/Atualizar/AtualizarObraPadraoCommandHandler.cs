using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObrasPadrao.Atualizar
{
    public class AtualizarObraPadraoCommandHandler : IRequestHandler<AtualizarObraPadraoCommand, FormularioResponse<AtualizarObraPadraoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarObraPadraoCommand> _validator;
        private const int _indice = 0;

        public AtualizarObraPadraoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarObraPadraoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarObraPadraoCommand>> Handle(AtualizarObraPadraoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarObraPadraoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var ObraPadraoUpdate = await _unitOfWork.ObraPadraoRepository.ObterPorId(command.Id);
            ObraPadraoUpdate!.Update(command.Nome);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarObraPadraoCommand(
                command.Id,
                command.Nome);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
