using ControllerModule;
using SecurityProviderModule;

namespace UXModule
{
    public class Program
    {
        private static Controller _controller;

        public static void Main()
        {
            _controller = new Controller();

            // Subscribe to the SecurityEventOccurred event
            _controller.SecurityEventOccurred += OnSecurityEventOccurred;

            // Simulate creating and using security providers
            List<ISecurityProvider> providers = CreateInstances();

            string? userInput;
            while(true)
            {
                Console.WriteLine("Enter a command (type 'scan' to perform scan, 'quit' to exit):");
                userInput = Console.ReadLine();

                if (userInput == "scan")
                {
                    // Example: Scan using all providers
                    foreach (var provider in providers)
                    {
                        bool result = provider.Scan();
                        Console.WriteLine($"Scan result: {result}");
                    }
                }
                else if (userInput != "quit")
                {
                    Console.WriteLine("Unknown command. Try again.");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Exiting the program.");
        }

        private static void OnSecurityEventOccurred(int eventCode)
        {
            Console.WriteLine("Security Event Encountered!!");
            Console.WriteLine($"Security event code: {eventCode}");
        }

        private static List<ISecurityProvider> CreateInstances()
        {
            List<ISecurityProvider> providers = new List<ISecurityProvider>();

            // Example instantiation
            providers.Add(new AccountSecurityProvider(_controller));

            return providers;
        }
    }
}
