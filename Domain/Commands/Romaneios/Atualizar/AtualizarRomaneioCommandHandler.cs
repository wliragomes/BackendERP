using Domain.Commands.Romaneios;
using Domain.Commands.Romaneios.Atualizar;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.OrdensFabricacoes.Atualizar
{
    public class AtualizarRomaneioCommandHandler : IRequestHandler<AtualizarRomaneioCommand, FormularioResponse<AtualizarRomaneioCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarRomaneioCommand> _validator;
        private const int _indice = 0;

        public AtualizarRomaneioCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarRomaneioCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarRomaneioCommand>> Handle(AtualizarRomaneioCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarRomaneioCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var romaneioExistente = await _unitOfWork.RomaneioRepository.ObterPorId(command.Id);

            if (romaneioExistente == null)
            {
                return response;
            }

            int sqRomaneioCodigo = romaneioExistente.SqRomaneioCodigo;
            int sqRomaneioAno = romaneioExistente.SqRomaneioAno;

            romaneioExistente.Update(
                sqRomaneioCodigo, 
                sqRomaneioAno,
                command.QtdFrete
            );

            var romaneioItemRemover = await _unitOfWork.RomaneioItemRepository.ObterPorIdRomaneioItem(command.Id);
            if (romaneioItemRemover.Any())
            {
                await _unitOfWork.RomaneioItemRepository.RemoverMassa(romaneioItemRemover);
            }

            var romaneioItem = CriarRomaneioItem(command.RomaneioItem!, command.Id);
            await _unitOfWork.RomaneioItemRepository.AdicionarEmMassa(romaneioItem);

            await _unitOfWork.CommitAsync(cancellationToken);

            response.SetFormulario(command);
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