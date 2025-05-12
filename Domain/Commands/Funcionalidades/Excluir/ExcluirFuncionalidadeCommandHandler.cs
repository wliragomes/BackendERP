using Domain.Constant;
using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Funcionalidades.Excluir
{
    public class ExcluirFuncionalidadeCommandHandler : IRequestHandler<ExcluirFuncionalidadeCommand, List<FormularioResponse<ExcluirFuncionalidadeCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirFuncionalidadeCommand>> _response = new();

        public ExcluirFuncionalidadeCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirFuncionalidadeCommand>>> Handle(ExcluirFuncionalidadeCommand command, CancellationToken cancellationToken)
        {
            var funcionalidade = await _unitOfWork.FuncionalidadeRepository.RetornarFuncionalidadesExcluirMassa(command.FiltroBase);

            if (!funcionalidade.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(funcionalidade);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirFuncionalidadeCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirFuncionalidadeCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Funcionalidade> funcionalidades)
        {
            var index = 0;
            foreach (var funcionalidade in funcionalidades)
            {

                funcionalidade.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirFuncionalidadeCommand>(index));
                index++;
            }
        }
    }
}