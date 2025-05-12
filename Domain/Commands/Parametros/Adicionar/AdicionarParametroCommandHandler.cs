using Domain.Commands.MedidasJumbo;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Parametros.Adicionar
{
    public class AdicionarParametroCommandHandler : IRequestHandler<AdicionarParametroCommand, FormularioResponse<AdicionarParametroCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AdicionarParametroCommand> _validator;
        private const int _indice = 0;

        public AdicionarParametroCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarParametroCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarParametroCommand>> Handle(AdicionarParametroCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarParametroCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            // Criar o parâmetro principal
            Parametro parametro = new
            (
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

            // Criar as MedidasJumbo associadas ao parâmetro
            var medidasJumbo = CriarMedidasJumbo(command.MedidaJumbo!, parametro.Id);

            // Adicionar as MedidasJumbo ao repositório
            foreach (var medida in medidasJumbo)
            {
                await _unitOfWork.MedidaJumboRepository.Adicionar(medida);
            }

            // Adicionar o parâmetro ao repositório
            await _unitOfWork.ParametroRepository.Adicionar(parametro);

            // Setar o ID do parâmetro criado na resposta
            response.Formulario!.SetId(parametro.Id);

            // Commit das alterações
            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }

        // Método para criar uma lista de MedidasJumbo a partir do comando
        private static List<MedidaJumbo> CriarMedidasJumbo(IEnumerable<MedidaJumboCommand> medidasJumboCommands, Guid parametroId)
        {
            return medidasJumboCommands.Select(medida => new MedidaJumbo(
                medida.Ordem,
                medida.Habilitar,
                medida.Altura,
                medida.Largura
            )).ToList();
        }
    }
}
