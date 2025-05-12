using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MotivoReposições.Atualizar
{
    public class AtualizarMotivoReposicaoCommandHandler : IRequestHandler<AtualizarMotivoReposicaoCommand, FormularioResponse<AtualizarMotivoReposicaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarMotivoReposicaoCommand> _validator;
        private const int _indice = 0;

        public AtualizarMotivoReposicaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarMotivoReposicaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarMotivoReposicaoCommand>> Handle(AtualizarMotivoReposicaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarMotivoReposicaoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var MotivoReposicaoUpdate = await _unitOfWork.MotivoReposicaoRepository.ObterPorId(command.Id);
            MotivoReposicaoUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarMotivoReposicaoCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
