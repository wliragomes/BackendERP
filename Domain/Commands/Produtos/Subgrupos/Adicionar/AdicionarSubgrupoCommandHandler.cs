using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Subgrupos.Adicionar
{
    public class AdicionarSubgrupoCommandHandler : IRequestHandler<AdicionarSubgrupoCommand, FormularioResponse<AdicionarSubgrupoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarSubgrupoCommand> _validator;
        private const int _indece = 0;

        public AdicionarSubgrupoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarSubgrupoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarSubgrupoCommand>> Handle(AdicionarSubgrupoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarSubgrupoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Subgrupo subgrupo = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.SubgrupoRepository.Adicionar(subgrupo);
                response.Formulario!.SetId(subgrupo.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
