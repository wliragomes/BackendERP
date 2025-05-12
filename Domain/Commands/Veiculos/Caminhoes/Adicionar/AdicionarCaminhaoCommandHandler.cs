using System.Text.RegularExpressions;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Caminhoes.Adicionar
{
    public class AdicionarCaminhaoCommandHandler : IRequestHandler<AdicionarCaminhaoCommand, FormularioResponse<AdicionarCaminhaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AdicionarCaminhaoCommand> _validator;
        private const int _indece = 0;

        public AdicionarCaminhaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarCaminhaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarCaminhaoCommand>> Handle(AdicionarCaminhaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarCaminhaoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            // Validação da placa do veículo
            if (!ValidarPlaca(command.Placa))
            {
                response.AddError("Placa", "Placa informada inválida! Digite conforme um dos seguintes formatos: AAA1234 e AAA1A23.");
                return response;
            }

            Caminhao caminhao = new
            (
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
                command.Inativo
            );

            await _unitOfWork.CaminhaoRepository.Adicionar(caminhao);
            response.Formulario!.SetId(caminhao.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }

        private bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            string formatoAntigo = @"^[A-Z]{3}\d{4}$";

            string formatoNovo = @"^[A-Z]{3}\d[A-Z]\d{2}$";

            // Verifica se a placa atende a qualquer um dos dois formatos
            var placaValidaAntiga = Regex.IsMatch(placa, formatoAntigo);
            var placaValidaNova = Regex.IsMatch(placa, formatoNovo);

            return placaValidaAntiga || placaValidaNova;
        }
    }
}
