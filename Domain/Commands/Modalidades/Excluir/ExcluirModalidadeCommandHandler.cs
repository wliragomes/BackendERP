using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Modalidades.Excluir
{
    public class ExcluirModalidadeCommandHandler : IRequestHandler<ExcluirModalidadeCommand, List<FormularioResponse<ExcluirModalidadeCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirModalidadeCommand>> _response = new();

        public ExcluirModalidadeCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirModalidadeCommand>>> Handle(ExcluirModalidadeCommand command, CancellationToken cancellationToken)
        {
            var modalidade = await _unitOfWork.ModalidadeRepository.RetornarModalidadesExcluirMassa(command.FiltroBase);

            if (!modalidade.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(modalidade);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirModalidadeCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirModalidadeCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Modalidade> modalidades)
        {
            var index = 0;
            foreach (var modalidade in modalidades)
            {

                modalidade.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirModalidadeCommand>(index));
                index++;
            }
        }
    }
}