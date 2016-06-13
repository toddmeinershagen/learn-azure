using System.Linq;

using Microsoft.WindowsAzure.Storage.Queue;

namespace Storage.Command
{
    public class AddMessagesToQueue : QueueCommand
    {
        public override void Execute()
        {
            foreach (var count in Enumerable.Range(1, 10))
            {
                WorkerQueue.AddMessage(new CloudQueueMessage($"Queued message {count}"));
            }
        }
    }
}