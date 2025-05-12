using Domain.Constant;
using Domain.Entities;
using Domain.Entities.Vendas;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.TipoFretes.Excluir
{
    public class ExcluirTipoFreteCommandHandler : IRequestHandler<ExcluirTipoFreteCommand, List<FormularioResponse<ExcluirTipoFreteCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirTipoFreteCommand>> _response = new();

        public ExcluirTipoFreteCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirTipoFreteCommand>>> Handle(ExcluirTipoFreteCommand command, CancellationToken cancellationToken)
        {
            var tipoFrete = await _unitOfWork.TipoFreteRepository.RetornarTiposFretesExcluirMassa(command.FiltroBase);

            if (!tipoFrete.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(tipoFrete);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirTipoFreteCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirTipoFreteCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<TipoFrete> tiposFretes)
        {
            var index = 0;
            foreach (var tipoFrete in tiposFretes)
            {

                tipoFrete.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirTipoFreteCommand>(index));
                index++;
            }
        }
    }
}