using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cartoes.Excluir
{
    public class ExcluirCartaoCommandHandler : IRequestHandler<ExcluirCartaoCommand, List<FormularioResponse<ExcluirCartaoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirCartaoCommand>> _response = new();

        public ExcluirCartaoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirCartaoCommand>>> Handle(ExcluirCartaoCommand command, CancellationToken cancellationToken)
        {
            var cartao = await _unitOfWork.CartaoRepository.RetornarCartoesExcluirMassa(command.FiltroBase);

            if (!cartao.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(cartao);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirCartaoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirCartaoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Cartao> cartoes)
        {
            var index = 0;
            foreach (var cartao in cartoes)
            {

                cartao.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirCartaoCommand>(index));
                index++;
            }
        }
    }
}