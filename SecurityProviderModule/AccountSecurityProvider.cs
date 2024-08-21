/******************************************************************************
* Filename    = AccountSecurityProvider.cs
*
* Author      = Garima Ranjan
* 
* Project     = SecurityProvider
*
* Description = Defines an Account Security Provider.
*****************************************************************************/

namespace SecurityProviderModule
{

    /// <summary>
    /// Account security provider.
    /// </summary>
    public class AccountSecurityProvider : ISecurityProvider
    {

        /// <summary>
        /// Scanner.
        /// </summary>
        public bool Scan()
        {
            return true; 
        }
    }
}
