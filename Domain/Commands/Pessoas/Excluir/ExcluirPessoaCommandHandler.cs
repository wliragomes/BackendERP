using Domain.Constant;
using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Pessoas.Excluir
{
    public class ExcluirPessoaCommandHandler : IRequestHandler<ExcluirPessoaCommand, List<FormularioResponse<ExcluirPessoaCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirPessoaCommand>> _response = new();

        public ExcluirPessoaCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirPessoaCommand>>> Handle(ExcluirPessoaCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.PessoaRepository.RetornarPessoasExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirPessoaCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirPessoaCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Pessoa> pessoas)
        {
            var index = 0;
            foreach (var checklist in pessoas)
            {

                checklist.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirPessoaCommand>(index));
                index++;
            }
        }
    }
}