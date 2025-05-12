using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.OrigemMateriais.Adicionar
{
    public class AdicionarOrigemMaterialCommandHandler : IRequestHandler<AdicionarOrigemMaterialCommand, FormularioResponse<AdicionarOrigemMaterialCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarOrigemMaterialCommand> _validator;
        private const int _indece = 0;

        public AdicionarOrigemMaterialCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarOrigemMaterialCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarOrigemMaterialCommand>> Handle(AdicionarOrigemMaterialCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarOrigemMaterialCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            OrigemMaterial origemmaterial = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.OrigemMaterialRepository.Adicionar(origemmaterial);
                response.Formulario!.SetId(origemmaterial.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
