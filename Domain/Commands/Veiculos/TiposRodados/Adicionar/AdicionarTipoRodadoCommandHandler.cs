using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.TiposRodados.Adicionar
{
    public class AdicionarTipoRodadoCommandHandler : IRequestHandler<AdicionarTipoRodadoCommand, FormularioResponse<AdicionarTipoRodadoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarTipoRodadoCommand> _validator;
        private const int _indece = 0;

        public AdicionarTipoRodadoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarTipoRodadoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarTipoRodadoCommand>> Handle(AdicionarTipoRodadoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarTipoRodadoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            TipoRodado tipoCarroceria = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.TipoRodadoRepository.Adicionar(tipoCarroceria);
                response.Formulario!.SetId(tipoCarroceria.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
