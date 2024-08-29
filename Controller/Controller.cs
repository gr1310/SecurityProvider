/******************************************************************************
* Filename    = Controller.cs
*
* Author      = Garima Ranjan
* 
* Project     = SecurityProvider
*
* Description = Defines a controller.
*****************************************************************************/

using SecurityProviderModule;

namespace ControllerModule
{

    /// <summary>
    /// Controller for Providers
    /// </summary>
    public class Controller : INotifier
    {

        public event Action<int> SecurityEventOccurred;

        /// <summary>
        /// Handler for Active Providers
        /// </summary>
        public List<ISecurityProvider> CreateInstances()
        {
            List<ISecurityProvider> ActiveSecurityProviders= new List<ISecurityProvider>();

            String SelectedEnv = "Home";

            // To the various security providers, pass "this" instance as the notifier.

            if (SelectedEnv == "Org")
            {
                ISecurityProvider antiVirusSecurity = new AntiVirusSecurityProvider(this);
                ISecurityProvider accountSecurity = new AccountSecurityProvider(this);
            }

            else if (SelectedEnv == "Home")
            {
                ISecurityProvider accountSecurity = new AccountSecurityProvider(this);
            }

            return ActiveSecurityProviders;
        }

        /// <summary>
        /// Security Event notifier
        /// </summary>
        public void OnSecurityEvent(int Event)
        {
            // Process the event

            // To notify UX up the chain about security event, you would
            // need another interface, or a pattern like MVVM


            switch (Event)
            {
                case 3:
                    // Handle file change event
                    Console.WriteLine("Security Event: File changed.");
                    // You could add additional logic here, like logging the event
                    break;

                case 4:
                    // Handle file creation event
                    Console.WriteLine("Security Event: File created.");
                    // You could add additional logic here, like logging the event
                    break;

                default:
                    // Handle unknown or other events
                    Console.WriteLine($"Security Event: Unknown event code {Event}.");
                    break;
            }

            // Notify subscribers about the event (e.g., UI components)
            SecurityEventOccurred?.Invoke(Event);
        }

    }
}
