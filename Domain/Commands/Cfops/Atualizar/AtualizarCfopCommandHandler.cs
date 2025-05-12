using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cfops.Atualizar
{
    public class AtualizarCfopCommandHandler : IRequestHandler<AtualizarCfopCommand, FormularioResponse<AtualizarCfopCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarCfopCommand> _validator;
        private const int _indice = 0;

        public AtualizarCfopCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarCfopCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarCfopCommand>> Handle(AtualizarCfopCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarCfopCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var CfopUpdate = await _unitOfWork.CfopRepository.ObterPorId(command.Id);
            CfopUpdate!.Update(
                command.CodigoAmigavel,
                command.CodigoLetra,
                command.CodigoCfopLetra,
                command.DsResumida,
                command.DsDetalhada,
                command.EntradaSaida,
                command.DadosAdicionaisIcms,
                command.DadosAdicionaisIpi,
                command.IdCstIcmsOrigemMaterial,
                command.IdCstIcms,
                command.IdCstIpi,
                command.IdCstPis,
                command.IdCstCofins,
                command.Comissao,
                command.Duplicata,
                command.Resumo,
                command.TaxaForaEstado,
                command.Retorno,
                command.Devolucao,
                command.Mercadoria,
                command.Producao,
                command.VendaOrdem,
                command.FaturaAutomatica,
                command.ZerarValor,
                command.Difal
                );

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarCfopCommand(
                command.Id,
                command.CodigoAmigavel,
                command.CodigoLetra,
                command.CodigoCfopLetra,
                command.DsResumida,
                command.DsDetalhada,
                command.EntradaSaida,
                command.DadosAdicionaisIcms,
                command.DadosAdicionaisIpi,
                command.IdCstIcmsOrigemMaterial,
                command.IdCstIcms,
                command.IdCstIpi,
                command.IdCstPis,
                command.IdCstCofins,
                command.Comissao,
                command.Duplicata,
                command.Resumo,
                command.TaxaForaEstado,
                command.Retorno,
                command.Devolucao,
                command.Mercadoria,
                command.Producao,
                command.VendaOrdem,
                command.FaturaAutomatica,
                command.ZerarValor,
                command.Difal
                );

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
