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
        }

    }
}
