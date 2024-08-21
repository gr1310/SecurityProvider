/******************************************************************************
* Filename    = Program.cs
*
* Author      = Garima Ranjan
* 
* Project     = SecurityProvider
*
* Description = Defines an user interface.
*****************************************************************************/

using SecurityProviderModule;

namespace UXModule
{

    /// <summary>
    /// User interaction program
    /// </summary>
    public class Program
    {

        /// <summary>
        /// To scan using user defined provider
        /// </summary>
        public void Main()
        {
            ISecurityProvider provider;
            String userInput = Console.ReadLine();

            while (userInput != "quit")
            {
                if (userInput == "1")
                {
                    provider = new AntiVirusSecurityProvider();
                    provider.Scan();
                }
                else if (userInput == "2")
                {
                    provider = new AccountSecurityProvider();
                    provider.Scan();
                }
            }
        }
    }
}
