using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.FusoHorarios.Adicionar
{
    public class AdicionarFusoHorarioCommandHandler : IRequestHandler<AdicionarFusoHorarioCommand, FormularioResponse<AdicionarFusoHorarioCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarFusoHorarioCommand> _validator;
        private const int _indece = 0;

        public AdicionarFusoHorarioCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarFusoHorarioCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarFusoHorarioCommand>> Handle(AdicionarFusoHorarioCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarFusoHorarioCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            FusoHorario fusoHorario = new
            (
                command.NumeroFusoHorario
            );
            {

                await _unitOfWork.FusoHorarioRepository.Adicionar(fusoHorario);
                response.Formulario!.SetId(fusoHorario.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
