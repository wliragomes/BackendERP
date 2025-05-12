using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.PlanosDeContas.Atualizar
{
    public class AtualizarPlanoDeContasCommandHandler : IRequestHandler<AtualizarPlanoDeContasCommand, FormularioResponse<AtualizarPlanoDeContasCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarPlanoDeContasCommand> _validator;
        private const int _indice = 0;

        public AtualizarPlanoDeContasCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarPlanoDeContasCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarPlanoDeContasCommand>> Handle(AtualizarPlanoDeContasCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarPlanoDeContasCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            // Validações específicas do plano de contas
            var existeAnterior = await ExistePlanoDeContaAnteriorAsync(RemoverUltimoGrupoSeZero(ObterValorAnterior(command.PlanoDeContasCompleto)), command.Id);
            var ehUnico = await EhPlanoDeContaUnicoAsync(command);

            if (!existeAnterior || !ehUnico)
            {
                response.AddError("Plano De Contas Completo", "Valor incorreto.", command.PlanoDeContasCompleto);
                return response;
            }

            var planoDeContasUpdate = await _unitOfWork.PlanoDeContasRepository.ObterPorId(command.Id);
            if (planoDeContasUpdate == null)
            {
                response.AddError("Id", "Plano de contas não encontrado.", command.Id);
                return response;
            }

            planoDeContasUpdate.Update(
                command.PlanoDeContasCompleto,
                command.ContaPrincipal,
                command.SubGrupo,
                command.Analitico,
                command.AnaliticoDetalhado,
                command.Especifico,
                command.PositivoNegativo,
                command.Conta,
                command.Natureza,
                command.Nivel);

            await _unitOfWork.CommitAsync(cancellationToken);
            response.SetFormulario(command);
            return response;
        }

        private async Task<bool> ExistePlanoDeContaAnteriorAsync(string planoDeContasCompleto, Guid? id)
        {
            return await _unitOfWork.PlanoDeContasRepository.ExistePlanoDeContaAsync(planoDeContasCompleto, id);
        }

        private async Task<bool> EhPlanoDeContaUnicoAsync(AtualizarPlanoDeContasCommand command)
        {
            var existePlano = await _unitOfWork.PlanoDeContasRepository.RetornarValidacao(command);
            return existePlano == null || existePlano.Id == command.Id;
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

            int ultimoIndex = partes.Length - 1;

            if (int.TryParse(partes[ultimoIndex], out int ultimoValor))
            {
                if (ultimoValor > 0)
                {
                    string valorAnterior = (ultimoValor - 1).ToString().PadLeft(partes[ultimoIndex].Length, '0');
                    partes[ultimoIndex] = valorAnterior;
                    return string.Join(".", partes);
                }
                else
                {
                    return string.Join(".", partes.Take(ultimoIndex));
                }
            }

            return plano;
        }
    }
}