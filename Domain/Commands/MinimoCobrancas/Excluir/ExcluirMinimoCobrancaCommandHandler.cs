using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MinimoCobrancas.Excluir
{
    public class ExcluirMinimoCobrancaCommandHandler : IRequestHandler<ExcluirMinimoCobrancaCommand, List<FormularioResponse<ExcluirMinimoCobrancaCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirMinimoCobrancaCommand>> _response = new();

        public ExcluirMinimoCobrancaCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirMinimoCobrancaCommand>>> Handle(ExcluirMinimoCobrancaCommand command, CancellationToken cancellationToken)
        {
            var minimoCobranca = await _unitOfWork.MinimoCobrancaRepository.RetornarMinimoCobrancasExcluirMassa(command.FiltroBase);

            if (!minimoCobranca.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(minimoCobranca);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirMinimoCobrancaCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirMinimoCobrancaCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<MinimoCobranca> minimoCobrancas)
        {
            var index = 0;
            foreach (var minimoCobranca in minimoCobrancas)
            {

                minimoCobranca.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirMinimoCobrancaCommand>(index));
                index++;
            }
        }
    }
}