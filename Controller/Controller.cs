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

            if (SelectedEnv == "Org")
            {
                ISecurityProvider antiVirusSecurity = new AntiVirusSecurityProvider();
                ISecurityProvider accountSecurity = new AccountSecurityProvider();
            }

            else if (SelectedEnv == "Home")
            {
                ISecurityProvider accountSecurity = new AccountSecurityProvider();
            }

            return ActiveSecurityProviders;
        }

        /// <summary>
        /// Security Event notifier
        /// </summary>
        public void OnSecurityEvent(int Event)
        {
            // to notify user about security event
        }

    }
}
