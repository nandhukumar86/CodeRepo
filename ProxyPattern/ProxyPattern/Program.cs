using System;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerProxyToLog server = new ServerProxyToLog();
            server.HandleRequest();
        }


        /*
         * Proxy Pattern
         * -------------
         * Copy the functionality of the Subject and do some modifications and use the new subject
         * 
         * Ex. Server is handling a request, but we need to introduce logging when the server is handling it.
         * 
         */

        public interface IServer
        {
            void HandleRequest();
        }

        public class Server : IServer
        {
            public void HandleRequest()
            {
                Console.WriteLine("Server is Handling the Request");
            }
        }


        // 1. Create Proxy Server
        public class ServerProxyToLog : IServer
        {
            Server server = new Server();
            public void HandleRequest()
            {
                Console.WriteLine($"Logging request at {DateTime.Now}");
                server.HandleRequest();

            }
        }

    }
}
