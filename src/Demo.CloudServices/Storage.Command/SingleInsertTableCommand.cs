using System;

using Microsoft.WindowsAzure.Storage.Table;

namespace Storage.Command
{
    public class SingleInsertTableCommand : TableCommand
    {
        public override void Execute()
        {
            var order = new OrderEntity("Archer", "20141216")
            {
                ShippedDate = new DateTime(2014, 12, 18),
                RequiredDate = new DateTime(2014, 12, 22),
                Status = "shipped"
            };

            var operation = TableOperation.Insert(order);
            Table.Execute(operation);
        }
    }
}