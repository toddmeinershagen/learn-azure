using System;

using Microsoft.WindowsAzure.Storage.Blob;

namespace Storage.Command
{
    public class ProduceSASTokenForBlob : BlobCommand
    {
        public override void Execute()
        {
            var policy = new SharedAccessBlobPolicy();
            policy.SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1);
            policy.SharedAccessStartTime = DateTime.UtcNow.Subtract(TimeSpan.FromMinutes(5));
            policy.Permissions = 
                SharedAccessBlobPermissions.Read |
                SharedAccessBlobPermissions.Write | 
                SharedAccessBlobPermissions.Delete | 
                SharedAccessBlobPermissions.List;

            Console.WriteLine(Container.GetSharedAccessSignature(policy));
        }
    }
}