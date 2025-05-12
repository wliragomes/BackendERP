using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Classificacoes.Atualizar
{
    public class AtualizarClassificacaoCommandHandler : IRequestHandler<AtualizarClassificacaoCommand, FormularioResponse<AtualizarClassificacaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarClassificacaoCommand> _validator;
        private const int _indice = 0;

        public AtualizarClassificacaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarClassificacaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarClassificacaoCommand>> Handle(AtualizarClassificacaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarClassificacaoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var ClassificacaoUpdate = await _unitOfWork.ClassificacaoRepository.ObterPorId(command.Id);
            ClassificacaoUpdate!.Update(command.Nome);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarClassificacaoCommand(
                command.Id,
                command.Nome);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
