using SecurityProviderModule;

namespace UXModule
{
    public class Program
    {
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
