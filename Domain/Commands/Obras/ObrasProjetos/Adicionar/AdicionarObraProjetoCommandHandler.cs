using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObrasProjetos.Adicionar
{
    public class AdicionarObraProjetoCommandHandler : IRequestHandler<AdicionarObraProjetoCommand, FormularioResponse<AdicionarObraProjetoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarObraProjetoCommand> _validator;
        private const int _indece = 0;

        public AdicionarObraProjetoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarObraProjetoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarObraProjetoCommand>> Handle(AdicionarObraProjetoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarObraProjetoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            ObraProjeto obraProjeto = new(command.Nome);
            {
                await _unitOfWork.ObraProjetoRepository.Adicionar(obraProjeto);
                response.Formulario!.SetId(obraProjeto.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
