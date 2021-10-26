using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using System.IO;

namespace VideoStreamFromAzureBlob.Controllers
{

    [ApiController]
    public class VideoController : ControllerBase
    {
        [HttpGet("api/video")]
        public async Task<IActionResult> GetVideo()
        {

            var client = new BlobServiceClient("CONNECTION_STRING");

            var blobClient = client.GetBlobContainerClient("CONTAINER_NAME");

            var blob = blobClient.GetBlobClient("BLOB_NAME");

            Stream str = await blob.OpenReadAsync();

            return new FileStreamResult(str, "video/mp4")
            {
                EnableRangeProcessing = true
            };

        }
    }
}
