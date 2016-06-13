using System;

namespace Storage.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            TableCommand command;

            //command = new BlobCommand();
            //command = new SingleInsertTableCommand();
            //command = new BatchInsertTableCommand();
            //command = new UpdateTableCommand();
            //command = new DeleteTableCommand();
            
            //command.Execute();
            command = new GetTableCommand();
            command.Execute();

            Console.WriteLine("Hit any key to end.");
            Console.ReadKey();
        }
    }
}
