using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Ncms.Adicionar
{
    public class AdicionarNcmCommandHandler : IRequestHandler<AdicionarNcmCommand, FormularioResponse<AdicionarNcmCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarNcmCommand> _validator;
        private const int _indece = 0;

        public AdicionarNcmCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarNcmCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarNcmCommand>> Handle(AdicionarNcmCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarNcmCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Ncm ncm = new
            (
                command.NrNcm01, 
                command.NrNcm02, 
                command.NrNcm03, 
                command.NrNcmCompleta, 
                command.Descricao, 
                command.Aliquota,
                command.InsiteSt,
                command.AliquotaSt
            );

            {
                await _unitOfWork.NcmRepository.Adicionar(ncm);
                response.Formulario!.SetId(ncm.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
