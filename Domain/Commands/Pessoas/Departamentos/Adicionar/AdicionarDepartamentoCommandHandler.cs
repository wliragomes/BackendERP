using Domain.Entities.Contatos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Departamentos.Adicionar
{
    public class AdicionarDepartamentoCommandHandler : IRequestHandler<AdicionarDepartamentoCommand, FormularioResponse<AdicionarDepartamentoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarDepartamentoCommand> _validator;
        private const int _indece = 0;

        public AdicionarDepartamentoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarDepartamentoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarDepartamentoCommand>> Handle(AdicionarDepartamentoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarDepartamentoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Departamento departamento = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.DepartamentoRepository.Adicionar(departamento);
                response.Formulario!.SetId(departamento.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
