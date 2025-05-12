using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.CepsBloqueados.Atualizar
{
    public class AtualizarCepBloqueadoCommandHandler : IRequestHandler<AtualizarCepBloqueadoCommand, FormularioResponse<AtualizarCepBloqueadoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarCepBloqueadoCommand> _validator;
        private const int _indice = 0;

        public AtualizarCepBloqueadoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarCepBloqueadoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarCepBloqueadoCommand>> Handle(AtualizarCepBloqueadoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarCepBloqueadoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var CepBloqueadoUpdate = await _unitOfWork.CepBloqueadoRepository.ObterPorId(command.Id);
            CepBloqueadoUpdate!.Update(command.NumeroCep, command.Descricao, command.NumeroDe, command.NumeroAte, command.Par, command.Impar);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarCepBloqueadoCommand(
                command.Id,
                command.NumeroCep,
                command.Descricao, 
                command.NumeroDe, 
                command.NumeroAte, 
                command.Par, 
                command.Impar);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
