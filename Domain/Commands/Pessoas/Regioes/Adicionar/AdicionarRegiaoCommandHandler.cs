using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Regioes.Adicionar
{
    public class AdicionarRegiaoCommandHandler : IRequestHandler<AdicionarRegiaoCommand, FormularioResponse<AdicionarRegiaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarRegiaoCommand> _validator;
        private const int _indece = 0;

        public AdicionarRegiaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarRegiaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarRegiaoCommand>> Handle(AdicionarRegiaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarRegiaoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Regiao regiao = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.RegiaoRepository.Adicionar(regiao);
                response.Formulario!.SetId(regiao.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
