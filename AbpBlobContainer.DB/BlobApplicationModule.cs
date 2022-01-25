using AbpBlobContainer.DB.App.Services;
using AbpBlobContainer.DB.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace AbpBlobContainer.DB
{
    [DependsOn(typeof(AbpBlobStoringModule))]
    [DependsOn(typeof(BlobStoringDatabaseDomainSharedModule))]
    [DependsOn(typeof(BlobStoringDatabaseEntityFrameworkCoreModule))]
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
                    container.UseDatabase();
                });
            });

            context.Services.AddScoped<IDBFilesService, DBFilesService>();

            Configure<AbpUnitOfWorkDefaultOptions>(options =>
            {
                options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
            });

        }


    }
}

