
using AutoMapper;
using CustomerTransaction.StartUp;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerTransaction
{
    public static class AutomapperServiceExtension
    {

        public static void UseAutomapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
