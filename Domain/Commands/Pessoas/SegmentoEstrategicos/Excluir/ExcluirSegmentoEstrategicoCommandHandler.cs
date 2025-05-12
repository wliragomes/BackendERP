using Domain.Constant;
using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.SegmentoEstrategicos.Excluir
{
    public class ExcluirSegmentoEstrategicoCommandHandler : IRequestHandler<ExcluirSegmentoEstrategicoCommand, List<FormularioResponse<ExcluirSegmentoEstrategicoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirSegmentoEstrategicoCommand>> _response = new();

        public ExcluirSegmentoEstrategicoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirSegmentoEstrategicoCommand>>> Handle(ExcluirSegmentoEstrategicoCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.SegmentoEstrategicoRepository.RetornarSegmentoEstrategicosExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirSegmentoEstrategicoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirSegmentoEstrategicoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<SegmentoEstrategico> segmentoestrategico)
        {
            var index = 0;
            foreach (var checklist in segmentoestrategico)
            {

                checklist.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirSegmentoEstrategicoCommand>(index));
                index++;
            }
        }
    }
}