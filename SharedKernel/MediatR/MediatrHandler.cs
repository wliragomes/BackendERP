using MediatR;
using SharedKernel.SharedObjects;

namespace SharedKernel.MediatR
{
    public class MediatrHandler : IMediatrHandler
    {
        private readonly IMediator _mediator;

        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<FormularioResponse<T>> SendCommand<T>(T comando) where T : CommandBase<T>
        {
            return await _mediator.Send(comando);
        }

        public async Task<List<FormularioResponse<TResponse>>> SendCommandInBulk<TCommand, TResponse>(TCommand comando) where TCommand : CommandInBulk<TResponse>
        {
            return await _mediator.Send(comando);
        }
    }
}
