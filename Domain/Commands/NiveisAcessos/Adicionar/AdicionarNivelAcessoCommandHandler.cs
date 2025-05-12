using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.NiveisAcessos.Adicionar
{
    public class AdicionarNivelAcessoCommandHandler : IRequestHandler<AdicionarNivelAcessoCommand, FormularioResponse<AdicionarNivelAcessoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarNivelAcessoCommand> _validator;
        private const int _indece = 0;

        public AdicionarNivelAcessoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarNivelAcessoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarNivelAcessoCommand>> Handle(AdicionarNivelAcessoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarNivelAcessoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            NivelAcesso nivelacesso = new
            (
                command.Codigo,
                command.Nome
            );
            {

                await _unitOfWork.NivelAcessoRepository.Adicionar(nivelacesso);
                response.Formulario!.SetId(nivelacesso.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
