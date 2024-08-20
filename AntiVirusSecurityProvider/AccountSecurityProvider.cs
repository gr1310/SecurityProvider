namespace SecurityProviderModule
{
    public class AccountSecurityProvider : ISecurityProvider
    {
        public bool Scan()
        {
            return true;
        }
    }
}
