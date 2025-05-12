using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cidades.Adicionar
{
    public class AdicionarCidadeCommandHandler : IRequestHandler<AdicionarCidadeCommand, FormularioResponse<AdicionarCidadeCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarCidadeCommand> _validator;
        private const int _indece = 0;

        public AdicionarCidadeCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarCidadeCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarCidadeCommand>> Handle(AdicionarCidadeCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarCidadeCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Cidade cidade = new
                (
                    command.IdEstado,
                    command.Nome,
                    command.PrISS,
                    command.ValorMultiplicador,
                    command.CodIBGE
                );

            await _unitOfWork.CidadeRepository.Adicionar(cidade);
            response.Formulario!.SetId(cidade.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }
    }
}
