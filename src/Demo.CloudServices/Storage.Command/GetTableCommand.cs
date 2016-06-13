using System;

using Microsoft.WindowsAzure.Storage.Table;

namespace Storage.Command
{
    public class GetTableCommand : TableCommand
    {
        public override void Execute()
        {
            var query = new TableQuery<OrderEntity>().Where(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Lana"));

            foreach (var entity in Table.ExecuteQuery(query))
            {
                Console.WriteLine("{0}, {1}\t{2}\t{3}", entity.PartitionKey, entity.RowKey,
                    entity.Status, entity.RequiredDate);
            }
        }
    }
}