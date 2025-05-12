using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Acabamentos.Excluir
{
    public class ExcluirAcabamentoCommandHandler : IRequestHandler<ExcluirAcabamentoCommand, List<FormularioResponse<ExcluirAcabamentoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirAcabamentoCommand>> _response = new();

        public ExcluirAcabamentoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirAcabamentoCommand>>> Handle(ExcluirAcabamentoCommand command, CancellationToken cancellationToken)
        {
            var acabamento = await _unitOfWork.AcabamentoRepository.RetornarAcabamentosExcluirMassa(command.FiltroBase);

            if (!acabamento.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(acabamento);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirAcabamentoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirAcabamentoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Acabamento> acabamentos)
        {
            var index = 0;
            foreach (var acabamento in acabamentos)
            {

                acabamento.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirAcabamentoCommand>(index));
                index++;
            }
        }
    }
}