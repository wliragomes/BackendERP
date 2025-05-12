using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Atualizar
{
    public class AtualizarIcstIcmsOrigemMaterialCommandHandler : IRequestHandler<AtualizarIcstIcmsOrigemMaterialCommand, FormularioResponse<AtualizarIcstIcmsOrigemMaterialCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarIcstIcmsOrigemMaterialCommand> _validator;
        private const int _indice = 0;

        public AtualizarIcstIcmsOrigemMaterialCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarIcstIcmsOrigemMaterialCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarIcstIcmsOrigemMaterialCommand>> Handle(AtualizarIcstIcmsOrigemMaterialCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarIcstIcmsOrigemMaterialCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var CST_ICMS_Origem_MaterialUpdate = await _unitOfWork.CST_ICMS_Origem_MaterialRepository.ObterPorId(command.Id);
            CST_ICMS_Origem_MaterialUpdate!.Update(command.Nome, command.CST_ICMS_Amigavel_Origem_Material);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarIcstIcmsOrigemMaterialCommand(
                command.Id,
                command.Nome,
                command.CST_ICMS_Amigavel_Origem_Material);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
