using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Representantes.Excluir
{
    public class ExcluirRepresentanteCommandHandler : IRequestHandler<ExcluirRepresentanteCommand, List<FormularioResponse<ExcluirRepresentanteCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirRepresentanteCommand>> _response = new();

        public ExcluirRepresentanteCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirRepresentanteCommand>>> Handle(ExcluirRepresentanteCommand command, CancellationToken cancellationToken)
        {
            var representante = await _unitOfWork.RepresentanteRepository.RetornarRepresentantesExcluirMassa(command.FiltroBase);

            if (!representante.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(representante);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirRepresentanteCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirRepresentanteCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Representante> representantes)
        {
            var index = 0;
            foreach (var representante in representantes)
            {

                representante.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirRepresentanteCommand>(index));
                index++;
            }
        }
    }
}