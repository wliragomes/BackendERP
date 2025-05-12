using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Adicionar
{
    public class AdicionarIcstIcmsOrigemMaterialCommandHandler : IRequestHandler<AdicionarIcstIcmsOrigemMaterialCommand, FormularioResponse<AdicionarIcstIcmsOrigemMaterialCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarIcstIcmsOrigemMaterialCommand> _validator;
        private const int _indece = 0;

        public AdicionarIcstIcmsOrigemMaterialCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarIcstIcmsOrigemMaterialCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarIcstIcmsOrigemMaterialCommand>> Handle(AdicionarIcstIcmsOrigemMaterialCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarIcstIcmsOrigemMaterialCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            CstIcmsOrigemMaterial cst_icms_origem_material = new
            (
                command.Nome,
                command.CST_ICMS_Amigavel_Origem_Material
            );
            {

                await _unitOfWork.CST_ICMS_Origem_MaterialRepository.Adicionar(cst_icms_origem_material);
                response.Formulario!.SetId(cst_icms_origem_material.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}