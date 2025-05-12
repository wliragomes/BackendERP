using Domain.Constant;
using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.NiveisAcessos.Excluir
{
    public class ExcluirNivelAcessoCommandHandler : IRequestHandler<ExcluirNivelAcessoCommand, List<FormularioResponse<ExcluirNivelAcessoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirNivelAcessoCommand>> _response = new();

        public ExcluirNivelAcessoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirNivelAcessoCommand>>> Handle(ExcluirNivelAcessoCommand command, CancellationToken cancellationToken)
        {
            var nivelacesso = await _unitOfWork.NivelAcessoRepository.RetornarNiveisAcessosExcluirMassa(command.FiltroBase);

            if (!nivelacesso.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(nivelacesso);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirNivelAcessoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirNivelAcessoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<NivelAcesso> Niveisacessos)
        {
            var index = 0;
            foreach (var Nivelacesso in Niveisacessos)
            {

                Nivelacesso.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirNivelAcessoCommand>(index));
                index++;
            }
        }
    }
}