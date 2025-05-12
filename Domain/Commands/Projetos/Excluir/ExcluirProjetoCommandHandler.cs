using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Projetos.Excluir
{
    public class ExcluirProjetoCommandHandler : IRequestHandler<ExcluirProjetoCommand, List<FormularioResponse<ExcluirProjetoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirProjetoCommand>> _response = new();

        public ExcluirProjetoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirProjetoCommand>>> Handle(ExcluirProjetoCommand command, CancellationToken cancellationToken)
        {
            var projeto = await _unitOfWork.ProjetoRepository.RetornarProjetosExcluirMassa(command.FiltroBase);

            if (!projeto.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(projeto);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirProjetoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirProjetoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Projeto> projetos)
        {
            var index = 0;
            foreach (var projeto in projetos)
            {

                projeto.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirProjetoCommand>(index));
                index++;
            }
        }
    }
}