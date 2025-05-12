using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MotivoReposições.Excluir
{
    public class ExcluirMotivoReposicaoCommandHandler : IRequestHandler<ExcluirMotivoReposicaoCommand, List<FormularioResponse<ExcluirMotivoReposicaoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirMotivoReposicaoCommand>> _response = new();

        public ExcluirMotivoReposicaoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirMotivoReposicaoCommand>>> Handle(ExcluirMotivoReposicaoCommand command, CancellationToken cancellationToken)
        {
            var motivoReposicao = await _unitOfWork.MotivoReposicaoRepository.RetornarMotivoReposicaosExcluirMassa(command.FiltroBase);

            if (!motivoReposicao.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(motivoReposicao);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirMotivoReposicaoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirMotivoReposicaoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<MotivoReposicao> motivoReposicaos)
        {
            var index = 0;
            foreach (var motivoReposicao in motivoReposicaos)
            {

                motivoReposicao.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirMotivoReposicaoCommand>(index));
                index++;
            }
        }
    }
}