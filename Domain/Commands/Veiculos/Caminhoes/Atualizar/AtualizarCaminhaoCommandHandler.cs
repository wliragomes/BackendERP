using System.Text.RegularExpressions;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Caminhoes.Atualizar
{
    public class AtualizarCaminhaoCommandHandler : IRequestHandler<AtualizarCaminhaoCommand, FormularioResponse<AtualizarCaminhaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarCaminhaoCommand> _validator;
        private const int _indice = 0;

        public AtualizarCaminhaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarCaminhaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarCaminhaoCommand>> Handle(AtualizarCaminhaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarCaminhaoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            // Validação da placa do veículo
            if (!ValidarPlaca(command.Placa))
            {
                response.AddError("Placa", "Placa informada inválida! Digite conforme um dos formatos: AAA1234 e AAA1A23.");
                return response;
            }

            var CaminhaoUpdate = await _unitOfWork.CaminhaoRepository.ObterPorId(command.Id);
            if (CaminhaoUpdate == null)
            {
                return response;
            }

            CaminhaoUpdate!.Update(
                command.Descricao,
                command.CaminhaoCarreta,
                command.Numero,
                command.Placa,
                command.Tara,
                command.CapacidadeKg,
                command.CapacidadeM3,
                command.IdPessoa,
                command.IdTipoRodado,
                command.IdTipoCarroceria,
                command.IdEstado,
                command.Inativo);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarCaminhaoCommand(
                command.Id,
                command.Descricao,
                command.CaminhaoCarreta,
                command.Numero,
                command.Placa,
                command.Tara,
                command.CapacidadeKg,
                command.CapacidadeM3,
                command.IdPessoa,
                command.IdTipoRodado,
                command.IdTipoCarroceria,
                command.IdEstado,
                command.Inativo);

            response.SetFormulario(commandAtualizado);
            return response;
        }

        private bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            // Formato antigo: AAA-1234
            string formatoAntigo = @"^[A-Z]{3}\d{4}$";

            // Formato novo: AAA1B23
            string formatoNovo = @"^[A-Z]{3}\d[A-Z]\d{2}$";

            // Verifica se a placa atende a qualquer um dos dois formatos
            var placaValidaAntiga = Regex.IsMatch(placa, formatoAntigo);
            var placaValidaNova = Regex.IsMatch(placa, formatoNovo);

            return placaValidaAntiga || placaValidaNova;
        }
    }
}
