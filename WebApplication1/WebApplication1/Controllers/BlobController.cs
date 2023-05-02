using Lib.Interface;
using Lib.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Training.Sql.Entity;
using Training.Sql.Entity.Entity;

namespace efcore.Controllers
{
    [Route("api/blob")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        private readonly IStorageProvider _storageProvider;
        private readonly CinemaDbContext _dbContext;
        private readonly string _bucketName;
        public BlobController(IStorageProvider storageProvider, CinemaDbContext dbContext, IOptions<MinioOptions> minioOptions)
        {
            _storageProvider = storageProvider;
            _dbContext = dbContext;
            _bucketName = minioOptions.Value.BucketName;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetPresignedUrl(string fileName)
        {
            var urlFile = await _storageProvider.GetPresignedUrl(fileName);
            return Ok(urlFile);
        }

        [HttpGet("redirect")]
        public async Task<ActionResult<string>> GetPresignedUrlRedirect(string fileName)
        {
            var urlFile = await _storageProvider.GetPresignedUrl(fileName);
            return Redirect(urlFile);
        }

        [HttpGet("presigned-put-object")]
        public async Task<ActionResult<string>> GetPresinedPutUrl(string fileName)
        {
            var urlFile = await _storageProvider.GetPresignedPutUrl(fileName);
            return Ok(urlFile);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteObject(string fileName, string fileExtension)
        {
            await this._storageProvider.DeleteFileAsync(fileName, fileExtension);

            return Ok();
        }

        [HttpPost("blob-information")]
        public async Task<ActionResult> PostBlobInformation(Guid id, string fileName, string mime)
        {
            var blob = new Blob
            {
                BlobId = id,
                FileName = fileName,
                CreatedAt = DateTimeOffset.UtcNow,
                FilePath = $"{_bucketName}/{id}",
                MIME = mime,
            };

            this._dbContext.Blobs.Add(blob);
            await this._dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
