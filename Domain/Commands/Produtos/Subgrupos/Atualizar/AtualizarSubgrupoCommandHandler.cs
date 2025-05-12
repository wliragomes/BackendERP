using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Subgrupos.Atualizar
{
    public class AtualizarSubgrupoCommandHandler : IRequestHandler<AtualizarSubgrupoCommand, FormularioResponse<AtualizarSubgrupoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarSubgrupoCommand> _validator;
        private const int _indice = 0;

        public AtualizarSubgrupoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarSubgrupoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarSubgrupoCommand>> Handle(AtualizarSubgrupoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarSubgrupoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var SubgrupoUpdate = await _unitOfWork.SubgrupoRepository.ObterPorId(command.Id);
            SubgrupoUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarSubgrupoCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
