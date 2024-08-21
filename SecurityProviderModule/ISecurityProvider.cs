/******************************************************************************
* Filename    = ISecurityProvider.cs
*
* Author      = Garima Ranjan
* 
* Project     = SecurityProvider
*
* Description = Defines an interface for security provider.
*****************************************************************************/

namespace SecurityProviderModule
{

    /// <summary>
    /// Declares a security provider that scans.
    /// </summary>
    public interface ISecurityProvider
    {

        /// <summary>
        /// Scanner.
        /// </summary>
        public bool Scan();
    }
}
