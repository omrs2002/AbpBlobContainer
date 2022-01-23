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

        //Resolve a service and use it
        //var services = new ServiceCollection();

        //services.AddLogging(b =>
        //{
        //    b.AddConsole();
        //    b.SetMinimumLevel(LogLevel.Debug);
        //});

        //services.AddTransient<IFilesService, FilesService>();


        //var serviceProvider = services.BuildServiceProvider();

        //using var scope = serviceProvider.CreateScope();

        var logger = application.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Current directory {0}", Directory.GetCurrentDirectory());
        logger.LogDebug("Starting application");
        logger.LogDebug("All done!");


        IFilesService fileS = application.ServiceProvider.GetRequiredService<IFilesService>();
        byte[] buffer = "My Name Is Omar".GetBytes();
        fileS.SaveBytesAsync(buffer);

        var s = fileS.GetBytesAsync();

        Console.WriteLine("Press ENTER to stop application...");
        //Console.ReadLine();


    }

}