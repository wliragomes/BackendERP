using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Prateleiras.Adicionar
{
    public class AdicionarPrateleiraCommandHandler : IRequestHandler<AdicionarPrateleiraCommand, FormularioResponse<AdicionarPrateleiraCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarPrateleiraCommand> _validator;
        private const int _indece = 0;

        public AdicionarPrateleiraCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarPrateleiraCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarPrateleiraCommand>> Handle(AdicionarPrateleiraCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarPrateleiraCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Prateleira prateleira = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.PrateleiraRepository.Adicionar(prateleira);
                response.Formulario!.SetId(prateleira.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
