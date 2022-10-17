using BudgetTrack.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BudgetTrack.Tests
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<BudgetContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<BudgetContext>(options =>
                {
                    options.UseInMemoryDatabase("BudgetTracker");
                });

            });
        }
    }
}
