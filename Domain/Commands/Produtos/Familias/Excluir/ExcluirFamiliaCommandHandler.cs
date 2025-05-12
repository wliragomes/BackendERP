using Domain.Constant;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Familias.Excluir
{
    public class ExcluirFamiliaCommandHandler : IRequestHandler<ExcluirFamiliaCommand, List<FormularioResponse<ExcluirFamiliaCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirFamiliaCommand>> _response = new();

        public ExcluirFamiliaCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirFamiliaCommand>>> Handle(ExcluirFamiliaCommand command, CancellationToken cancellationToken)
        {
            var familia = await _unitOfWork.FamiliaRepository.RetornarFamiliasExcluirMassa(command.FiltroBase);

            if (!familia.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(familia);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirFamiliaCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirFamiliaCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.Familia> familia)
        {
            var index = 0;
            foreach (var intem in familia)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirFamiliaCommand>(index));
                index++;
            }
        }
    }
}
