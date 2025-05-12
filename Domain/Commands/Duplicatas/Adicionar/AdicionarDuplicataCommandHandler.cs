using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Duplicatas.Adicionar
{
    public class AdicionarDuplicataCommandHandler : IRequestHandler<AdicionarDuplicataCommand, FormularioResponse<AdicionarDuplicataCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AdicionarDuplicataCommand> _validator;
        private const int _indice = 0;

        public AdicionarDuplicataCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarDuplicataCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarDuplicataCommand>> Handle(AdicionarDuplicataCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarDuplicataCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var duplicata = new Duplicata(
                command.Parcelado,
                command.Numero,
                command.Ano,
                command.ValorTotal,
                1,
                command.DataEmissao,
                command.IdSacado,
                command.Cep,
                command.Endereco,
                command.IdCidade,
                command.IdEstado,
                command.NumeroEndereco,
                command.Complemento,
                command.CepCobranca,
                command.EnderecoCobranca,
                command.IdCidadeCobranca,
                command.IdEstadoCobranca,
                command.NumeroEnderecoCobranca,
                command.ComplementoCobranca,
                command.Observacao
            );

            await _unitOfWork.DuplicataRepository.Adicionar(duplicata);
            await _unitOfWork.CommitAsync(cancellationToken);

            var duplicataParcela = new DuplicataParcela(
                duplicata.Id, // Usa o mesmo ID da Duplicata
                command.Parcela = command.QtdParcelas,
                command.ValorDuplicata = command.ValorTotal,
                command.ValorDuplicataExtensao,
                command.DataVencimento
            );

            await _unitOfWork.DuplicataParcelaRepository.Adicionar(duplicataParcela);
            await _unitOfWork.CommitAsync(cancellationToken);

            return response;
        }
    }
}