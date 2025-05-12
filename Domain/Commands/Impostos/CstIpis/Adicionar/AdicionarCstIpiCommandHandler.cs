using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.CstIpis.Adicionar
{
    public class AdicionarCstIpiCommandHandler : IRequestHandler<AdicionarCstIpiCommand, FormularioResponse<AdicionarCstIpiCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarCstIpiCommand> _validator;
        private const int _indece = 0;

        public AdicionarCstIpiCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarCstIpiCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarCstIpiCommand>> Handle(AdicionarCstIpiCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarCstIpiCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            CstIpi cst_ipi = new
            (
                command.Nome,
                command.CstIpiAmigavel,
                command.CobraIpi,
                command.EntradaSaida
            );
            {

                await _unitOfWork.CST_IPIRepository.Adicionar(cst_ipi);
                response.Formulario!.SetId(cst_ipi.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
