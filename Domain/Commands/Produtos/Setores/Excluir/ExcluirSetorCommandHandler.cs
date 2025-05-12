using Domain.Constant;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Setores.Excluir
{
    public class ExcluirSetorCommandHandler : IRequestHandler<ExcluirSetorCommand, List<FormularioResponse<ExcluirSetorCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirSetorCommand>> _response = new();

        public ExcluirSetorCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirSetorCommand>>> Handle(ExcluirSetorCommand command, CancellationToken cancellationToken)
        {
            var setor = await _unitOfWork.SetorRepository.RetornarSetoresExcluirMassa(command.FiltroBase);

            if (!setor.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(setor);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirSetorCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirSetorCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.Setor> setor)
        {
            var index = 0;
            foreach (var intem in setor)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirSetorCommand>(index));
                index++;
            }
        }
    }
}