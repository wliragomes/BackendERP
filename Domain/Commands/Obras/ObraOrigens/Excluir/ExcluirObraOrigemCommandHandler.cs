using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObraOrigems.Excluir
{
    public class ExcluirObraOrigemCommandHandler : IRequestHandler<ExcluirObraOrigemCommand, List<FormularioResponse<ExcluirObraOrigemCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirObraOrigemCommand>> _response = new();

        public ExcluirObraOrigemCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirObraOrigemCommand>>> Handle(ExcluirObraOrigemCommand command, CancellationToken cancellationToken)
        {
            var obraFase = await _unitOfWork.ObraOrigemRepository.RetornarObraOrigemsExcluirMassa(command.FiltroBase);

            if (!obraFase.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(obraFase);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirObraOrigemCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirObraOrigemCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<ObraOrigem> obraFases)
        {
            var index = 0;
            foreach (var obraFase in obraFases)
            {

                obraFase.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirObraOrigemCommand>(index));
                index++;
            }
        }
    }
}