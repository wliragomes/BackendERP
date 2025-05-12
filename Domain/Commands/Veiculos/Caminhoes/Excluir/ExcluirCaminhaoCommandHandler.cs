using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Caminhoes.Excluir
{
    public class ExcluirCaminhaoCommandHandler : IRequestHandler<ExcluirCaminhaoCommand, List<FormularioResponse<ExcluirCaminhaoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirCaminhaoCommand>> _response = new();

        public ExcluirCaminhaoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirCaminhaoCommand>>> Handle(ExcluirCaminhaoCommand command, CancellationToken cancellationToken)
        {
            var caminhao = await _unitOfWork.CaminhaoRepository.RetornarCaminhoesExcluirMassa(command.FiltroBase);

            if (!caminhao.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(caminhao);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirCaminhaoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirCaminhaoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Caminhao> caminhoes)
        {
            var index = 0;
            foreach (var caminhao in caminhoes)
            {

                caminhao.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirCaminhaoCommand>(index));
                index++;
            }
        }
    }
}