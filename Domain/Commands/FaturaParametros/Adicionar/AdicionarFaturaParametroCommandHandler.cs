using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.FaturaParametros.Adicionar
{
    public class AdicionarFaturaParametroCommandHandler : IRequestHandler<AdicionarFaturaParametroCommand, FormularioResponse<AdicionarFaturaParametroCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarFaturaParametroCommand> _validator;
        private const int _indece = 0;

        public AdicionarFaturaParametroCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarFaturaParametroCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarFaturaParametroCommand>> Handle(AdicionarFaturaParametroCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarFaturaParametroCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            FaturaParametro faturaParametro = new
            (
                command.Modelo,
                command.Serie,
                command.PrimeiroNumero
            );
            {

                await _unitOfWork.FaturaParametroRepository.Adicionar(faturaParametro);
                response.Formulario!.SetId(faturaParametro.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
