using Domain.Constant;
using Domain.Entities.Contatos;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Departamentos.Excluir
{
    public class ExcluirDepartamentoCommandHandler : IRequestHandler<ExcluirDepartamentoCommand, List<FormularioResponse<ExcluirDepartamentoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirDepartamentoCommand>> _response = new();

        public ExcluirDepartamentoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirDepartamentoCommand>>> Handle(ExcluirDepartamentoCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.DepartamentoRepository.RetornarDepartamentosExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirDepartamentoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirDepartamentoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Departamento> Departamentos)
        {
            var index = 0;
            foreach (var checklist in Departamentos)
            {

                checklist.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirDepartamentoCommand>(index));
                index++;
            }
        }
    }
}