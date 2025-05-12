using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.DesgastePolimentos.Adicionar
{
    public class AdicionarDesgastePolimentoCommandHandler : IRequestHandler<AdicionarDesgastePolimentoCommand, FormularioResponse<AdicionarDesgastePolimentoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarDesgastePolimentoCommand> _validator;
        private const int _indece = 0;

        public AdicionarDesgastePolimentoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarDesgastePolimentoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarDesgastePolimentoCommand>> Handle(AdicionarDesgastePolimentoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarDesgastePolimentoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            DesgastePolimento desgastePolimento = new(
                command.EspessuraVidroMinimo,
                command.EspessuraVidroMaximo,
                command.QuantidadeDesgasteLado,
                command.QuantidadeDesgasteTotal
            );
            {
                await _unitOfWork.DesgastePolimentoRepository.Adicionar(desgastePolimento);
                response.Formulario!.SetId(desgastePolimento.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }

    }
}
