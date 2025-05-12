using Domain.Commands.ContasAPagar;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Duplicatas.Atualizar
{
    public class AtualizarDuplicataCommandHandler : IRequestHandler<AtualizarDuplicataCommand, FormularioResponse<AtualizarDuplicataCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarDuplicataCommand> _validator;
        private const int _indice = 0;

        public AtualizarDuplicataCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarDuplicataCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarDuplicataCommand>> Handle(AtualizarDuplicataCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarDuplicataCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            // Buscar a Duplicata existente
            var DuplicataParcelaUpdate = await _unitOfWork.DuplicataParcelaRepository.ObterPorId(command.Id);
            var DuplicataUpdate = await _unitOfWork.DuplicataRepository.ObterPorId(command.Id);
            if (DuplicataUpdate == null)
            {
                return response;
            }

            // Atualizar as informações da Duplicata
            DuplicataUpdate.Update(
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

            DuplicataParcelaUpdate.Update(
                command.Parcela = command.QtdParcelas,
                command.ValorDuplicata = command.ValorTotal,
                command.ValorDuplicataExtensao,
                command.DataVencimento
            );

            // Commit das operações no banco
            await _unitOfWork.CommitAsync(cancellationToken);

            // Criar o comando atualizado para retornar na resposta
            var commandAtualizado = new AtualizarDuplicataCommand(
                command.Id,
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
                command.IdEstado,
                command.NumeroEnderecoCobranca,
                command.ComplementoCobranca,
                command.Observacao
            );

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
