using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Ncms.Atualizar
{
    public class AtualizarNcmCommandHandler : IRequestHandler<AtualizarNcmCommand, FormularioResponse<AtualizarNcmCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarNcmCommand> _validator;
        private const int _indice = 0;

        public AtualizarNcmCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarNcmCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarNcmCommand>> Handle(AtualizarNcmCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarNcmCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var NcmUpdate = await _unitOfWork.NcmRepository.ObterPorId(command.Id);
            NcmUpdate!.Update(
                command.NrNcm01, 
                command.NrNcm02, 
                command.NrNcm03, 
                command.NrNcmCompleta, 
                command.Descricao, 
                command.Aliquota,
                command.InsiteSt,
                command.AliquotaSt);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarNcmCommand(
                command.Id,
                command.NrNcm01,
                command.NrNcm02,
                command.NrNcm03,
                command.NrNcmCompleta,
                command.Descricao,
                command.Aliquota,
                command.InsiteSt, 
                command.AliquotaSt);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
