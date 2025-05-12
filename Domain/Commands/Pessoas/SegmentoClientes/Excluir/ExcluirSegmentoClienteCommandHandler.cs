using Domain.Constant;
using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.SegmentoClientes.Excluir
{
    public class ExcluirSegmentoClienteCommandHandler : IRequestHandler<ExcluirSegmentoClienteCommand, List<FormularioResponse<ExcluirSegmentoClienteCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirSegmentoClienteCommand>> _response = new();

        public ExcluirSegmentoClienteCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirSegmentoClienteCommand>>> Handle(ExcluirSegmentoClienteCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.SegmentoClienteRepository.RetornarSegmentoClientesExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirSegmentoClienteCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirSegmentoClienteCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<SegmentoCliente> segmentoclientes)
        {
            var index = 0;
            foreach (var checklist in segmentoclientes)
            {

                checklist.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirSegmentoClienteCommand>(index));
                index++;
            }
        }
    }
}