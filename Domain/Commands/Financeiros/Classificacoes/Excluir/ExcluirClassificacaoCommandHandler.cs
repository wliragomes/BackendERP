using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Classificacoes.Excluir
{
    public class ExcluirClassificacaoCommandHandler : IRequestHandler<ExcluirClassificacaoCommand, List<FormularioResponse<ExcluirClassificacaoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirClassificacaoCommand>> _response = new();

        public ExcluirClassificacaoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirClassificacaoCommand>>> Handle(ExcluirClassificacaoCommand command, CancellationToken cancellationToken)
        {
            var classificacao = await _unitOfWork.ClassificacaoRepository.RetornarClassificacoesExcluirMassa(command.FiltroBase);

            if (!classificacao.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(classificacao);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirClassificacaoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirClassificacaoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Classificacao> classificacoes)
        {
            var index = 0;
            foreach (var classificacao in classificacoes)
            {

                classificacao.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirClassificacaoCommand>(index));
                index++;
            }
        }
    }
}