using Microsoft.WindowsAzure.Storage.Table;

namespace Storage.Command
{
    public class DeleteTableCommand : TableCommand
    {
        public override void Execute()
        {
            var retrieveOperation = TableOperation.Retrieve<OrderEntity>("Lana", "20141217");
            var retrievedOrder = Table.Execute(retrieveOperation).Result as ITableEntity;

            if (retrievedOrder != null)
            {
                var operation = TableOperation.Delete(retrievedOrder);
                Table.Execute(operation);
            }
        }
    }
}