using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Parametros.Atualizar
{
    public class AtualizarParametroCommandHandler : IRequestHandler<AtualizarParametroCommand, FormularioResponse<AtualizarParametroCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarParametroCommand> _validator;
        private const int _indice = 0;

        public AtualizarParametroCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarParametroCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarParametroCommand>> Handle(AtualizarParametroCommand command, CancellationToken cancellationToken)
        {
            // Validação do comando
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarParametroCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            // Obter o ParametroUpdate e validar se existe
            var parametroUpdate = await _unitOfWork.ParametroRepository.ObterPorId(command.Id);

            if (parametroUpdate == null)
            {
                response.AddError(new ValidationResult(new[]
                {
                    new ValidationFailure(nameof(command.Id), "Parâmetro não encontrado.")
                }));
                return response;
            }

            // Atualizar o parâmetro
            parametroUpdate.Update(
                command.Nome,
                command.Aba,
                command.Descricao,
                command.ExibirDescricao,
                command.BlocoDescricao,
                command.Descricao2,
                command.ExibirDescricao2,
                command.BlocoDescricao2,
                command.Valor,
                command.ExibirValor,
                command.BlocoValor,
                command.Valor2,
                command.ExibirValor2,
                command.BlocoValor2,
                command.Verdade,
                command.ExibirVerdade,
                command.BlocoVerdade,
                command.CaixaDeTexto,
                command.ExibirCaixaDeTexto,
                command.Criptografado,
                command.BlocoCaixaDeTexto,
                command.CaixaDeTexto2,
                command.ExibirCaixaDeTexto2,
                command.Criptografado2,
                command.BlocoCaixaDeTexto2,
                command.CaixaDeData,
                command.ExibirCaixaDeData,
                command.BlocoCaixaDeData,
                command.CaixaDeData2,
                command.ExibirCaixaDeData2,
                command.BlocoCaixaDeData2,
                command.Help,
                command.ExibirHelp,
                command.BlocoHelp
            );

            // Adicionar novas MedidasJumbo
            foreach (var novaMedidaJumbo in command.MedidaJumbo!)
            {
                // Verifica se a medida já existe (opcional, para evitar duplicatas)
                var existeMedida = await _unitOfWork.MedidaJumboRepository.ObterPorId(novaMedidaJumbo.Id);
                if (existeMedida == null)
                {
                    var novaEntidadeMedidaJumbo = new MedidaJumbo(
                        novaMedidaJumbo.Ordem,
                        novaMedidaJumbo.Habilitar,
                        novaMedidaJumbo.Altura,
                        novaMedidaJumbo.Largura
                    );

                    await _unitOfWork.MedidaJumboRepository.Adicionar(novaEntidadeMedidaJumbo);
                }
            }

            // Persistir alterações
            await _unitOfWork.CommitAsync(cancellationToken);

            // Retornar o comando atualizado na resposta
            var commandAtualizado = new AtualizarParametroCommand(
                command.Id,
                command.Nome,
                command.Aba,
                command.Descricao,
                command.ExibirDescricao,
                command.BlocoDescricao,
                command.Descricao2,
                command.ExibirDescricao2,
                command.BlocoDescricao2,
                command.Valor,
                command.ExibirValor,
                command.BlocoValor,
                command.Valor2,
                command.ExibirValor2,
                command.BlocoValor2,
                command.Verdade,
                command.ExibirVerdade,
                command.BlocoVerdade,
                command.CaixaDeTexto,
                command.ExibirCaixaDeTexto,
                command.Criptografado,
                command.BlocoCaixaDeTexto,
                command.CaixaDeTexto2,
                command.ExibirCaixaDeTexto2,
                command.Criptografado2,
                command.BlocoCaixaDeTexto2,
                command.CaixaDeData,
                command.ExibirCaixaDeData,
                command.BlocoCaixaDeData,
                command.CaixaDeData2,
                command.ExibirCaixaDeData2,
                command.BlocoCaixaDeData2,
                command.Help,
                command.ExibirHelp,
                command.BlocoHelp
            );

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
