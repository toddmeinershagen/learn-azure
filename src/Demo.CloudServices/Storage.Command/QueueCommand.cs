using System;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Storage.Command
{
    public abstract class QueueCommand
    {
        private CloudQueue _queue = null;

        public abstract void Execute();

        protected CloudQueue WorkerQueue
        {
            get
            {
                if (_queue == null)
                {
                    var connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE",
                        EnvironmentVariableTarget.Machine);

                    var storageAccount = CloudStorageAccount.Parse(connectionString);
                    var client = storageAccount.CreateCloudQueueClient();

                    _queue = client.GetQueueReference("worker");
                    _queue.CreateIfNotExists();
                }

                return _queue;
            }
        }
    }
}