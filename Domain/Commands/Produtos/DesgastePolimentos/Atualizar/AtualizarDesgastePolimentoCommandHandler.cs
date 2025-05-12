using Domain.Commands.Produtos.AtualizarDesgastes.Atualizar;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

public class AtualizarDesgastePolimentoCommandHandler : IRequestHandler<AtualizarDesgastePolimentoCommand, FormularioResponse<AtualizarDesgastePolimentoCommand>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<AtualizarDesgastePolimentoCommand> _validator;
    private const int _indice = 0;

    public AtualizarDesgastePolimentoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarDesgastePolimentoCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<FormularioResponse<AtualizarDesgastePolimentoCommand>> Handle(AtualizarDesgastePolimentoCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        var response = new FormularioResponse<AtualizarDesgastePolimentoCommand>(_indice, command, validationResult);

        if (!validationResult.IsValid || response.ExisteErro())
            return response;

        var desgastePolimentoUpdate = await _unitOfWork.DesgastePolimentoRepository.ObterPorId(command.Id);
        
        desgastePolimentoUpdate!.Update(command.EspessuraVidroMinimo,
                                        command.EspessuraVidroMaximo,
                                        command.QuantidadeDesgasteLado,
                                        command.QuantidadeDesgasteTotal);


        await _unitOfWork.CommitAsync(cancellationToken);

        var commandAtualizado = new AtualizarDesgastePolimentoCommand(
            command.Id,
            command.EspessuraVidroMinimo,
            command.EspessuraVidroMaximo,
            command.QuantidadeDesgasteLado,
            command.QuantidadeDesgasteTotal);

        response.SetFormulario(commandAtualizado);
        return response;
    }
}
