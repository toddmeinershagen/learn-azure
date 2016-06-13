using System;
using System.Configuration;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Storage.Command
{
    public abstract class TableCommand
    {
        private CloudTable _table = null;

        public abstract void Execute();

        protected CloudTable Table
        {
            get
            {
                if (_table == null)
                {
                    var connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE",
                        EnvironmentVariableTarget.Machine);

                    var storageAccount = CloudStorageAccount.Parse(connectionString);
                    var client = storageAccount.CreateCloudTableClient();

                    _table = client.GetTableReference("orders");
                    _table.CreateIfNotExists();
                }

                return _table;
            }
        }
    }
}