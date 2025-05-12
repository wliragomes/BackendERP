using Domain.Constant;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Ruas.Excluir
{
    public class ExcluirRuaCommandHandler : IRequestHandler<ExcluirRuaCommand, List<FormularioResponse<ExcluirRuaCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirRuaCommand>> _response = new();

        public ExcluirRuaCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirRuaCommand>>> Handle(ExcluirRuaCommand command, CancellationToken cancellationToken)
        {
            var rua = await _unitOfWork.RuaRepository.RetornarRuasExcluirMassa(command.FiltroBase);

            if (!rua.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(rua);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirRuaCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirRuaCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.Rua> rua)
        {
            var index = 0;
            foreach (var intem in rua)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirRuaCommand>(index));
                index++;
            }
        }
    }
}
