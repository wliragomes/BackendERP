using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.RegimeTributarios.Adicionar
{
    public class AdicionarRegimeTributarioCommandHandler : IRequestHandler<AdicionarRegimeTributarioCommand, FormularioResponse<AdicionarRegimeTributarioCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarRegimeTributarioCommand> _validator;
        private const int _indece = 0;

        public AdicionarRegimeTributarioCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarRegimeTributarioCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarRegimeTributarioCommand>> Handle(AdicionarRegimeTributarioCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarRegimeTributarioCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            RegimeTributario regimeTributario = new
            (
                command.Nome,               
                command.ValorPis,                
                command.ValorCofins                
            );
            {

                await _unitOfWork.RegimeTributarioRepository.Adicionar(regimeTributario);
                response.Formulario!.SetId(regimeTributario.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
