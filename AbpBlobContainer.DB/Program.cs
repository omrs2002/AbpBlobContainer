using AbpBlobContainer.DB;
using AbpBlobContainer.DB.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

public class Program
{
    public static void Main(string[] args)
    {

        using var application = AbpApplicationFactory.Create<BlobApplicationModuleDB>();
        application.Initialize();

        var logger = application.ServiceProvider.GetRequiredService<ILogger<Program>>();

        logger.LogInformation("Current directory {0}", Directory.GetCurrentDirectory());
        logger.LogDebug("Starting application");
        logger.LogDebug("All done!");


        

        Console.WriteLine("Press ENTER to stop application...");
        Console.ReadLine();


    }

}