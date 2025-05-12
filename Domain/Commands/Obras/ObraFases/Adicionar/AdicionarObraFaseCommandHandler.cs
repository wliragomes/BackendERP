using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObraFases.Adicionar
{
    public class AdicionarObraFaseCommandHandler : IRequestHandler<AdicionarObraFaseCommand, FormularioResponse<AdicionarObraFaseCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarObraFaseCommand> _validator;
        private const int _indece = 0;

        public AdicionarObraFaseCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarObraFaseCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarObraFaseCommand>> Handle(AdicionarObraFaseCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarObraFaseCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            ObraFase obraFase = new (command.Nome);
            {
                await _unitOfWork.ObraFaseRepository.Adicionar(obraFase);
                response.Formulario!.SetId(obraFase.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
