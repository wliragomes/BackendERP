using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.FaturaTemporarias.Excluir
{
    public class ExcluirFaturaTemporariaCommandHandler : IRequestHandler<ExcluirFaturaTemporariaCommand, List<FormularioResponse<ExcluirFaturaTemporariaCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirFaturaTemporariaCommand>> _response = new();

        public ExcluirFaturaTemporariaCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirFaturaTemporariaCommand>>> Handle(ExcluirFaturaTemporariaCommand command, CancellationToken cancellationToken)
        {
            var faturaTemporaria = await _unitOfWork.FaturaTemporariaRepository.RetornarFaturaTemporariasExcluirMassa(command.FiltroBase);

            if (!faturaTemporaria.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(faturaTemporaria);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirFaturaTemporariaCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirFaturaTemporariaCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<FaturaTemporaria> faturaTemporarias)
        {
            var index = 0;
            foreach (var faturaTemporaria in faturaTemporarias)
            {

                faturaTemporaria.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirFaturaTemporariaCommand>(index));
                index++;
            }
        }
    }
}