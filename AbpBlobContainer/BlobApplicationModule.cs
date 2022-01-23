
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.BlobStoring;
using Volo.Abp.Modularity;
using Volo.Abp.BlobStoring.FileSystem;
using AbpBlobContainer.Data;

namespace AbpBlobContainer
{
    //[DependsOn(typeof(AbpBlobStoringModule))]
    [DependsOn(typeof(AbpBlobStoringFileSystemModule))]
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

            context.Services.AddDbContext<EmployeeDBContext>();

            //Configure the Default Container
            Configure<AbpBlobStoringOptions>(options =>
            {
                options.Containers.ConfigureDefault(container =>
                {
                    //Disable multi-tenancy for a specific container
                    container.IsMultiTenant = false;

                    container.UseFileSystem(fileSystem =>
                    {
                        fileSystem.BasePath = "C:\\my-files";
                    });
                });
            });

        }


    }
}

