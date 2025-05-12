using MediatR;
using SharedKernel.SharedObjects;

namespace SharedKernel.MediatR
{
    public class CommandInBulk<T> : IRequest<List<FormularioResponse<T>>>
    {
        protected CommandInBulk()
        {
        }
    }
}
