using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.CodigoDDIs.Adicionar
{
    public class AdicionarCodigoDDICommandHandler : IRequestHandler<AdicionarCodigoDDICommand, FormularioResponse<AdicionarCodigoDDICommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarCodigoDDICommand> _validator;
        private const int _indece = 0;

        public AdicionarCodigoDDICommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarCodigoDDICommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarCodigoDDICommand>> Handle(AdicionarCodigoDDICommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarCodigoDDICommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            CodigoDDI codigoDDI = new
            (
                command.Codigo
            );
            {

                await _unitOfWork.CodigoDDIRepository.Adicionar(codigoDDI);
                response.Formulario!.SetId(codigoDDI.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
