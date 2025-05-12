using Domain.Constant;
using Domain.Entities.Cfops;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cfops.Excluir
{
    public class ExcluirCfopCommandHandler : IRequestHandler<ExcluirCfopCommand, List<FormularioResponse<ExcluirCfopCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirCfopCommand>> _response = new();

        public ExcluirCfopCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirCfopCommand>>> Handle(ExcluirCfopCommand command, CancellationToken cancellationToken)
        {
            var cfop = await _unitOfWork.CfopRepository.RetornarCfopsExcluirMassa(command.FiltroBase);

            if (!cfop.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(cfop);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirCfopCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirCfopCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Cfop> cfops)
        {
            var index = 0;
            foreach (var cfop in cfops)
            {

                cfop.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirCfopCommand>(index));
                index++;
            }
        }
    }
}