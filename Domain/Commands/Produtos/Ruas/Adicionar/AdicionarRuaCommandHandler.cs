using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Ruas.Adicionar
{
    public class AdicionarRuaCommandHandler : IRequestHandler<AdicionarRuaCommand, FormularioResponse<AdicionarRuaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarRuaCommand> _validator;
        private const int _indece = 0;

        public AdicionarRuaCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarRuaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarRuaCommand>> Handle(AdicionarRuaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarRuaCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Rua rua = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.RuaRepository.Adicionar(rua);
                response.Formulario!.SetId(rua.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}