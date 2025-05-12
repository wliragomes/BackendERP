using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.UnidadesMedidas.Adicionar
{
    public class AdicionarUnidadeMedidaCommandHandler : IRequestHandler<AdicionarUnidadeMedidaCommand, FormularioResponse<AdicionarUnidadeMedidaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarUnidadeMedidaCommand> _validator;
        private const int _indece = 0;

        public AdicionarUnidadeMedidaCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarUnidadeMedidaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarUnidadeMedidaCommand>> Handle(AdicionarUnidadeMedidaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarUnidadeMedidaCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            UnidadeMedida unidademedida = new
            (
                command.Descricao, command.Sigla, command.CasaDecimal);

            {
                await _unitOfWork.UnidadeMedidaRepository.Adicionar(unidademedida);
                response.Formulario!.SetId(unidademedida.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
