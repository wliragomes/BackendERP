using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cidades.Atualizar
{
    public class AtualizarCidadeCommandHandler : IRequestHandler<AtualizarCidadeCommand, FormularioResponse<AtualizarCidadeCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarCidadeCommand> _validator;
        private const int _indice = 0;

        public AtualizarCidadeCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarCidadeCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarCidadeCommand>> Handle(AtualizarCidadeCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarCidadeCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var CidadeUpdate = await _unitOfWork.CidadeRepository.ObterPorId(command.Id);
            CidadeUpdate!.Update(command.IdEstado, command.Nome, command.PrISS, command.ValorMultiplicador, command.CodIBGE);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarCidadeCommand(
                CidadeUpdate.Id,
                command.IdEstado,
                command.Nome,
                command.PrISS,
                command.ValorMultiplicador,
                command.CodIBGE);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
