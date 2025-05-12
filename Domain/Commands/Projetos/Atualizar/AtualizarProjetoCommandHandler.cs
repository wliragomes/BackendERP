using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Projetos.Atualizar
{
    public class AtualizarProjetoCommandHandler : IRequestHandler<AtualizarProjetoCommand, FormularioResponse<AtualizarProjetoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarProjetoCommand> _validator;
        private const int _indice = 0;

        public AtualizarProjetoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarProjetoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarProjetoCommand>> Handle(AtualizarProjetoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarProjetoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var ProjetoUpdate = await _unitOfWork.ProjetoRepository.ObterPorId(command.Id);
            ProjetoUpdate!.Update(command.Nome, command.Apitar, command.Tarja, command.Agrupar, command.FProjeto);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarProjetoCommand(
                command.Id,
                command.Nome,
                command.Apitar,
                command.Tarja,
                command.Agrupar,
                command.FProjeto);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
