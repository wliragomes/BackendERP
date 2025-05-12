using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Grupos.Adicionar
{
    public class AdicionarGrupoCommandHandler : IRequestHandler<AdicionarGrupoCommand, FormularioResponse<AdicionarGrupoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarGrupoCommand> _validator;
        private const int _indece = 0;

        public AdicionarGrupoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarGrupoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarGrupoCommand>> Handle(AdicionarGrupoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarGrupoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Grupo grupo = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.GrupoRepository.Adicionar(grupo);
                response.Formulario!.SetId(grupo.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
