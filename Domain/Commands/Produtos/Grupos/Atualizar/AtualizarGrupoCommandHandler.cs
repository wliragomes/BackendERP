using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Grupos.Atualizar
{
    public class AtualizarGrupoCommandHandler : IRequestHandler<AtualizarGrupoCommand, FormularioResponse<AtualizarGrupoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarGrupoCommand> _validator;
        private const int _indice = 0;

        public AtualizarGrupoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarGrupoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarGrupoCommand>> Handle(AtualizarGrupoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarGrupoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var GrupoUpdate = await _unitOfWork.GrupoRepository.ObterPorId(command.Id);
            GrupoUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarGrupoCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
