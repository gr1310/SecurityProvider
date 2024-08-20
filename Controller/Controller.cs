using SecurityProviderModule;

namespace ControllerModule
{
    public class Controller
    {
        List<ISecurityProvider> CreateInstances()
        {
            List<ISecurityProvider> ActiveSecurityProviders= new List<ISecurityProvider>();

            String SelectedEnv = "Home";

            if (SelectedEnv == "Org")
            {
                ISecurityProvider antiVirusSecurity = new AntiVirusSecurityProvider();
                ISecurityProvider accountSecurity = new AccountSecurityProvider();
            }

            else if (SelectedEnv == "Home")
            {
                ISecurityProvider accountSecurity = new AccountSecurityProvider();
            }

            return ActiveSecurityProviders;
        }
    }
}
