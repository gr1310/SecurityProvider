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

        private List<ISubscriber> _subscribers = new List<ISubscriber>();
        public void Subscribe(ISubscriber subscriber)
        {
            if (!_subscribers.Contains(subscriber))
            {
                _subscribers.Add(subscriber);
            }
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            if (_subscribers.Contains(subscriber))
            {
                _subscribers.Remove(subscriber);
            }
        }

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
