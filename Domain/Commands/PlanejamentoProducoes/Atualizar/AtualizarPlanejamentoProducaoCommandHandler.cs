using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.PlanejamentoProducaos.Atualizar
{
    public class AtualizarPlanejamentoProducaoCommandHandler : IRequestHandler<AtualizarPlanejamentoProducaoCommand, FormularioResponse<AtualizarPlanejamentoProducaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarPlanejamentoProducaoCommand> _validator;
        private const int _indice = 0;

        public AtualizarPlanejamentoProducaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarPlanejamentoProducaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarPlanejamentoProducaoCommand>> Handle(AtualizarPlanejamentoProducaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarPlanejamentoProducaoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var PlanejamentoProducaoUpdate = await _unitOfWork.PlanejamentoProducaoRepository.ObterPorId(command.Id);
            PlanejamentoProducaoUpdate!.Update(
                command.IdOrdemFabricacao, 
                command.IdOrdemFabricacaoItem, 
                command.IdComposicao,
                command.SequenciaComposicacao,
                command.Altura,
                command.Largura,
                command.NPeca,
                command.QtdTotalPeca,
                command.CodigoBarra,
                command.AnoBarra,
                command.CodigoBarraCompleto,
                command.ValorM2,
                command.ValorMLinear,
                command.ValorPeso,
                command.ValorM2Real,
                command.ValorMLinearReal,
                command.ValorPesoReal,
                command.ValorAreaMinima,
                command.IdSetorProduto,
                command.AlturaLapidacao,
                command.LarguraLapidacao,
                command.DataReposicao,
                command.IdPlanejamentoComposto,
                command.Reposicao,
                command.Reposto);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarPlanejamentoProducaoCommand(
                command.Id,
                command.IdOrdemFabricacao,
                command.IdOrdemFabricacaoItem,
                command.IdComposicao,
                command.SequenciaComposicacao,
                command.Altura,
                command.Largura,
                command.NPeca,
                command.QtdTotalPeca,
                command.CodigoBarra,
                command.AnoBarra,
                command.CodigoBarraCompleto,
                command.ValorM2,
                command.ValorMLinear,
                command.ValorPeso,
                command.ValorM2Real,
                command.ValorMLinearReal,
                command.ValorPesoReal,
                command.ValorAreaMinima,
                command.IdSetorProduto,
                command.AlturaLapidacao,
                command.LarguraLapidacao,
                command.DataReposicao,
                command.IdPlanejamentoComposto,
                command.Reposicao,
                command.Reposto);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}