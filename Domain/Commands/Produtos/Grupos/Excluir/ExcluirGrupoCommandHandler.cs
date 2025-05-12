using Domain.Constant;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Grupos.Excluir
{
    public class ExcluirGrupoCommandHandler : IRequestHandler<ExcluirGrupoCommand, List<FormularioResponse<ExcluirGrupoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirGrupoCommand>> _response = new();

        public ExcluirGrupoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirGrupoCommand>>> Handle(ExcluirGrupoCommand command, CancellationToken cancellationToken)
        {
            var grupo = await _unitOfWork.GrupoRepository.RetornarGruposExcluirMassa(command.FiltroBase);

            if (!grupo.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(grupo);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirGrupoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirGrupoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.Grupo> grupo)
        {
            var index = 0;
            foreach (var intem in grupo)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirGrupoCommand>(index));
                index++;
            }
        }
    }
}
