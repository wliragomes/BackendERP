using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Estados.Adicionar
{
    public class AdicionarEstadoCommandHandler : IRequestHandler<AdicionarEstadoCommand, FormularioResponse<AdicionarEstadoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarEstadoCommand> _validator;
        private const int _indece = 0;

        public AdicionarEstadoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarEstadoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarEstadoCommand>> Handle(AdicionarEstadoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarEstadoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Estado Estado = new
                (
                    command.IdPais,
                    command.Nome,
                    command.Sigla,
                    command.CodIBGE,
                    command.AliquotaIcmsInterestadual,
                    command.AliquotaIcmsInterna,
                    command.AliquotaIcmsDiferenca
                );

            await _unitOfWork.EstadoRepository.Adicionar(Estado);
            response.Formulario!.SetId(Estado.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }
    }
}
