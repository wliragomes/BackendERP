using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Bancos.Atualizar
{
    public class AtualizarBancoCommandHandler : IRequestHandler<AtualizarBancoCommand, FormularioResponse<AtualizarBancoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarBancoCommand> _validator;
        private const int _indice = 0;

        public AtualizarBancoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarBancoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarBancoCommand>> Handle(AtualizarBancoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarBancoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var BancoUpdate = await _unitOfWork.BancoRepository.ObterPorId(command.Id);
            BancoUpdate!.Update(command.Nome, command.NaoSomar, command.NumeroBanco);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarBancoCommand(
                command.Id,
                command.Nome,
                command.NaoSomar,
                command.NumeroBanco);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
