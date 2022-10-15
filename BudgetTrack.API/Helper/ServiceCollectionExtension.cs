using BudgetTrack.Data;

namespace BudgetTrack.API.Helper
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddEffCollections(this IServiceCollection services)
        {
            services.AddDbContext<BudgetContext>();

            return services;
        }
    }
}
