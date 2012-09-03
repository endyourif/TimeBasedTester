using System.Net;

namespace TimeBasedTester
{
    class CheckLink
    {
        public static void ReadUrl(string uri)
        {
            //Create the request object
            WebRequest req = WebRequest.Create(uri);
            req.GetResponse();
        }
    }
}