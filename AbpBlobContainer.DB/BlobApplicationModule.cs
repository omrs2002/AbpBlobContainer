using AbpBlobContainer.DB.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.BlobStoring;
using Volo.Abp.Modularity;

namespace AbpBlobContainer.DB
{
    [DependsOn(typeof(AbpBlobStoringModule))]
    public class BlobApplicationModuleDB : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddDbContext<EmployeeDBContext>();

            context.Services.AddLogging(b =>
            {
               
                b.SetMinimumLevel(LogLevel.Debug);
            });
            

            Configure<AbpBlobStoringOptions>(options =>
            {
                options.Containers.ConfigureDefault(container =>
                {

                });
            });

        }


    }
}

