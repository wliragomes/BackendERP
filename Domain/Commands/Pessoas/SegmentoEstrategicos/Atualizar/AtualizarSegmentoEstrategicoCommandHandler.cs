using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.SegmentoEstrategicos.Atualizar
{
    public class AtualizarSegmentoEstrategicoCommandHandler : IRequestHandler<AtualizarSegmentoEstrategicoCommand, FormularioResponse<AtualizarSegmentoEstrategicoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarSegmentoEstrategicoCommand> _validator;
        private const int _indice = 0;

        public AtualizarSegmentoEstrategicoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarSegmentoEstrategicoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarSegmentoEstrategicoCommand>> Handle(AtualizarSegmentoEstrategicoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarSegmentoEstrategicoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var SegmentoEstrategicoUpdate = await _unitOfWork.SegmentoEstrategicoRepository.ObterPorId(command.Id);
            SegmentoEstrategicoUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarSegmentoEstrategicoCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
