using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Setores.Adicionar
{
    public class AdicionarSetorCommandHandler : IRequestHandler<AdicionarSetorCommand, FormularioResponse<AdicionarSetorCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarSetorCommand> _validator;
        private const int _indece = 0;

        public AdicionarSetorCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarSetorCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarSetorCommand>> Handle(AdicionarSetorCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarSetorCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Setor setor = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.SetorRepository.Adicionar(setor);
                response.Formulario!.SetId(setor.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}