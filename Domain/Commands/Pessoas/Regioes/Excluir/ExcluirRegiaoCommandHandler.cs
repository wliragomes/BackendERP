using Domain.Constant;
using Domain.Entities;
using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Regioes.Excluir
{
    public class ExcluirRegiaoCommandHandler : IRequestHandler<ExcluirRegiaoCommand, List<FormularioResponse<ExcluirRegiaoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirRegiaoCommand>> _response = new();

        public ExcluirRegiaoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirRegiaoCommand>>> Handle(ExcluirRegiaoCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.RegiaoRepository.RetornarRegiaosExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirRegiaoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirRegiaoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Regiao> regioes)
        {
            var index = 0;
            foreach (var checklist in regioes)
            {

                checklist.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirRegiaoCommand>(index));
                index++;
            }
        }
    }
}