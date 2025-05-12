using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Bancos.Excluir
{
    public class ExcluirBancoCommandHandler : IRequestHandler<ExcluirBancoCommand, List<FormularioResponse<ExcluirBancoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirBancoCommand>> _response = new();

        public ExcluirBancoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirBancoCommand>>> Handle(ExcluirBancoCommand command, CancellationToken cancellationToken)
        {
            var banco = await _unitOfWork.BancoRepository.RetornarBancosExcluirMassa(command.FiltroBase);

            if (!banco.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(banco);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirBancoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirBancoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Banco> bancos)
        {
            var index = 0;
            foreach (var banco in bancos)
            {

                banco.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirBancoCommand>(index));
                index++;
            }
        }
    }
}