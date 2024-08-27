/******************************************************************************
* Filename    = INotifier.cs
*
* Author      = Garima Ranjan
* 
* Project     = SecurityProvider
*
* Description = Defines an interface for notification.
*****************************************************************************/

namespace SecurityProviderModule
{
    /// <summary>
    /// Declares a notifier that can send and receive messages.
    /// </summary>
    public interface INotifier
    {
        public void OnSecurityEvent(int Event);
    }
}
