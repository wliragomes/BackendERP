using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.Cofinss.Adicionar
{
    public class AdicionarCofinsCommandHandler : IRequestHandler<AdicionarCofinsCommand, FormularioResponse<AdicionarCofinsCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarCofinsCommand> _validator;
        private const int _indece = 0;

        public AdicionarCofinsCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarCofinsCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarCofinsCommand>> Handle(AdicionarCofinsCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarCofinsCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Cofins cofins = new
            (
                command.Nome,
                command.CofinsAmigavel,
                command.DescontaCofins
            );
            {
                await _unitOfWork.CofinsRepository.AdicionarCofins(cofins);
                response.Formulario!.SetId(cofins.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
