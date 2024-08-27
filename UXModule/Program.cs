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
using ControllerModule;

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
        public static void Main()
        {
            string? userInput = Console.ReadLine();
            while (userInput != "quit")
            {
                ControllerModule.Controller controller = new ControllerModule.Controller();
                List<ISecurityProvider> providers = controller.CreateInstances();
                // ...
            }
        }
    }
}
