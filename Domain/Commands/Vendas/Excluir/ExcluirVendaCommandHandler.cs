using Domain.Commands.Vendas.Excluir;
using Domain.Constant;
using Domain.Entities;
using Domain.Entities.Vendas;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.NormasAbnts.Excluir
{
    public class ExcluirVendaCommandHandler : IRequestHandler<ExcluirVendaCommand, List<FormularioResponse<ExcluirVendaCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirVendaCommand>> _response = new();

        public ExcluirVendaCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirVendaCommand>>> Handle(ExcluirVendaCommand command, CancellationToken cancellationToken)
        {
            var venda = await _unitOfWork.VendaRepository.RetornarVendasExcluirMassa(command.FiltroBase);

            if (!venda.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(venda);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirVendaCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirVendaCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Venda> vendas)
        {
            var index = 0;
            foreach (var venda in vendas)
            {

                venda.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirVendaCommand>(index));
                index++;
            }
        }
    }
}