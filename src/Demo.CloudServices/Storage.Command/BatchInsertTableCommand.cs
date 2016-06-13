using System;
using System.Configuration;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Storage.Command
{
    public class BatchInsertTableCommand : TableCommand
    {
        public override void Execute()
        {
            var newOrder1 = new OrderEntity("Lana", "20141217")
            {
                OrderNumber = "102",
                ShippedDate = Convert.ToDateTime("1/1/1900"),
                RequiredDate = Convert.ToDateTime("1/1/1900"),
                Status = "pending"
            };
            var newOrder2 = new OrderEntity("Lana", "20141218")
            {
                OrderNumber = "103",
                ShippedDate = Convert.ToDateTime("1/1/1900"),
                RequiredDate = Convert.ToDateTime("12/25/2014"),
                Status = "open"
            };

            var newOrder3 = new OrderEntity("Lana", "20141219")
            {
                OrderNumber = "103",
                ShippedDate = Convert.ToDateTime("12/17/2014"),
                RequiredDate = Convert.ToDateTime("12/17/2014"),
                Status = "shipped"
            };

            var batchOperation = new TableBatchOperation();
            batchOperation.Insert(newOrder1);
            batchOperation.Insert(newOrder2);
            batchOperation.Insert(newOrder3);
            Table.ExecuteBatch(batchOperation);
        }
    }
}