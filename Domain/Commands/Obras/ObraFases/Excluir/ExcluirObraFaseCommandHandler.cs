using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObraFases.Excluir
{
    public class ExcluirObraFaseCommandHandler : IRequestHandler<ExcluirObraFaseCommand, List<FormularioResponse<ExcluirObraFaseCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirObraFaseCommand>> _response = new();

        public ExcluirObraFaseCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirObraFaseCommand>>> Handle(ExcluirObraFaseCommand command, CancellationToken cancellationToken)
        {
            var obraFase = await _unitOfWork.ObraFaseRepository.RetornarObraFasesExcluirMassa(command.FiltroBase);

            if (!obraFase.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(obraFase);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirObraFaseCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirObraFaseCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<ObraFase> obraFases)
        {
            var index = 0;
            foreach (var obraFase in obraFases)
            {

                obraFase.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirObraFaseCommand>(index));
                index++;
            }
        }
    }
}