using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObraOrigems.Adicionar
{
    public class AdicionarObraOrigemCommandHandler : IRequestHandler<AdicionarObraOrigemCommand, FormularioResponse<AdicionarObraOrigemCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarObraOrigemCommand> _validator;
        private const int _indece = 0;

        public AdicionarObraOrigemCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarObraOrigemCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarObraOrigemCommand>> Handle(AdicionarObraOrigemCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarObraOrigemCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            ObraOrigem obraOrigem = new(command.Nome);
            {
                await _unitOfWork.ObraOrigemRepository.Adicionar(obraOrigem);
                response.Formulario!.SetId(obraOrigem.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
