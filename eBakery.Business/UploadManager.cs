using System;
using System.Collections.Generic;
using System.Text;
using eBakery.Contracts.Repositories;
using eBakery.Contracts.Services;
using eBakery.Contracts.Models;
using System.Threading.Tasks;

namespace eBakery.Business
{
    public class UploadManager: IUploadService
    {
        private readonly IUploadRepository _uploadRepository;

        public UploadManager(IUploadRepository uploadRepository)
        {
            _uploadRepository = uploadRepository;

        }
        public async Task SaveUploadedImages(int ImageId, int CategoryId, string ImageName, string UserEmail, string Format, string FolderName)
        {
            await _uploadRepository.SaveUploadedImages(ImageId, CategoryId, ImageName, UserEmail, Format, FolderName);
        }

        public string GetUserFolderName(string UserEmail)
        {
            return _uploadRepository.GetUserFolderName(UserEmail);
        }
    }
}
