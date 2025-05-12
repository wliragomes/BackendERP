using Domain.Constant;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.CodigosImportacoes.Excluir
{
    public class ExcluirCodigoImportacaoCommandHandler : IRequestHandler<ExcluirCodigoImportacaoCommand, List<FormularioResponse<ExcluirCodigoImportacaoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirCodigoImportacaoCommand>> _response = new();

        public ExcluirCodigoImportacaoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirCodigoImportacaoCommand>>> Handle(ExcluirCodigoImportacaoCommand command, CancellationToken cancellationToken)
        {
            var codigo = await _unitOfWork.CodigoImportacaoRepository.RetornarCodigoImportacaoExcluirMassa(command.FiltroBase);

            if (!codigo.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(codigo);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirCodigoImportacaoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirCodigoImportacaoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.CodigoImportacao> codigo)
        {
            var index = 0;
            foreach (var intem in codigo)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirCodigoImportacaoCommand>(index));
                index++;
            }
        }
    }
}
