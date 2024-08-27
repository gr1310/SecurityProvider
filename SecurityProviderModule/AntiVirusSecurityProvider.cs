/******************************************************************************
* Filename    = AntiVirusSecurityProvider.cs
*
* Author      = Garima Ranjan
* 
* Project     = SecurityProvider
*
* Description = Defines an AntiVirus Security Provider.
*****************************************************************************/

namespace SecurityProviderModule
{

    /// <summary>
    /// Anti Virus security provider.
    /// </summary>
    public class AntiVirusSecurityProvider : ISecurityProvider
    {

        private INotifier _notifier;

        public AntiVirusSecurityProvider(INotifier notifier)
        {
            _notifier = notifier;

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Users\public\Desktop";
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
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
                        _notifier?.OnSecurityEvent(1);
                        break;
                    }

                case WatcherChangeTypes.Created:
                    {
                        _notifier?.OnSecurityEvent(2);
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
