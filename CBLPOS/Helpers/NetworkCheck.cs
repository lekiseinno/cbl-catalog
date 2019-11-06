using System;
using Plugin.Connectivity;
namespace CBLPOS.Helpers
{
    public static class NetworkCheck
    {
        public static bool IsInternet()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
