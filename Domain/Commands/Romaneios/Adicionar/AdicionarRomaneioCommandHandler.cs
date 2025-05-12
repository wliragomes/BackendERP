using Domain.Commands.Romaneios;
using Domain.Entities;
using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.OrdensFabricacoes.Adicionar
{
    public class AdicionarRomaneioCommandHandler : IRequestHandler<AdicionarRomaneioCommand, FormularioResponse<AdicionarRomaneioCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarRomaneioCommand> _validator;
        private const int _indece = 0;

        public AdicionarRomaneioCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarRomaneioCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarRomaneioCommand>> Handle(AdicionarRomaneioCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarRomaneioCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            int novoSqRomaneioCodigo = (await _unitOfWork.RomaneioRepository.ObterUltimoSqRomaneioCodigo()) + 1;

            int sqRomaneioAno = DateTime.Now.Year % 100;

            Romaneio romaneio = new
            (
                novoSqRomaneioCodigo,
                sqRomaneioAno,
                command.QtdFrete
            );

            var romaneioItens = CriarRomaneioItem(command.RomaneioItem!, romaneio.Id);

            await _unitOfWork.RomaneioRepository.Adicionar(romaneio);
            await _unitOfWork.RomaneioItemRepository.AdicionarEmMassa(romaneioItens);
            response.Formulario!.SetId(romaneio.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }

        private List<RomaneioItem> CriarRomaneioItem(IEnumerable<RomaneioItemCommand> romaneioItemCommands, Guid idRomaneio)
        {
            return romaneioItemCommands.Select(romaneioItem =>
            {
                return new RomaneioItem(
                    idRomaneio,
                    romaneioItem.IdOrdemFabricacaoItem,
                    romaneioItem.SqRomaneioItem,
                    romaneioItem.QtItem
                );
            }).ToList();
        }
    }
}



