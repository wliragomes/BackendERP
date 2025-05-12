using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Operacoes.Excluir
{
    public class ExcluirOperacaoCommandHandler : IRequestHandler<ExcluirOperacaoCommand, List<FormularioResponse<ExcluirOperacaoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirOperacaoCommand>> _response = new();

        public ExcluirOperacaoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirOperacaoCommand>>> Handle(ExcluirOperacaoCommand command, CancellationToken cancellationToken)
        {
            var operacao = await _unitOfWork.OperacaoRepository.RetornarOperacoesExcluirMassa(command.FiltroBase);

            if (!operacao.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(operacao);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirOperacaoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirOperacaoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Operacao> operacoes)
        {
            var index = 0;
            foreach (var operacao in operacoes)
            {

                operacao.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirOperacaoCommand>(index));
                index++;
            }
        }
    }
}