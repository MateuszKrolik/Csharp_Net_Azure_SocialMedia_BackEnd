using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace WebApplication1.Services.ImageService
{
    public class ImageServiceImpl : IImageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string? _containerName;

        public ImageServiceImpl(IConfiguration configuration)
        {
            var connectionString = configuration["AZURE_BLOB_STORAGE_CONNECTION_STRING"];
            var containerName = configuration["AZURE_BLOB_STORAGE_CONTAINER_NAME"];
            _blobServiceClient = new BlobServiceClient(connectionString);
            _containerName = containerName;
        }

        public async Task<string> UploadImageAsync(string name, Stream imageStream, string contentType)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(name);

            await blobClient.UploadAsync(imageStream, new BlobHttpHeaders { ContentType = contentType });
            return blobClient.Uri.ToString();
        }

        public async Task DeleteImageAsync(string name)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(name);

            await blobClient.DeleteIfExistsAsync();
        }

        public async Task<(Stream imageStream, string contentType)> GetImageAsync(string name)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(name);

            var response = await blobClient.DownloadAsync();
            var contentType = response.Value.Details.ContentType;
            return (response.Value.Content, contentType);
        }

    }

}