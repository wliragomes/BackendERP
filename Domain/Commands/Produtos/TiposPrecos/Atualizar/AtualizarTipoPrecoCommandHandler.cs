using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.TiposPrecos.Atualizar
{
    public class AtualizarTipoPrecoCommandHandler : IRequestHandler<AtualizarTipoPrecoCommand, FormularioResponse<AtualizarTipoPrecoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarTipoPrecoCommand> _validator;
        private const int _indice = 0;

        public AtualizarTipoPrecoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarTipoPrecoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarTipoPrecoCommand>> Handle(AtualizarTipoPrecoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarTipoPrecoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var tipoprecoUpdate = await _unitOfWork.TipoPrecoRepository.ObterPorId(command.Id);
            tipoprecoUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarTipoPrecoCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
