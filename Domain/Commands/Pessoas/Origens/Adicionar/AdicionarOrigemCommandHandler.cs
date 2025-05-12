using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Origens.Adicionar
{
    public class AdicionarOrigemCommandHandler : IRequestHandler<AdicionarOrigemCommand, FormularioResponse<AdicionarOrigemCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarOrigemCommand> _validator;
        private const int _indece = 0;

        public AdicionarOrigemCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarOrigemCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarOrigemCommand>> Handle(AdicionarOrigemCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarOrigemCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Origem origem = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.OrigemRepository.Adicionar(origem);
                response.Formulario!.SetId(origem.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
