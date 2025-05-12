using Microsoft.AspNetCore.Builder;

namespace SharedKernel.Configuration.Extensions
{
    public static class UseExceptionHandlerExtension
    {
        public static void RegisterUseExceptionHandlerExtension(this WebApplication app)
        {
            app.UseExceptionHandler("/error");
        }
    }
}
