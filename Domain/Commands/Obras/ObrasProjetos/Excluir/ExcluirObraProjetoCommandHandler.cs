using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObrasProjetos.Excluir
{
    public class ExcluirObraProjetoCommandHandler : IRequestHandler<ExcluirObraProjetoCommand, List<FormularioResponse<ExcluirObraProjetoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirObraProjetoCommand>> _response = new();

        public ExcluirObraProjetoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirObraProjetoCommand>>> Handle(ExcluirObraProjetoCommand command, CancellationToken cancellationToken)
        {
            var obraProjeto = await _unitOfWork.ObraProjetoRepository.RetornarObrasProjetosExcluirMassa(command.FiltroBase);

            if (!obraProjeto.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(obraProjeto);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirObraProjetoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirObraProjetoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<ObraProjeto> obraProjetos)
        {
            var index = 0;
            foreach (var obraProjeto in obraProjetos)
            {

                obraProjeto.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirObraProjetoCommand>(index));
                index++;
            }
        }
    }
}