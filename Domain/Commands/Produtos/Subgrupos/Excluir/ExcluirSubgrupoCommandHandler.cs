using Domain.Constant;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Subgrupos.Excluir
{
    public class ExcluirSubgrupoCommandHandler : IRequestHandler<ExcluirSubgrupoCommand, List<FormularioResponse<ExcluirSubgrupoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirSubgrupoCommand>> _response = new();

        public ExcluirSubgrupoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirSubgrupoCommand>>> Handle(ExcluirSubgrupoCommand command, CancellationToken cancellationToken)
        {
            var subgrupo = await _unitOfWork.SubgrupoRepository.RetornarSubGruposExcluirMassa(command.FiltroBase);

            if (!subgrupo.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(subgrupo);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirSubgrupoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirSubgrupoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.Subgrupo> subgrupo)
        {
            var index = 0;
            foreach (var intem in subgrupo)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirSubgrupoCommand>(index));
                index++;
            }
        }
    }
}
