using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.SegmentoClientes.Atualizar
{
    public class AtualizarSegmentoClienteCommandHandler : IRequestHandler<AtualizarSegmentoClienteCommand, FormularioResponse<AtualizarSegmentoClienteCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarSegmentoClienteCommand> _validator;
        private const int _indice = 0;

        public AtualizarSegmentoClienteCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarSegmentoClienteCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarSegmentoClienteCommand>> Handle(AtualizarSegmentoClienteCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarSegmentoClienteCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var SegmentoClienteUpdate = await _unitOfWork.SegmentoClienteRepository.ObterPorId(command.Id);
            SegmentoClienteUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarSegmentoClienteCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
