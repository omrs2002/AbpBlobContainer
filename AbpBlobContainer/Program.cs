using AbpBlobContainer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

public class Program
{
	public static  void Main(string[] args)
	{

        using var application = AbpApplicationFactory.Create<BlobApplicationModule>
          (options =>
          {
          });
        application.Initialize();

        var logger = application.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Current directory {0}", Directory.GetCurrentDirectory());
        logger.LogDebug("Starting application");
        logger.LogDebug("All done!");


        IFilesService fileS = application.ServiceProvider.GetRequiredService<IFilesService>();
        byte[] buffer = "My Name Is Omar".GetBytes();
        fileS.SaveBytesAsync(buffer);

        var s = fileS.GetBytesAsync();

        Console.WriteLine("Press ENTER to stop application...");
        Console.ReadLine();


    }

}