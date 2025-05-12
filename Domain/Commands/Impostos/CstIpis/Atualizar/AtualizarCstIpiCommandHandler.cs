using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.CstIpis.Atualizar
{
    public class AtualizarCstIpiCommandHandler : IRequestHandler<AtualizarCstIpiCommand, FormularioResponse<AtualizarCstIpiCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarCstIpiCommand> _validator;
        private const int _indice = 0;

        public AtualizarCstIpiCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarCstIpiCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarCstIpiCommand>> Handle(AtualizarCstIpiCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarCstIpiCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var CST_IPIUpdate = await _unitOfWork.CST_IPIRepository.ObterPorId(command.Id);
            CST_IPIUpdate!.Update(command.Nome, command.CstIpiAmigavel, command.CobraIpi, command.EntradaSaida);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarCstIpiCommand(
                command.Id,
                command.Nome,
                command.CstIpiAmigavel,
                command.CobraIpi,
                command.EntradaSaida);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
