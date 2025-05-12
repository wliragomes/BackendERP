using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cidades.Excluir
{
    public class ExcluirCidadeCommandHandler : IRequestHandler<ExcluirCidadeCommand, List<FormularioResponse<ExcluirCidadeCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirCidadeCommand>> _response = new();

        public ExcluirCidadeCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirCidadeCommand>>> Handle(ExcluirCidadeCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.CidadeRepository.RetornarCidadesExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirCidadeCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirCidadeCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Cidade> cidades)
        {
            var index = 0;
            foreach (var cidade in cidades)
            {

                cidade.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirCidadeCommand>(index));
                index++;
            }
        }
    }
}