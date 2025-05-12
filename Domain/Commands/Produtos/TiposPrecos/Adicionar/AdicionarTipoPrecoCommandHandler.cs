using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.TiposPrecos.Adicionar
{
    public class AdicionarTipoPrecoCommandHandler : IRequestHandler<AdicionarTipoPrecoCommand, FormularioResponse<AdicionarTipoPrecoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarTipoPrecoCommand> _validator;
        private const int _indece = 0;

        public AdicionarTipoPrecoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarTipoPrecoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarTipoPrecoCommand>> Handle(AdicionarTipoPrecoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarTipoPrecoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            TipoPreco tipopreco = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.TipoPrecoRepository.Adicionar(tipopreco);
                response.Formulario!.SetId(tipopreco.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
