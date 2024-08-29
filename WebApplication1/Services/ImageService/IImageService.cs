using System;
using Azure.Storage.Blobs.Models;

namespace WebApplication1.Services.ImageService;

public interface IImageService
{
    public Task<string> UploadImageAsync(string containerName, string name, Stream imageStream, string contentType);    
    public Task DeleteImageAsync(string containerName, string name);

    public Task<(Stream imageStream, string contentType)> GetImageAsync(string containerName, string name);
}
