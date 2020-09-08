using Microsoft.Extensions.DependencyInjection;

namespace DeryaBilisim.BiBayim.Integration.Standart
{
    public static class BiBayimServiceExtensions
    {
        public static void AddBiBayimService(this IServiceCollection services, string endpoint, string token)
        {
            services.AddSingleton<BiBayimService>(x => new BiBayimService(endpoint, token));
        }
    }
}