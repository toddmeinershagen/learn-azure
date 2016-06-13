using System;

namespace Storage.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Command command;
            //command = new UpdateBlobMetadataCommand();

            //command = new SingleInsertTableCommand();
            //command = new BatchInsertTableCommand();
            //command = new UpdateTableCommand();
            //command = new DeleteTableCommand();
            //command = new GetTableCommand();
            
            //command = new AddMessagesToQueue();
            //command = new GetMessagesSeriallyCommand();
            //command = new GetMessagesInParallelCommand();
            
            command = new ProduceSASTokenForBlob();
            command.Execute();

            Console.WriteLine("Hit any key to end.");
            Console.ReadKey();
        }
    }
}
