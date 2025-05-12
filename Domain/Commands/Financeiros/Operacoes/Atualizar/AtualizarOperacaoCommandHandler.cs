using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Operacoes.Atualizar
{
    public class AtualizarOperacaoCommandHandler : IRequestHandler<AtualizarOperacaoCommand, FormularioResponse<AtualizarOperacaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarOperacaoCommand> _validator;
        private const int _indice = 0;

        public AtualizarOperacaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarOperacaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarOperacaoCommand>> Handle(AtualizarOperacaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarOperacaoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var OperacaoUpdate = await _unitOfWork.OperacaoRepository.ObterPorId(command.Id);
            OperacaoUpdate!.Update(command.Nome, command.DescontaFinanceiro, command.LancaComissao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarOperacaoCommand(
                command.Id,
                command.Nome,
                command.DescontaFinanceiro,
                command.LancaComissao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
