using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Representantes.Atualizar
{
    public class AtualizarRepresentanteCommandHandler : IRequestHandler<AtualizarRepresentanteCommand, FormularioResponse<AtualizarRepresentanteCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarRepresentanteCommand> _validator;
        private const int _indice = 0;

        public AtualizarRepresentanteCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarRepresentanteCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarRepresentanteCommand>> Handle(AtualizarRepresentanteCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarRepresentanteCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var RepresentanteUpdate = await _unitOfWork.RepresentanteRepository.ObterPorId(command.Id);
            RepresentanteUpdate!.Update(command.IdPessoa, command.Externo, command.Comissao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarRepresentanteCommand(
                command.Id,
                command.IdPessoa,
                command.Externo,
                command.Comissao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
