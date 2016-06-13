using System;

using Microsoft.WindowsAzure.Storage;

namespace Storage.Command
{
    public abstract class Command
    {
        public abstract void Execute();

        private CloudStorageAccount _account;

        protected CloudStorageAccount Account
        {
            get
            {
                if (_account == null)
                {
                    var connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE", EnvironmentVariableTarget.Machine);
                    _account = CloudStorageAccount.Parse(connectionString);
                }

                return _account;
            }
        }
    }
}