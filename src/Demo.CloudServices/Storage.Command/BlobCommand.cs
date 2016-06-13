using Microsoft.WindowsAzure.Storage.Blob;

namespace Storage.Command
{
    public abstract class BlobCommand : Command
    {
        private CloudBlobClient _client;
        private CloudBlobContainer _container;

        protected CloudBlobContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = Client.GetContainerReference("documents");
                    _container.CreateIfNotExists();
                }

                return _container;
            }
        }

        protected CloudBlobClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = Account.CreateCloudBlobClient();
                }

                return _client;
            }
        }
    }
}