using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Familias.Adicionar
{
    public class AdicionarFamiliaCommandHandler : IRequestHandler<AdicionarFamiliaCommand, FormularioResponse<AdicionarFamiliaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarFamiliaCommand> _validator;
        private const int _indece = 0;

        public AdicionarFamiliaCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarFamiliaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarFamiliaCommand>> Handle(AdicionarFamiliaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarFamiliaCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Familia familia = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.FamiliaRepository.Adicionar(familia);
                response.Formulario!.SetId(familia.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
