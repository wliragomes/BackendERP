using Domain.Constant;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.TiposPrecos.Excluir
{
    public class ExcluirTipoPrecoCommandHandler : IRequestHandler<ExcluirTipoPrecoCommand, List<FormularioResponse<ExcluirTipoPrecoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirTipoPrecoCommand>> _response = new();

        public ExcluirTipoPrecoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirTipoPrecoCommand>>> Handle(ExcluirTipoPrecoCommand command, CancellationToken cancellationToken)
        {
            var tipopreco = await _unitOfWork.TipoPrecoRepository.RetornarTiposPrecosExcluirMassa(command.FiltroBase);

            if (!tipopreco.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(tipopreco);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirTipoPrecoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirTipoPrecoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.TipoPreco> tipopreco)
        {
            var index = 0;
            foreach (var intem in tipopreco)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirTipoPrecoCommand>(index));
                index++;
            }
        }
    }
}
