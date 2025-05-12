using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.OrdensFabricacoes.Adicionar
{
    public class AdicionarOrdemFabricacaoTemporariaCommandHandler : IRequestHandler<AdicionarOrdemFabricacaoTemporariaCommand, FormularioResponse<AdicionarOrdemFabricacaoTemporariaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AdicionarOrdemFabricacaoTemporariaCommand> _validator;
        private const int _indice = 0;

        public AdicionarOrdemFabricacaoTemporariaCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarOrdemFabricacaoTemporariaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarOrdemFabricacaoTemporariaCommand>> Handle(AdicionarOrdemFabricacaoTemporariaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarOrdemFabricacaoTemporariaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var idComum = Guid.NewGuid();

            var ordensFabricacaoItemTemporaria = CriarOrdemFabricacaoTemporaria(command.OrdemFabricacaoItemTemporaria, idComum);

            foreach (var item in ordensFabricacaoItemTemporaria)
            {
                await _unitOfWork.OrdemFabricacaoItemTemporariaRepository.Adicionar(item);
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return response;
        }

        private List<OrdemFabricacaoItemTemporaria> CriarOrdemFabricacaoTemporaria(IEnumerable<OrdemFabricacaoItemTemporariaCommand>? ordemFabricacaoItemTemporariaCommands, Guid idComum)
        {
            var comandos = ordemFabricacaoItemTemporariaCommands ?? Enumerable.Empty<OrdemFabricacaoItemTemporariaCommand>();

            return comandos.Select(cmd =>
            {
                var item = new OrdemFabricacaoItemTemporaria(
                    cmd.IdVenda,
                    cmd.SqVendaItem,
                    cmd.Altura,
                    cmd.Largura,
                    cmd.ValorM2,
                    cmd.Quantidade,
                    cmd.ValorPeso,
                    cmd.ValorMLinearReal,
                    cmd.ValorMLinear
                );

                item.SetId(idComum);

                return item;
            }).ToList();
        }
    }
}