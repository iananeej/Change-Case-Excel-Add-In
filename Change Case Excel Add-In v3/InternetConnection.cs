using System.Runtime.InteropServices;

namespace Change_Case_Excel_Add_In_v3
{
    internal class InternetConnection
    {
        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int description, int reservedValue);

        //Creating a function that uses the API function...
        internal static bool IsConnected()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }
    }
}
