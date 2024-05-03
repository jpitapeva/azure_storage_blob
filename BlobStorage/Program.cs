using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace BlobStorage
{
    public static class Program
    {
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=youraccountname;AccountKey=youraccountkey;EndpointSuffix=core.windows.net";
        private static string containerName = "itext";
        private static string blobName = "itext";
        private static string filePath = "C:\\temp\\teste.txt";

        static async Task Main(string[] args)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            await Upload(blobClient);

            await Download(blobClient);
        }

        static async Task Upload(BlobClient blobClient)
        {
            // Write text to the file
            await File.WriteAllTextAsync(filePath, "Hello, World33!");

            await blobClient.UploadAsync(filePath, true);
            Console.WriteLine("Blob uploaded successfully");
        }

        static async Task Download(BlobClient blobClient)
        {
            string downloadFilePath = filePath.Replace("teste.txt", "DOWNLOADED.txt");
            await blobClient.DownloadToAsync(downloadFilePath);
            Console.WriteLine("Blob download successfully");
        }
    }
}