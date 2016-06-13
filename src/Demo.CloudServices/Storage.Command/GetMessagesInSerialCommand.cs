using System;

namespace Storage.Command
{
    public class GetMessagesInSerialCommand : QueueCommand
    {
        public override void Execute()
        {
            var keepWorking = true;
            while (keepWorking)
            {
                var message = WorkerQueue.GetMessage(TimeSpan.FromMinutes(5));

                if (message != null)
                {
                    Console.WriteLine(message.AsString);
                }
                else
                {
                    keepWorking = false;
                }
            }
        }
    }
}