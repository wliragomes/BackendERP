using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MinimoCobrancas.Atualizar
{
    public class AtualizarMinimoCobrancaCommandHandler : IRequestHandler<AtualizarMinimoCobrancaCommand, FormularioResponse<AtualizarMinimoCobrancaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarMinimoCobrancaCommand> _validator;
        private const int _indice = 0;

        public AtualizarMinimoCobrancaCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarMinimoCobrancaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarMinimoCobrancaCommand>> Handle(AtualizarMinimoCobrancaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarMinimoCobrancaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var MinimoCobrancaItemUpdate = await _unitOfWork.MinimoCobrancaItemRepository.ObterPorId(command.Id);
            var MinimoCobrancaUpdate = await _unitOfWork.MinimoCobrancaRepository.ObterPorId(command.Id);
            MinimoCobrancaUpdate!.Update(command.Descricao, command.ValorMinimoCobranca);


            var commandAtualizado = new AtualizarMinimoCobrancaCommand(
                command.Id,
                command.Descricao,
                command.ValorMinimoCobranca);

            var minimoCobrancaItemExistente = await _unitOfWork.MinimoCobrancaItemRepository
                .ObterMinimoCobrancaItemPorId(MinimoCobrancaItemUpdate!.IdMinimoCobranca, MinimoCobrancaItemUpdate.IdSetorProduto, MinimoCobrancaItemUpdate.DescricaoSetorProduto);

            var minimoCobrancaItemParaRemover = command.MinimoCobrancaItem.FirstOrDefault(novo =>
                novo.IdSetorProduto == minimoCobrancaItemExistente!.IdSetorProduto &&
                novo.DescricaoSetorProduto == minimoCobrancaItemExistente.DescricaoSetorProduto);

            if (minimoCobrancaItemParaRemover == null)
            {
                minimoCobrancaItemExistente!.ChangeRemoved(true);
            }

            var minimoCobrancaItens = CriarMinimoCobrancaItens(command.MinimoCobrancaItem!, command.Id);
            await _unitOfWork.MinimoCobrancaItemRepository.AdicionarEmMassa(minimoCobrancaItens);


            await _unitOfWork.CommitAsync(cancellationToken);

            response.SetFormulario(commandAtualizado);
            return response;
        }

        private List<MinimoCobrancaItem> CriarMinimoCobrancaItens(IEnumerable<MinimoCobrancaItemCommand> minimoCobrancaItensCommands, Guid idMinimoCobranca)
        {
            return minimoCobrancaItensCommands.Select(minimoCobrancaItem => new MinimoCobrancaItem(
                idMinimoCobranca,
                minimoCobrancaItem.IdSetorProduto,
                minimoCobrancaItem.DescricaoSetorProduto
            )).ToList();
        }
    }
}
