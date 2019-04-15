using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Ralms.EntityFrameworkCore.Extensions
{
    class RalmsExOptionsExtension : IDbContextOptionsExtension
    {
        public string LogFragment => string.Empty;

        public long GetServiceProviderHashCode()
            => base.GetHashCode()  * 397;

        public void Validate(IDbContextOptions options)
        {
        }

        public bool ApplyServices(IServiceCollection services)
        {
            services.AddRalmsExtensions(); 
            return false;
        }
    }
}
