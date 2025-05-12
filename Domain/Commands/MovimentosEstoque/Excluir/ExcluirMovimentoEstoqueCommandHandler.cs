using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MovimentosEstoque.Excluir
{
    public class ExcluirMovimentoEstoqueCommandHandler : IRequestHandler<ExcluirMovimentoEstoqueCommand, List<FormularioResponse<ExcluirMovimentoEstoqueCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirMovimentoEstoqueCommand>> _response = new();

        public ExcluirMovimentoEstoqueCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirMovimentoEstoqueCommand>>> Handle(ExcluirMovimentoEstoqueCommand command, CancellationToken cancellationToken)
        {
            var movimentoEstoque = await _unitOfWork.MovimentoEstoqueRepository.RetornarMovimentosEstoqueExcluirMassa(command.FiltroBase);

            if (!movimentoEstoque.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(movimentoEstoque);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirMovimentoEstoqueCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirMovimentoEstoqueCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<MovimentoEstoque> movimentosEstoque)
        {
            var index = 0;
            foreach (var movimentoEstoque in movimentosEstoque)
            {

                movimentoEstoque.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirMovimentoEstoqueCommand>(index));
                index++;
            }
        }
    }
}