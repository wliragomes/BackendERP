using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Empresas.Excluir
{
    public class ExcluirEmpresaCommandHandler : IRequestHandler<ExcluirEmpresaCommand, List<FormularioResponse<ExcluirEmpresaCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirEmpresaCommand>> _response = new();

        public ExcluirEmpresaCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirEmpresaCommand>>> Handle(ExcluirEmpresaCommand command, CancellationToken cancellationToken)
        {
            var empresa = await _unitOfWork.EmpresaRepository.RetornarEmpresasExcluirMassa(command.FiltroBase);

            if (!empresa.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(empresa);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirEmpresaCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirEmpresaCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Empresa> empresas)
        {
            var index = 0;
            foreach (var empresa in empresas)
            {

                empresa.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirEmpresaCommand>(index));
                index++;
            }
        }
    }
}