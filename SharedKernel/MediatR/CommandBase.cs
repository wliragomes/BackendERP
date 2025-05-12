using SharedKernel.SharedObjects;
using MediatR;

namespace SharedKernel.MediatR
{
    public class CommandBase<T> : IRequest<FormularioResponse<T>>
    {
        protected CommandBase()
        {
        }
    }
}
