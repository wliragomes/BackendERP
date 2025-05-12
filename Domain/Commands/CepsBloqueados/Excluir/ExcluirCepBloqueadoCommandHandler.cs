using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.CepsBloqueados.Excluir
{
    public class ExcluirCepBloqueadoCommandHandler : IRequestHandler<ExcluirCepBloqueadoCommand, List<FormularioResponse<ExcluirCepBloqueadoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirCepBloqueadoCommand>> _response = new();

        public ExcluirCepBloqueadoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirCepBloqueadoCommand>>> Handle(ExcluirCepBloqueadoCommand command, CancellationToken cancellationToken)
        {
            var cepBloqueado = await _unitOfWork.CepBloqueadoRepository.RetornarCepsBloqueadosExcluirMassa(command.FiltroBase);

            if (!cepBloqueado.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(cepBloqueado);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirCepBloqueadoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirCepBloqueadoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<CepBloqueado> cepsBloqueados)
        {
            var index = 0;
            foreach (var cepBloqueado in cepsBloqueados)
            {

                cepBloqueado.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirCepBloqueadoCommand>(index));
                index++;
            }
        }
    }
}