using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Pessoas.TipoConsumidores.Atualizar
{
    public class AtualizarTipoConsumidorCommandHandler : IRequestHandler<AtualizarTipoConsumidorCommand, FormularioResponse<AtualizarTipoConsumidorCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarTipoConsumidorCommand> _validator;
        private const int _indice = 0;

        public AtualizarTipoConsumidorCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarTipoConsumidorCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarTipoConsumidorCommand>> Handle(AtualizarTipoConsumidorCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarTipoConsumidorCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var TipoConsumidorUpdate = await _unitOfWork.TipoConsumidorRepository.ObterPorId(command.Id);
            TipoConsumidorUpdate!.Update(
                command.Nome, 
                command.Descricao, 
                command.SomaItens, 
                command.SomaDespesasBaseIcms, 
                command.SomaIpiBaseIcms,
                command.SomaDespesasBaseSt,
                command.SomaIpiBaseSt,
                command.SomaStBaseIcms,
                command.Difal,
                command.SubstituicaoIcms);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarTipoConsumidorCommand(
                command.Id,
                command.Nome,
                command.Descricao,
                command.SomaItens,
                command.SomaDespesasBaseIcms,
                command.SomaIpiBaseIcms,
                command.SomaDespesasBaseSt,
                command.SomaIpiBaseSt,
                command.SomaStBaseIcms,
                command.Difal,
                command.SubstituicaoIcms);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
