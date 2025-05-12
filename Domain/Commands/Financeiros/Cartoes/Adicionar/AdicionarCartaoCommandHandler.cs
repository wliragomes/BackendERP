using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cartoes.Adicionar
{
    public class AdicionarCartaoCommandHandler : IRequestHandler<AdicionarCartaoCommand, FormularioResponse<AdicionarCartaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarCartaoCommand> _validator;
        private const int _indece = 0;

        public AdicionarCartaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarCartaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarCartaoCommand>> Handle(AdicionarCartaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarCartaoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Cartao cartao = new
            (
                command.Nome
            );
            {

                await _unitOfWork.CartaoRepository.Adicionar(cartao);
                response.Formulario!.SetId(cartao.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
