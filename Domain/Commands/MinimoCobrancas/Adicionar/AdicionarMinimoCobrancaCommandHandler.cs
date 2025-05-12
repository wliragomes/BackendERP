using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MinimoCobrancas.Adicionar
{
    public class AdicionarMinimoCobrancaCommandHandler : IRequestHandler<AdicionarMinimoCobrancaCommand, FormularioResponse<AdicionarMinimoCobrancaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarMinimoCobrancaCommand> _validator;
        private const int _indece = 0;

        public AdicionarMinimoCobrancaCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarMinimoCobrancaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarMinimoCobrancaCommand>> Handle(AdicionarMinimoCobrancaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarMinimoCobrancaCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            MinimoCobranca minimoCobranca = new
            (
                command.Descricao,
                command.ValorMinimoCobranca
            );

            var minimoCobrancaItens = CriarMinimoCobrancaItens(command.MinimoCobrancaItem!, minimoCobranca.Id);


            await _unitOfWork.MinimoCobrancaItemRepository.AdicionarEmMassa(minimoCobrancaItens);
            await _unitOfWork.MinimoCobrancaRepository.Adicionar(minimoCobranca);
            response.Formulario!.SetId(minimoCobranca.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
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
