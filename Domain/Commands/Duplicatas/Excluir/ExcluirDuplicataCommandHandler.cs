using Domain.Commands.ContasAPagar.Excluir;
using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Duplicatas.Excluir
{
    public class ExcluirDuplicataCommandHandler : IRequestHandler<ExcluirDuplicataCommand, List<FormularioResponse<ExcluirDuplicataCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirDuplicataCommand>> _response = new();

        public ExcluirDuplicataCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirDuplicataCommand>>> Handle(ExcluirDuplicataCommand command, CancellationToken cancellationToken)
        {
            var duplicata = await _unitOfWork.DuplicataRepository.RetornarDuplicatasExcluirMassa(command.FiltroBase);

            if (!duplicata.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(duplicata);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirDuplicataCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirDuplicataCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Duplicata> duplicatas)
        {
            var index = 0;
            foreach (var duplicata in duplicatas)
            {

                duplicata.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirDuplicataCommand>(index));
                index++;
            }
        }
    }
}