using System;
using System.IO;

using Microsoft.WindowsAzure.Storage.Blob;

namespace Storage.Command
{
    public class UpdateBlobMetadataCommand : BlobCommand
    {
        public override void Execute()
        {
            Container.SetPermissions(new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob });

            var counter = 0;
            if (Container.Metadata.ContainsKey("counter"))
            {
                counter = Convert.ToInt32(Container.Metadata["counter"] ?? "0");
            }

            Console.WriteLine($"Counter:  {counter}");
            Console.WriteLine($"ETag:  {Container.Properties.ETag}");

            foreach (CloudBlockBlob blob in Container.ListBlobs(null, false))
            {
                Console.WriteLine($"Block blob of length {blob.Properties.Length}:  {blob.Uri}");
                var path = Path.Combine(@"C:\Temp\", blob.Name);

                using (var stream = File.OpenWrite(path))
                {
                    blob.DownloadToStream(stream);
                }
            }
            counter++;
            Container.Metadata["counter"] = counter.ToString();
            Container.SetMetadata();
        }
    }
}