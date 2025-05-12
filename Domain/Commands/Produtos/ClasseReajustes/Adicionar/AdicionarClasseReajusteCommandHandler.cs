using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.ClasseReajustes.Adicionar
{
    public class AdicionarClasseReajusteCommandHandler : IRequestHandler<AdicionarClasseReajusteCommand, FormularioResponse<AdicionarClasseReajusteCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarClasseReajusteCommand> _validator;
        private const int _indice = 0;

        public AdicionarClasseReajusteCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarClasseReajusteCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarClasseReajusteCommand>> Handle(AdicionarClasseReajusteCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarClasseReajusteCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            ClasseReajuste classeReajuste = new(
                command.Nome,
                command.Descricao
            );
            {
                await _unitOfWork.ClasseReajusteRepository.Adicionar(classeReajuste);
                response.Formulario!.SetId(classeReajuste.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }

    }
}
