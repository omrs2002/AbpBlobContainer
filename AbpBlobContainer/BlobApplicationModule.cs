
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpBlobContainer
{
    [DependsOn(typeof(AbpBlobStoringModule))]
    [DependsOn(typeof(BlobStoringDatabaseEntityFrameworkCoreModule))]
    public class BlobApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            context.Services.AddLogging(b =>
            {
                b.AddConsole();
                b.SetMinimumLevel(LogLevel.Debug);
            });

            context.Services.AddTransient<IFilesService, FilesService>();

        }


    }
}

