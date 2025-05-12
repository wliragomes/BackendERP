using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.RegimeTributarios.Excluir
{
    public class ExcluirRegimeTributarioCommandHandler : IRequestHandler<ExcluirRegimeTributarioCommand, List<FormularioResponse<ExcluirRegimeTributarioCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirRegimeTributarioCommand>> _response = new();

        public ExcluirRegimeTributarioCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirRegimeTributarioCommand>>> Handle(ExcluirRegimeTributarioCommand command, CancellationToken cancellationToken)
        {
            var regimeTributario = await _unitOfWork.RegimeTributarioRepository.RetornarRegimeTributariosExcluirMassa(command.FiltroBase);

            if (!regimeTributario.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(regimeTributario);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirRegimeTributarioCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirRegimeTributarioCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<RegimeTributario> regimeTributarios)
        {
            var index = 0;
            foreach (var regimeTributario in regimeTributarios)
            {

                regimeTributario.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirRegimeTributarioCommand>(index));
                index++;
            }
        }
    }
}