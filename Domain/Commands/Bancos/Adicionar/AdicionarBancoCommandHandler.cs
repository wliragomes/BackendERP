using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Bancos.Adicionar
{
    public class AdicionarBancoCommandHandler : IRequestHandler<AdicionarBancoCommand, FormularioResponse<AdicionarBancoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarBancoCommand> _validator;
        private const int _indece = 0;

        public AdicionarBancoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarBancoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarBancoCommand>> Handle(AdicionarBancoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarBancoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Banco banco = new
            (
                command.Nome,
                command.NaoSomar,
                command.NumeroBanco
            );
            {

                await _unitOfWork.BancoRepository.Adicionar(banco);
                response.Formulario!.SetId(banco.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
