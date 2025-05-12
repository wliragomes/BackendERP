using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Moedas.Adicionar
{
    public class AdicionarMoedaCommandHandler : IRequestHandler<AdicionarMoedaCommand, FormularioResponse<AdicionarMoedaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarMoedaCommand> _validator;
        private const int _indece = 0;

        public AdicionarMoedaCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarMoedaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarMoedaCommand>> Handle(AdicionarMoedaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarMoedaCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Moeda moeda = new
            (
                command.Nome,
                command.Negociavel
            );
            {

                await _unitOfWork.MoedaRepository.Adicionar(moeda);
                response.Formulario!.SetId(moeda.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
