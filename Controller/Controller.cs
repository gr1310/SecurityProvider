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
    public class Controller : ICommunicator
    {
        /// <summary>
        /// List of all subscribers
        /// </summary>
        private List<ISubscriber> _subscribers = new List<ISubscriber>();

        /// <summary>
        /// Adding subscriber
        /// </summary>
        public void Subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        /// <summary>
        /// Removing subscriber
        /// </summary>
        public void Unsubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        /// <summary>
        /// Sending information to UX module, recieved from Security Provider Module
        /// </summary>
        public void Notify(int eventCode)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.OnSecurityEvent(eventCode);
            }
        }

        /// <summary>
        /// Handler for Active Providers
        /// </summary>
        public List<ISecurityProvider> CreateInstances()
        {
            List<ISecurityProvider> ActiveSecurityProviders= new List<ISecurityProvider>();

            String SelectedEnv = "Org";

            // To the various security providers, pass "this" instance as the notifier.

            if (SelectedEnv == "Org")
            {
                ISecurityProvider antiVirusSecurity = new AntiVirusSecurityProvider(this);
                ISecurityProvider accountSecurity = new AccountSecurityProvider(this);
                ActiveSecurityProviders.Add(accountSecurity);
                ActiveSecurityProviders.Add(antiVirusSecurity);
            }

            else if (SelectedEnv == "Home")
            {
                ISecurityProvider accountSecurity = new AccountSecurityProvider(this);
                ActiveSecurityProviders.Add(accountSecurity);
            }

            return ActiveSecurityProviders;
        }

    }
}
