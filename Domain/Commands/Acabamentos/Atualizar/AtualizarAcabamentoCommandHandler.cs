using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Acabamentos.Atualizar
{
    public class AtualizarAcabamentoCommandHandler : IRequestHandler<AtualizarAcabamentoCommand, FormularioResponse<AtualizarAcabamentoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarAcabamentoCommand> _validator;
        private const int _indice = 0;

        public AtualizarAcabamentoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarAcabamentoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarAcabamentoCommand>> Handle(AtualizarAcabamentoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarAcabamentoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var AcabamentoUpdate = await _unitOfWork.AcabamentoRepository.ObterPorId(command.Id);
            AcabamentoUpdate!.Update(command.Descricao, command.Tolerancia);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarAcabamentoCommand(
                command.Id,
                command.Descricao,
                command.Tolerancia);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
