using Microsoft.WindowsAzure.Storage.Queue;

namespace Storage.Command
{
    public abstract class QueueCommand : Command
    {
        private CloudQueue _queue = null;

        protected CloudQueue WorkerQueue
        {
            get
            {
                if (_queue == null)
                {
                    var client = Account.CreateCloudQueueClient();

                    _queue = client.GetQueueReference("worker");
                    _queue.CreateIfNotExists();
                }

                return _queue;
            }
        }
    }
}