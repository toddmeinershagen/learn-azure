using System;

using Microsoft.WindowsAzure.Storage.Table;

namespace Storage.Command
{
    public class UpdateTableCommand : TableCommand
    {
        public override void Execute()
        {
            var retrieveOperation = TableOperation.Retrieve<OrderEntity>("Lana", "20141217");
            var retrievedResult = Table.Execute(retrieveOperation);

            var updateEntity = (OrderEntity)retrievedResult.Result;
            if (updateEntity != null)
            {
                updateEntity.Status = "shipped";
                updateEntity.ShippedDate = Convert.ToDateTime("12/20/2014");
                TableOperation insertOrReplaceOperation = TableOperation.InsertOrReplace(updateEntity);
                Table.Execute(insertOrReplaceOperation);
            }
        }
    }
}