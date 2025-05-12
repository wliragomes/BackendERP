using SharedKernel.SharedObjects;

namespace SharedKernel.MediatR
{
    public interface IMediatrHandler
    {
        Task<FormularioResponse<T>> SendCommand<T>(T comando) where T : CommandBase<T>;

        Task<List<FormularioResponse<TResponse>>> SendCommandInBulk<TCommand, TResponse>(TCommand comando)
        where TCommand : CommandInBulk<TResponse>;
    }
}
