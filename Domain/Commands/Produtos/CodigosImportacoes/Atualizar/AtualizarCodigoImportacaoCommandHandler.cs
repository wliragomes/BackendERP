using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.CodigosImportacoes.Atualizar
{
    public class AtualizarCodigoImportacaoCommandHandler : IRequestHandler<AtualizarCodigoImportacaoCommand, FormularioResponse<AtualizarCodigoImportacaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarCodigoImportacaoCommand> _validator;
        private const int _indice = 0;

        public AtualizarCodigoImportacaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarCodigoImportacaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarCodigoImportacaoCommand>> Handle(AtualizarCodigoImportacaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarCodigoImportacaoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var CodigoImportacaoUpdate = await _unitOfWork.CodigoImportacaoRepository.ObterPorId(command.Id);
            CodigoImportacaoUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarCodigoImportacaoCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}