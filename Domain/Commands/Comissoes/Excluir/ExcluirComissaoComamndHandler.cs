using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Comissoes.Excluir
{
    public class ExcluirComissaoCommandHandler : IRequestHandler<ExcluirComissaoCommand, List<FormularioResponse<ExcluirComissaoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirComissaoCommand>> _response = new();

        public ExcluirComissaoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirComissaoCommand>>> Handle(ExcluirComissaoCommand command, CancellationToken cancellationToken)
        {
            var comissao = await _unitOfWork.ComissaoRepository.RetornarComissoesExcluirMassa(command.FiltroBase);

            if (!comissao.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(comissao);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirComissaoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirComissaoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Comissao> comissoes)
        {
            var index = 0;
            foreach (var comissao in comissoes)
            {

                comissao.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirComissaoCommand>(index));
                index++;
            }
        }
    }
}