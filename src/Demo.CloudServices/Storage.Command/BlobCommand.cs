using System;
using System.Configuration;
using System.IO;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Storage.Command
{
    public class BlobCommand
    {
        public void Execute()
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            var client = storageAccount.CreateCloudBlobClient();

            var container = client.GetContainerReference("documents");
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob });

            var counter = 0;
            if (container.Metadata.ContainsKey("counter"))
            {
                counter = Convert.ToInt32(container.Metadata["counter"] ?? "0");
            }

            Console.WriteLine($"Counter:  {counter}");
            Console.WriteLine($"ETag:  {container.Properties.ETag}");

            foreach (CloudBlockBlob blob in container.ListBlobs(null, false))
            {
                Console.WriteLine($"Block blob of length {blob.Properties.Length}:  {blob.Uri}");
                var path = Path.Combine(@"C:\Temp\", blob.Name);

                using (var stream = File.OpenWrite(path))
                {
                    blob.DownloadToStream(stream);
                }
            }
            counter++;
            container.Metadata["counter"] = counter.ToString();
            container.SetMetadata();
        }
    }
}