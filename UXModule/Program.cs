using ControllerModule;
using SecurityProviderModule;

namespace UXModule
{
    public class Program : ISubscriber
    {
        private static Controller _controller;


        public static void Main()
        {
            _controller = new Controller();

            _controller.Subscribe(new Program());

            List<ISecurityProvider> providers = _controller.CreateInstances();

            string? userInput;
            while(true)
            {
                Console.WriteLine("Enter a command (type 'scan' to perform scan, 'quit' to exit):");
                userInput = Console.ReadLine();

                if (userInput == "scan")
                {
                    foreach (var provider in providers)
                    {
                        bool result = provider.Scan();
                        Console.WriteLine($"Scan Successful: {result}");
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

        public void OnSecurityEvent(int eventCode)
        {
            Console.WriteLine("Security Event Encountered!!");

            switch (eventCode)
            {
                case 1:
                    Console.WriteLine($"Security Event: File changed with event code: {eventCode}.\n");
                    break;

                case 2:
                    Console.WriteLine($"Security Event: File created with event code: {eventCode}.\n");
                    break;

                case 3:
                    Console.WriteLine($"Security Event: File changed with event code: {eventCode}.\n");
                    break;

                case 4:
                    Console.WriteLine($"Security Event: File created with event code: {eventCode}.\n");
                    break;

                default:
                    Console.WriteLine($"Security Event: Unknown event code {eventCode}.");
                    break;
            }

        }

    }
}
