using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.CodigosImportacoes.Adicionar
{
    public class AdicionarCodigoImportacaoCommandHandler : IRequestHandler<AdicionarCodigoImportacaoCommand, FormularioResponse<AdicionarCodigoImportacaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarCodigoImportacaoCommand> _validator;
        private const int _indece = 0;

        public AdicionarCodigoImportacaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarCodigoImportacaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarCodigoImportacaoCommand>> Handle(AdicionarCodigoImportacaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarCodigoImportacaoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            CodigoImportacao codigo = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.CodigoImportacaoRepository.Adicionar(codigo);
                response.Formulario!.SetId(codigo.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}