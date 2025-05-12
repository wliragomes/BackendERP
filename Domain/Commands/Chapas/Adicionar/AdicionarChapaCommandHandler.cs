using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Chapas.Adicionar
{
    public class AdicionarChapaCommandHandler : IRequestHandler<AdicionarChapaCommand, FormularioResponse<AdicionarChapaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarChapaCommand> _validator;
        private const int _indece = 0;

        public AdicionarChapaCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarChapaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarChapaCommand>> Handle(AdicionarChapaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarChapaCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Chapa chapa = new
            (
                command.Descricao,
                command.Altura,
                command.Largura
            );
            {

                await _unitOfWork.ChapaRepository.Adicionar(chapa);
                response.Formulario!.SetId(chapa.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
