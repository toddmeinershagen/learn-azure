using System;
using System.Threading.Tasks;

namespace Storage.Command
{
    public class GetMessagesInParallelCommand : QueueCommand
    {
        public override void Execute()
        {
            var batch = WorkerQueue.GetMessages(10, TimeSpan.FromMinutes(5));

            Parallel.ForEach(batch, m =>
            {
                Console.WriteLine(m.AsString);
            });
        }
    }
}