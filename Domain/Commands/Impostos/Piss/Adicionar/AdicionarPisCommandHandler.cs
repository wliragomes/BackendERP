using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.Piss.Adicionar
{
    public class AdicionarPisCommandHandler : IRequestHandler<AdicionarPisCommand, FormularioResponse<AdicionarPisCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarPisCommand> _validator;
        private const int _indece = 0;

        public AdicionarPisCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarPisCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarPisCommand>> Handle(AdicionarPisCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarPisCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Pis pis = new
            (
                command.Nome,
                command.PisAmigavel,
                command.DescontaPis
            );
            {
                await _unitOfWork.PisRepository.AdicionarPis(pis);
                response.Formulario!.SetId(pis.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
