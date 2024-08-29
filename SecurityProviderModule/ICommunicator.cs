/******************************************************************************
* Filename    = INotifier.cs
*
* Author      = Garima Ranjan
* 
* Project     = SecurityProvider
*
* Description = Defines an interface for subscribing to get notified.
*****************************************************************************/

namespace SecurityProviderModule
{
    /// <summary>
    /// Declares a communicator to take event code from SPM to CM.
    /// </summary>
    public interface ICommunicator
    {
        void Subscribe(ISubscriber subscriber);
        void Unsubscribe(ISubscriber subscriber);
        void Notify(int eventCode);
    }
}
