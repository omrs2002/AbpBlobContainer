using Abp.Application.Services;
using AbpBlobContainer.DB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring;
using Volo.Abp.Uow;

namespace AbpBlobContainer.DB.App.Services
{
    
    public interface IDBFilesService : IApplicationService
    {
        Task SaveBlobAsync(SaveBlobInputDto input);
        Task<BlobDto> GetBlobAsync(GetBlobRequestDto input);
    }

    internal class DBFilesService : ApplicationService, IDBFilesService
    {
        private readonly IBlobContainer<MyFileContainer> _fileContainer;

        public DBFilesService(IBlobContainer<MyFileContainer> fileContainer)
        {
            _fileContainer = fileContainer;
        }


        [UnitOfWork]
        public async Task SaveBlobAsync(SaveBlobInputDto input)
        {
            await _fileContainer.SaveAsync(input.Name, input.Content, true);
        }
        [UnitOfWork]
        public async Task<BlobDto> GetBlobAsync(GetBlobRequestDto input)
        {
            var blob = await _fileContainer.GetAllBytesAsync(input.Name);

            return new BlobDto
            {
                Name = input.Name,
                Content = blob
            };
        }

    }
}
