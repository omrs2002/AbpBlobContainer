using Microsoft.Extensions.Logging;
using Volo.Abp.BlobStoring;
using Volo.Abp.DependencyInjection;

namespace AbpBlobContainer
{

    public interface IFilesService
    {
         Task SaveBytesAsync(byte[] bytes);
         Task<byte[]> GetBytesAsync();
    }

    public class FilesService : IFilesService,ITransientDependency
    {

        //If you don't use the generic argument and directly inject the IBlobContainer (as explained before), you get the default container
        private readonly IBlobContainer _blobContainer;

        private readonly ILogger<FilesService> _logger;


        public FilesService(IBlobContainer blobContainer, ILogger<FilesService> logger)
        {
            
            _blobContainer = blobContainer;

            _logger = logger;
            this._logger.LogInformation("Info: In Application::Run");
            this._logger.LogWarning("Warn: In Application::Run");
            this._logger.LogError("Error: In Application::Run");
            this._logger.LogCritical("Critical: In Application::Run");
        }

        public async Task SaveBytesAsync(byte[] bytes)
        {
            await _blobContainer.SaveAsync("my-blob-1", bytes);
        }

        public async Task<byte[]> GetBytesAsync()
        {
            return await _blobContainer.GetAllBytesOrNullAsync("my-blob-1");
        }
    }

}
