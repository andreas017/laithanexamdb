using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interface
{
    public interface IStorageProvider
    {
        /// <summary>
        /// Get presigned URL for retrieving blob from provider
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Task<string> GetPresignedUrl(string fileName);
        /// <summary>
        /// Get the PUT presigned URL for uploading file to the storage provider
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Task<string> GetPresignedPutUrl(string fileName);
        /// <summary>
        /// Delete file from storage provider
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        public Task DeleteFileAsync(string fileName, string fileExtension);
    }
}
