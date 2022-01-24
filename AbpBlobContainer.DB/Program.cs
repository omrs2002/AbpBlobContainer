using AbpBlobContainer.DB;
using AbpBlobContainer.DB.App.Services;
using AbpBlobContainer.DB.Data;
using AbpBlobContainer.DB.DTOs;
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
        //test adding files to DB :

        var file_serv = application.ServiceProvider.GetRequiredService<IDBFilesService>();
        byte[] buffer = "My Name Is Omar".GetBytes();
        SaveBlobInputDto dto = new SaveBlobInputDto
        {
            Name = "My Name Is Omar",
            Content = buffer
        };

        file_serv.SaveBlobAsync(dto);
        //read the file:
        var res = file_serv.GetBlobAsync(new GetBlobRequestDto { Name = "My Name Is Omar" });

        Console.WriteLine("Press ENTER to stop application...");
        Console.ReadLine();


    }

}