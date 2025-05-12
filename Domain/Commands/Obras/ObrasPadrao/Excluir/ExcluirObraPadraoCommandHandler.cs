using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObrasPadrao.Excluir
{
    public class ExcluirObraPadraoCommandHandler : IRequestHandler<ExcluirObraPadraoCommand, List<FormularioResponse<ExcluirObraPadraoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirObraPadraoCommand>> _response = new();

        public ExcluirObraPadraoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirObraPadraoCommand>>> Handle(ExcluirObraPadraoCommand command, CancellationToken cancellationToken)
        {
            var obraPadrao = await _unitOfWork.ObraPadraoRepository.RetornarObrasPadraoExcluirMassa(command.FiltroBase);

            if (!obraPadrao.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(obraPadrao);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirObraPadraoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirObraPadraoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<ObraPadrao> obraPadraos)
        {
            var index = 0;
            foreach (var obraPadrao in obraPadraos)
            {

                obraPadrao.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirObraPadraoCommand>(index));
                index++;
            }
        }
    }
}