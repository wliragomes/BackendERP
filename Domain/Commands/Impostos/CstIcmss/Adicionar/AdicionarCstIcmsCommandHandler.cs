using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.CstIcmss.Adicionar
{
    public class AdicionarCstIcmsCommandHandler : IRequestHandler<AdicionarCstIcmsCommand, FormularioResponse<AdicionarCstIcmsCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarCstIcmsCommand> _validator;
        private const int _indece = 0;

        public AdicionarCstIcmsCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarCstIcmsCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarCstIcmsCommand>> Handle(AdicionarCstIcmsCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarCstIcmsCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            CST_ICMS cst_icms = new
            (
                command.Nome,
                command.CstIcmsAmigavel,
                command.DescontaIcms
            );
            {
                await _unitOfWork.CST_ICMSRepository.Adicionar(cst_icms);
                response.Formulario!.SetId(cst_icms.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
