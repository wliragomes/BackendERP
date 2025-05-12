using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.FaturaParametros.Excluir
{
    public class ExcluirFaturaParametroCommandHandler : IRequestHandler<ExcluirFaturaParametroCommand, List<FormularioResponse<ExcluirFaturaParametroCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirFaturaParametroCommand>> _response = new();

        public ExcluirFaturaParametroCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirFaturaParametroCommand>>> Handle(ExcluirFaturaParametroCommand command, CancellationToken cancellationToken)
        {
            var faturaParametro = await _unitOfWork.FaturaParametroRepository.RetornarFaturaParametrosExcluirMassa(command.FiltroBase);

            if (!faturaParametro.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(faturaParametro);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirFaturaParametroCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirFaturaParametroCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<FaturaParametro> faturaParametros)
        {
            var index = 0;
            foreach (var faturaParametro in faturaParametros)
            {

                faturaParametro.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirFaturaParametroCommand>(index));
                index++;
            }
        }
    }
}