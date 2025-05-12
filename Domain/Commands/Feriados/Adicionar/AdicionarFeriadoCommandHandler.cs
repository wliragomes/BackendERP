using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Feriados.Adicionar
{
    public class AdicionarFeriadoCommandHandler : IRequestHandler<AdicionarFeriadoCommand, FormularioResponse<AdicionarFeriadoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarFeriadoCommand> _validator;
        private const int _indece = 0;

        public AdicionarFeriadoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarFeriadoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarFeriadoCommand>> Handle(AdicionarFeriadoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarFeriadoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Feriado feriado = new
            (
                command.Nome,
                command.Data
            );
            {

                await _unitOfWork.FeriadoRepository.Adicionar(feriado);
                response.Formulario!.SetId(feriado.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
