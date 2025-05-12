using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Departamentos.Atualizar
{
    public class AtualizarDepartamentoCommandHandler : IRequestHandler<AtualizarDepartamentoCommand, FormularioResponse<AtualizarDepartamentoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarDepartamentoCommand> _validator;
        private const int _indice = 0;

        public AtualizarDepartamentoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarDepartamentoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarDepartamentoCommand>> Handle(AtualizarDepartamentoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarDepartamentoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var DepartamentoUpdate = await _unitOfWork.DepartamentoRepository.ObterPorId(command.Id);
            DepartamentoUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarDepartamentoCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
