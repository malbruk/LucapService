using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Lucap.Repositories.Entities;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace Lucap.Web
{
    public class GoogleStorageManagerOptions
    {
        public string FilePath { get; set; }
    }

    //public static class GoogleStorageManagerOptionsBuilderExtension
    //{
       
    //    public static GoogleStorageManagerOptionsBuilder UseGoogleStorageManager(this GoogleStorageManagerOptionsBuilder string credentialsFilePath)
    //    {

    //    }
    //}

    public class GoogleStorageManager
    {
        private readonly string _bucketName = "trial_storage_of_mabruk";//TODO put in secrets.json
        private readonly GoogleStorageManagerOptions _options;

        public GoogleStorageManager(IOptions<GoogleStorageManagerOptions> options)
        {
            _options = options.Value;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    var credential = GoogleCredential.FromFile(_options.FilePath);
                    var storage = StorageClient.Create(credential);
                    //var storage = StorageClient.Create();
                    var uploadedObject = storage.UploadObject(_bucketName, $"fileName2{Path.GetExtension(file.FileName)}", "application/octet-stream", memoryStream);
                    var link = uploadedObject.SelfLink;
                    Console.WriteLine(link);
                    return link;

                }
            }
            return String.Empty;
        }
    }
}
