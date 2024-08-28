using System;
using Azure.Storage.Blobs.Models;

namespace WebApplication1.Services.ImageService;

public interface IImageService
{
    Task<string> UploadImageAsync(string name, Stream imageStream, string contentType);
    Task DeleteImageAsync(string name);

    Task<(Stream imageStream, string contentType)> GetImageAsync(string name);
}
