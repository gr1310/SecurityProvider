/******************************************************************************
* Filename    = INotifier.cs
*
* Author      = Garima Ranjan
* 
* Project     = SecurityProvider
*
* Description = Defines an interface for recieving message.
*****************************************************************************/

namespace SecurityProviderModule
{
    /// <summary>
    /// Declares a subscriber that can receive messages on UX.
    /// </summary>
    public interface ISubscriber
    {
        void OnSecurityEvent(int Event);
    }
}
