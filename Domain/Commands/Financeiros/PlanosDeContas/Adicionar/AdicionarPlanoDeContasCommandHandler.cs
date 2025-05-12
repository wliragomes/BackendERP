using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.PlanosDeContas.Adicionar
{
    public class AdicionarPlanoDeContasCommandHandler : IRequestHandler<AdicionarPlanoDeContasCommand, FormularioResponse<AdicionarPlanoDeContasCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarPlanoDeContasCommand> _validator;
        private const int _indece = 0;

        public AdicionarPlanoDeContasCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarPlanoDeContasCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarPlanoDeContasCommand>> Handle(AdicionarPlanoDeContasCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarPlanoDeContasCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            //validação
            var existeAnterior = await ExistePlanoDeContaAnteriorAsync(RemoverUltimoGrupoSeZero(ObterValorAnterior(command.PlanoDeContasCompleto)), null);
            var ehUnico = await EhPlanoDeContaUnicoAsync(command);

            if (!existeAnterior || !ehUnico)
            {
                response.AddError("Plano De Contas Completo", "Valor incorreto.", command.PlanoDeContasCompleto);
                return response;
            }

            PlanoDeContas planoDeContas = new
            (
                command.PlanoDeContasCompleto,
                command.ContaPrincipal,
                command.SubGrupo,
                command.Analitico,
                command.AnaliticoDetalhado,
                command.Especifico,
                command.PositivoNegativo,
                command.Conta,
                command.Natureza,
                command.Nivel
            );

            await _unitOfWork.PlanoDeContasRepository.Adicionar(planoDeContas);
            response.Formulario!.SetId(planoDeContas.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }

        private async Task<bool> ExistePlanoDeContaAnteriorAsync(string planoDeContasCompleto, Guid? id)
        {
            // Retorna true se o plano anterior já está no banco
            return await _unitOfWork.PlanoDeContasRepository.ExistePlanoDeContaAsync(planoDeContasCompleto, id);
        }

        private async Task<bool> EhPlanoDeContaUnicoAsync(AdicionarPlanoDeContasCommand command)
        {
            // Retorna true se NÃO existir nenhum outro plano com os mesmos dados
            var existePlano = await _unitOfWork.PlanoDeContasRepository.RetornarValidacao(command);
            return existePlano == null;
        }

        private string RemoverUltimoGrupoSeZero(string plano)
        {
            if (string.IsNullOrWhiteSpace(plano))
                return string.Empty;

            var partes = plano.Split('.');
            int ultimoIndex = partes.Length - 1;

            if (int.TryParse(partes[ultimoIndex], out int valorUltimoGrupo) && valorUltimoGrupo == 0)
            {
                // Remove o último grupo e retorna o restante
                return string.Join(".", partes.Take(ultimoIndex));
            }

            return plano;
        }

        public string ObterValorAnterior(string plano)
        {
            if (string.IsNullOrWhiteSpace(plano))
                return string.Empty;

            var partes = plano.Split('.');

            // Se só tem um nível, decrementa o número
            if (partes.Length == 1)
            {
                if (int.TryParse(partes[0], out int valor))
                    return (valor - 1).ToString();
                else
                    return plano;
            }

            // Se tem múltiplos níveis
            int ultimoIndex = partes.Length - 1;

            // Tenta converter a última parte para número
            if (int.TryParse(partes[ultimoIndex], out int ultimoValor))
            {
                if (ultimoValor > 0)
                {
                    // Mantém o número de dígitos com padding à esquerda
                    string valorAnterior = (ultimoValor - 1).ToString().PadLeft(partes[ultimoIndex].Length, '0');
                    partes[ultimoIndex] = valorAnterior;
                    return string.Join(".", partes);
                }
                else
                {
                    // Se o último valor for 0, remove o nível
                    return string.Join(".", partes.Take(ultimoIndex));
                }
            }

            return plano; // Caso não seja número, retorna o original
        }

    }
}
