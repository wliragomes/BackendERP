using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Comissoes.Adicionar
{
    public class AdicionarComissaoCommandHandler : IRequestHandler<AdicionarComissaoCommand, FormularioResponse<AdicionarComissaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarComissaoCommand> _validator;
        private const int _indece = 0;

        public AdicionarComissaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarComissaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarComissaoCommand>> Handle(AdicionarComissaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarComissaoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Comissao comissao = new
            (
                command.IdVendaRecebimentoTipo,
                command.IdContaAReceber,
                command.IdFatura,
                command.IdVendedor,
                command.Comissaoo,
                command.ValorComissao,
                command.ValorPago,
                command.DataEmissao,
                command.DataVencimento,
                command.DataPagamento,
                command.IdStatus);
            {

                await _unitOfWork.ComissaoRepository.Adicionar(comissao);
                response.Formulario!.SetId(comissao.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
