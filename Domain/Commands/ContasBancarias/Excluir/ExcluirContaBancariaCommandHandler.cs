using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasBancarias.Excluir
{
    public class ExcluirContaBancariaCommandHandler : IRequestHandler<ExcluirContaBancariaCommand, List<FormularioResponse<ExcluirContaBancariaCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirContaBancariaCommand>> _response = new();

        public ExcluirContaBancariaCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirContaBancariaCommand>>> Handle(ExcluirContaBancariaCommand command, CancellationToken cancellationToken)
        {
            var contaBancaria = await _unitOfWork.ContaBancariaRepository.RetornarContasBancariasExcluirMassa(command.FiltroBase);

            if (!contaBancaria.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(contaBancaria);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirContaBancariaCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirContaBancariaCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<ContaBancaria> contasBancarias)
        {
            var index = 0;
            foreach (var contaBancaria in contasBancarias)
            {

                contaBancaria.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirContaBancariaCommand>(index));
                index++;
            }
        }
    }
}