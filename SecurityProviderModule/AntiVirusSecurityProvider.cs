/******************************************************************************
* Filename    = AntiVirusSecurityProvider.cs
*
* Author      = Garima Ranjan
* 
* Project     = SecurityProvider
*
* Description = Defines an AntiVirus Security Provider.
*****************************************************************************/

namespace SecurityProviderModule
{

    /// <summary>
    /// Anti Virus security provider.
    /// </summary>
    public class AntiVirusSecurityProvider : ISecurityProvider
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
