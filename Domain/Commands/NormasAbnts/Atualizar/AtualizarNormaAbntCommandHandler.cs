using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.NormasAbnts.Atualizar
{
    public class AtualizarNormaAbntCommandHandler : IRequestHandler<AtualizarNormaAbntCommand, FormularioResponse<AtualizarNormaAbntCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarNormaAbntCommand> _validator;
        private const int _indice = 0;

        public AtualizarNormaAbntCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarNormaAbntCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarNormaAbntCommand>> Handle(AtualizarNormaAbntCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarNormaAbntCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var NormaAbntUpdate = await _unitOfWork.NormaAbntRepository.ObterPorId(command.Id);
            NormaAbntUpdate!.Update(command.NNbr!, command.Descricao!, command.Pedido!, command.Validade!, command.Vencida);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarNormaAbntCommand(
                command.Id,  
                command.NNbr!,
                command.Descricao!,
                command.Pedido!,
                command.Validade!,
                command.Vencida
                );

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}