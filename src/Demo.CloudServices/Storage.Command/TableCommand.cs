using System.Configuration;

using Microsoft.WindowsAzure.Storage.Table;

namespace Storage.Command
{
    public abstract class TableCommand : Command
    {
        private CloudTable _table = null;

        protected CloudTable Table
        {
            get
            {
                if (_table == null)
                {
                    var client = Account.CreateCloudTableClient();

                    _table = client.GetTableReference("orders");
                    _table.CreateIfNotExists();
                }

                return _table;
            }
        }
    }
}