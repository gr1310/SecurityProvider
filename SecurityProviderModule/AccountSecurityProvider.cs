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

        private INotifier _notifier;

        public AccountSecurityProvider(INotifier notifier)
        {
            _notifier = notifier;

            FileSystemWatcher watcher = new FileSystemWatcher();
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
            return true;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            WatcherChangeTypes wct = e.ChangeType;
            switch (wct)
            {
                case WatcherChangeTypes.Changed:
                    {
                        _notifier?.OnSecurityEvent(3);
                        break;
                    }

                case WatcherChangeTypes.Created:
                    {
                        _notifier?.OnSecurityEvent(4);
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
