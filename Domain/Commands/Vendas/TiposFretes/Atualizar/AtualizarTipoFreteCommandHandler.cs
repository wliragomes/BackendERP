using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.TipoFretes.Atualizar
{
    public class AtualizarTipoFreteCommandHandler : IRequestHandler<AtualizarTipoFreteCommand, FormularioResponse<AtualizarTipoFreteCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarTipoFreteCommand> _validator;
        private const int _indice = 0;

        public AtualizarTipoFreteCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarTipoFreteCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarTipoFreteCommand>> Handle(AtualizarTipoFreteCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarTipoFreteCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var TipoFreteUpdate = await _unitOfWork.TipoFreteRepository.ObterPorId(command.Id);
            TipoFreteUpdate!.Update(command.NFrete, command.Descricao, command.DescricaoResumida);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarTipoFreteCommand(
                command.Id,
                command.NFrete,
                command.Descricao,
                command.DescricaoResumida);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
