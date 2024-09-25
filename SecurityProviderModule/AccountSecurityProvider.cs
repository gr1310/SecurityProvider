/******************************************************************************
* Filename    = AccountSecurityProvider.cs
*
* Author      = Garima Ranjan
* 
* Project     = SecurityProvider
*
* Description = Defines an Account Security Provider.
*****************************************************************************/

namespace SecurityProviderModule
{

    /// <summary>
    /// Account security provider.
    /// </summary>
    public class AccountSecurityProvider : ISecurityProvider
    {

        private ICommunicator _communicator;
        public FileSystemWatcher watcher;
        public AccountSecurityProvider(ICommunicator communicator)
        {
            _communicator = communicator;

            watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Users\Garima Ranjan\Documents";
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            // Subscribe to events
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);

            // Start monitoring
            watcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Scanner.
        /// </summary>
        public bool Scan()
        {
            Console.WriteLine("Account Security Provider Scan on Documents ");
            return true;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            WatcherChangeTypes wct = e.ChangeType;
            switch (wct)
            {
                case WatcherChangeTypes.Changed:
                    {
                        _communicator?.Notify(3);
                        break;
                    }

                case WatcherChangeTypes.Created:
                    {
                        _communicator?.Notify(4);
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }
    }
}
