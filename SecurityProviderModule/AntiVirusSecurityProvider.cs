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

        private ICommunicator _communicator;
        public FileSystemWatcher watcher;

        public AntiVirusSecurityProvider(ICommunicator communicator)
        {
            _communicator = communicator;

            watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Users\Garima Ranjan\Desktop";
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
            Console.WriteLine("Anti Virus Security Provider Scan on Desktop ");
            return true;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            WatcherChangeTypes wct = e.ChangeType;
            switch (wct)
            {
                case WatcherChangeTypes.Changed:
                    {
                        _communicator?.Notify(1);
                        break;
                    }

                case WatcherChangeTypes.Created:
                    {
                        _communicator?.Notify(2);
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
