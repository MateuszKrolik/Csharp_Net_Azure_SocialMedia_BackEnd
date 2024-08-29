using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace WebApplication1.Services.ImageService
{
    public class ImageServiceImpl : IImageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly HashSet<string> _allowedImageContentTypes = new()
        {
            "image/jpg",
            "image/jpeg",
            "image/png",
        };

        private readonly Dictionary<string, string> _contentTypeToExtension = new()
        {
            { "image/jpg", ".jpg" },
            { "image/jpeg", ".jpeg" },
            { "image/png", ".png" },
        };

        public ImageServiceImpl(IConfiguration configuration)
        {
            var connectionString = configuration["AzureBlobStorage:ConnectionString"];
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task<string> UploadImageAsync(string containerName, string name, Stream imageStream, string contentType)
        {
            if (_allowedImageContentTypes.Contains(contentType))
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
                var extension = _contentTypeToExtension[contentType];
                var blobClient = containerClient.GetBlobClient(name + extension);

                await blobClient.UploadAsync(imageStream, new BlobHttpHeaders { ContentType = contentType });
                return blobClient.Uri.ToString();
            }
            else
            {
                throw new InvalidOperationException($"Invalid image content type: {contentType}");
            }
        }

        public async Task DeleteImageAsync(string containerName, string name)
        {

            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);

            await blobClient.DeleteIfExistsAsync();

        }

        public async Task<(Stream imageStream, string contentType)> GetImageAsync(string containerName, string name)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);

            var response = await blobClient.DownloadAsync();
            var contentType = response.Value.Details.ContentType;
            return (response.Value.Content, contentType);
        }
    }

}