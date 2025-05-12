using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.OrdensFabricacoes.Excluir
{
    public class ExcluirOrdemFabricacaoCommandHandler : IRequestHandler<ExcluirOrdemFabricacaoCommand, List<FormularioResponse<ExcluirOrdemFabricacaoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirOrdemFabricacaoCommand>> _response = new();

        public ExcluirOrdemFabricacaoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirOrdemFabricacaoCommand>>> Handle(ExcluirOrdemFabricacaoCommand command, CancellationToken cancellationToken)
        {
            var ordemFabricacao = await _unitOfWork.OrdemFabricacaoRepository.RetornarOrdensFabricacoesExcluirMassa(command.FiltroBase);

            if (!ordemFabricacao.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(ordemFabricacao);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirOrdemFabricacaoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirOrdemFabricacaoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<OrdemFabricacao> ordensFabricacoes)
        {
            var index = 0;
            foreach (var ordemFabricacao in ordensFabricacoes)
            {

                ordemFabricacao.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirOrdemFabricacaoCommand>(index));
                index++;
            }
        }
    }
}