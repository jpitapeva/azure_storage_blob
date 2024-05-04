using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace BlobStorage
{
    public static class Program
    {
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=CHANGE_ME;AccountKey=CHANGE_ME;EndpointSuffix=core.windows.net";
        private static string containerName = "joao"; //add in azure portal 
        private static string blobName = "files.txt";  //image.png //doc.pdf
        private static string filePath = "C:\\temp";
        private static string fileName = "arquivoQueQueroSalvar.txt"; //arquivoQueQueroSalvar.png //arquivoQueQueroSalvar.pdf
        private static string fileFullPath = Path.Combine(filePath, fileName);

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
            // Rewrite text to the file
            //await File.WriteAllTextAsync(fileFullPath, "Hello, World3!");

            await blobClient.UploadAsync(fileFullPath, true);
            Console.WriteLine("Blob uploaded successfully");
        }

        static async Task Download(BlobClient blobClient)
        {
            string downloadFilePath = fileFullPath.Replace(fileName, "DOWNLOADED.txt");
            await blobClient.DownloadToAsync(downloadFilePath);
            Console.WriteLine("Blob download successfully");
        }
    }
}