using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.TiposCarrocerias.Adicionar
{
    public class AdicionarTipoCarroceriaCommandHandler : IRequestHandler<AdicionarTipoCarroceriaCommand, FormularioResponse<AdicionarTipoCarroceriaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarTipoCarroceriaCommand> _validator;
        private const int _indece = 0;

        public AdicionarTipoCarroceriaCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarTipoCarroceriaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarTipoCarroceriaCommand>> Handle(AdicionarTipoCarroceriaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarTipoCarroceriaCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            TipoCarroceria tipoCarroceria = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.TipoCarroceriaRepository.Adicionar(tipoCarroceria);
                response.Formulario!.SetId(tipoCarroceria.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
