using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Representantes.Adicionar
{
    public class AdicionarRepresentanteCommandHandler : IRequestHandler<AdicionarRepresentanteCommand, FormularioResponse<AdicionarRepresentanteCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarRepresentanteCommand> _validator;
        private const int _indece = 0;

        public AdicionarRepresentanteCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarRepresentanteCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarRepresentanteCommand>> Handle(AdicionarRepresentanteCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarRepresentanteCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Representante representante = new
            (
                command.IdPessoa,
                command.Externo,
                command.Comissao
            );
            {

                await _unitOfWork.RepresentanteRepository.Adicionar(representante);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
