using Domain.Entities.Contatos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cargos.Adicionar
{
    public class AdicionarCargoCommandHandler : IRequestHandler<AdicionarCargoCommand, FormularioResponse<AdicionarCargoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarCargoCommand> _validator;
        private const int _indece = 0;

        public AdicionarCargoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarCargoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarCargoCommand>> Handle(AdicionarCargoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarCargoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Cargo cargo = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.CargoRepository.Adicionar(cargo);
                response.Formulario!.SetId(cargo.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
