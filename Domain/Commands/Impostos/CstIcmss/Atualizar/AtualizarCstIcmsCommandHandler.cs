using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.CstIcmss.Atualizar
{
    public class AtualizarCST_ICMSCommandHandler : IRequestHandler<AtualizarCST_ICMSCommand, FormularioResponse<AtualizarCST_ICMSCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarCST_ICMSCommand> _validator;
        private const int _indice = 0;

        public AtualizarCST_ICMSCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarCST_ICMSCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarCST_ICMSCommand>> Handle(AtualizarCST_ICMSCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarCST_ICMSCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var CST_ICMSUpdate = await _unitOfWork.CST_ICMSRepository.ObterPorId(command.Id);
            CST_ICMSUpdate!.Update(command.Nome, command.CstIcmsAmigavel, command.DescontaIcms);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarCST_ICMSCommand(
                command.Id,
                command.Nome,
                command.CstIcmsAmigavel,
                command.DescontaIcms);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
