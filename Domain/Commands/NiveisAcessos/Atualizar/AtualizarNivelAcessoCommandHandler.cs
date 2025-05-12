using Domain.Commands.Funcionalidades.Adicionar;
using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.NiveisAcessos.Atualizar
{
    public class AtualizarNivelAcessoCommandHandler : IRequestHandler<AtualizarNivelAcessoCommand, FormularioResponse<AtualizarNivelAcessoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarNivelAcessoCommand> _validator;
        private const int _indice = 0;

        public AtualizarNivelAcessoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarNivelAcessoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarNivelAcessoCommand>> Handle(AtualizarNivelAcessoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarNivelAcessoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var NivelAcessoUpdate = await _unitOfWork.NivelAcessoRepository.ObterPorId(command.Id);
            NivelAcessoUpdate!.Update(command.Codigo, command.Nome);
            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarNivelAcessoCommand(
                command.Id,
                command.Codigo,
                command.Nome);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}