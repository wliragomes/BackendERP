using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.CodigoDDIs.Excluir
{
    public class ExcluirCodigoDDICommandHandler : IRequestHandler<ExcluirCodigoDDICommand, List<FormularioResponse<ExcluirCodigoDDICommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirCodigoDDICommand>> _response = new();

        public ExcluirCodigoDDICommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirCodigoDDICommand>>> Handle(ExcluirCodigoDDICommand command, CancellationToken cancellationToken)
        {
            var codigoDDI = await _unitOfWork.CodigoDDIRepository.RetornarCodigoDDIsExcluirMassa(command.FiltroBase);

            if (!codigoDDI.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(codigoDDI);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirCodigoDDICommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirCodigoDDICommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<CodigoDDI> codigoDDIs)
        {
            var index = 0;
            foreach (var codigoDDI in codigoDDIs)
            {

                codigoDDI.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirCodigoDDICommand>(index));
                index++;
            }
        }
    }
}