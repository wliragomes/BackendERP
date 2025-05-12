using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.NormasAbnts.Adicionar
{
    public class AdicionarNormaAbntCommandHandler : IRequestHandler<AdicionarNormaAbntCommand, FormularioResponse<AdicionarNormaAbntCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarNormaAbntCommand> _validator;
        private const int _indice = 0;

        public AdicionarNormaAbntCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarNormaAbntCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarNormaAbntCommand>> Handle(AdicionarNormaAbntCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarNormaAbntCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            NormaAbnt normaAbnt = new
            (
                command.NNbr!,                    
                command.Descricao!,
                command.Pedido!,
                command.Validade!,
                command.Vencida
            );

            await _unitOfWork.NormaAbntRepository.Adicionar(normaAbnt);
            response.Formulario!.SetId(normaAbnt.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }
    }
}