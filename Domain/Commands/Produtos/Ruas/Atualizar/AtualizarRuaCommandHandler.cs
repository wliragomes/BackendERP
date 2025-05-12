using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Ruas.Atualizar
{
    public class AtualizarRuaCommandHandler : IRequestHandler<AtualizarRuaCommand, FormularioResponse<AtualizarRuaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarRuaCommand> _validator;
        private const int _indice = 0;

        public AtualizarRuaCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarRuaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarRuaCommand>> Handle(AtualizarRuaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarRuaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var RuaUpdate = await _unitOfWork.RuaRepository.ObterPorId(command.Id);
            RuaUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarRuaCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
