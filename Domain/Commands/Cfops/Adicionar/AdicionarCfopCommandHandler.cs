using Domain.Entities.Cfops;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cfops.Adicionar
{
    public class AdicionarCfopCommandHandler : IRequestHandler<AdicionarCfopCommand, FormularioResponse<AdicionarCfopCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AdicionarCfopCommand> _validator;
        private const int _indece = 0;

        public AdicionarCfopCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarCfopCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarCfopCommand>> Handle(AdicionarCfopCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarCfopCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Cfop? cfopExistente = await _unitOfWork.CfopRepository.ExisteCodigoAmigavel(command.CodigoAmigavel);

            if (cfopExistente != null)
            {
                string nextCodigoLetra = GetNextCodigoLetra(cfopExistente.CodigoLetra!);
                command.CodigoLetra = nextCodigoLetra;
            }
            else
            {
                command.CodigoLetra = "A";
            }

            Cfop cfop = new
            (
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

            // Adiciona o novo CFOP ao repositório
            await _unitOfWork.CfopRepository.Adicionar(cfop);
            response.Formulario!.SetId(cfop.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }

        private string GetNextCodigoLetra(string currentCodigoLetra)
        {
            // Lógica para pegar a próxima letra do alfabeto
            char nextLetter = (char)(currentCodigoLetra[0] + 1);

            // Verificar se passou de 'Z'
            if (nextLetter > 'Z')
            {
                // Lógica de overflow de 'Z' para 'A' (você pode personalizar essa lógica para 'AA' etc.)
                nextLetter = 'A';  // Reinicia para 'A' (você pode personalizar essa lógica para 'AA' etc.)
            }

            return nextLetter.ToString();
        }
    }
}
