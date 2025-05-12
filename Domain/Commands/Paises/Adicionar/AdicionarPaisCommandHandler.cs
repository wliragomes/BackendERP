using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Paises.Adicionar
{
    public class AdicionarPaisCommandHandler : IRequestHandler<AdicionarPaisCommand, FormularioResponse<AdicionarPaisCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarPaisCommand> _validator;
        private const int _indece = 0;

        public AdicionarPaisCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarPaisCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarPaisCommand>> Handle(AdicionarPaisCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarPaisCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

                Pais pais = new
                (
                    command.Nome,
                    command.IdFusoHorario,
                    command.IdDdi,
                    command.IdMoedaPrincipal
                );

            await _unitOfWork.PaisRepository.Adicionar(pais);
            response.Formulario!.SetId(pais.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }
    }
}
