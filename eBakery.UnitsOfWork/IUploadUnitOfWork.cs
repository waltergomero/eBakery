using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eBakery.UnitOfWork
{
    public interface IUploadUnitOfWork
    {
        Task SaveUploadedImages(int ImageId, int CategoryId, string ImageName, string UserEmail, string Format, string FolderName);
        string GetUserFolderName(string UserEmail);
    }
}
