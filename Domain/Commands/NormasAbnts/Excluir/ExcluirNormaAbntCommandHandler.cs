using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.NormasAbnts.Excluir
{
    public class ExcluirNormaAbntCommandHandler : IRequestHandler<ExcluirNormaAbntCommand, List<FormularioResponse<ExcluirNormaAbntCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirNormaAbntCommand>> _response = new();

        public ExcluirNormaAbntCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirNormaAbntCommand>>> Handle(ExcluirNormaAbntCommand command, CancellationToken cancellationToken)
        {
            var normaAbnt = await _unitOfWork.NormaAbntRepository.RetornarNormasAbntsExcluirMassa(command.FiltroBase);

            if (!normaAbnt.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(normaAbnt);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirNormaAbntCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirNormaAbntCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<NormaAbnt> normasAbnts)
        {
            var index = 0;
            foreach (var normaAbnt in normasAbnts)
            {

                normaAbnt.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirNormaAbntCommand>(index));
                index++;
            }
        }
    }
}