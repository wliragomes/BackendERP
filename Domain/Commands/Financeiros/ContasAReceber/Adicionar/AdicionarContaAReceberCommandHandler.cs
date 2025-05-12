using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasAReceber.Adicionar
{
    public class AdicionarContaAReceberCommandHandler : IRequestHandler<AdicionarContaAReceberCommand, FormularioResponse<AdicionarContaAReceberCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarContaAReceberCommand> _validator;
        private const int _indece = 0;

        public AdicionarContaAReceberCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarContaAReceberCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarContaAReceberCommand>> Handle(AdicionarContaAReceberCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarContaAReceberCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            decimal? valorParcela = command.ValorDocumento / command.QtdParcela;
            DateTime dataVencimento = command.DataVencimento; // Primeira parcela mantém a data digitada pelo usuário
            int diaOriginal = dataVencimento.Day; // Dia original da primeira parcela

            for (int i = 0; i < command.QtdParcela; i++)
            {
                string numeroParcela = (i + 1).ToString("D3"); // Ex: '001', '002', etc.
                string nDocumentoParcela = $"{command.NDocumento}P{numeroParcela}";

                ContaAReceber contaAReceber = new
                (
                    false,
                    command.Rascunho,
                    command.IdCliente,
                    nDocumentoParcela, // Documento único por parcela
                    command.DataDocumento,
                    dataVencimento,
                    valorParcela,
                    command.UnitarioPeriodoMensal,
                    command.QtdParcela,
                    command.QtdPeriodo,
                    command.IdCentroDeCusto,
                    command.IdDespesa,
                    command.IdBanco,
                    command.IdFatura,
                    command.Historico
                );

                await _unitOfWork.ContaAReceberRepository.Adicionar(contaAReceber);
                response.Formulario!.SetId(contaAReceber.Id);

                if (command.QtdPeriodo == 0)
                {
                    dataVencimento = dataVencimento.AddMonths(1);

                    int ultimoDiaDoMes = DateTime.DaysInMonth(dataVencimento.Year, dataVencimento.Month);

                    if (diaOriginal > ultimoDiaDoMes)
                    {
                        dataVencimento = new DateTime(dataVencimento.Year, dataVencimento.Month, ultimoDiaDoMes);
                    }
                    else
                    {
                        dataVencimento = new DateTime(dataVencimento.Year, dataVencimento.Month, diaOriginal);
                    }
                }
                else
                {
                    dataVencimento = dataVencimento.AddDays(command.QtdPeriodo);
                }
            }

            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }
    }
}