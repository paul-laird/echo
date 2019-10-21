using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
	public static void Main()
        {
            Console.WriteLine("Starting echo server...");

            int port = 1234;
            TcpListener listener = new TcpListener(IPAddress.Loopback, port);
            listener.Start();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Handler h = new Handler(client);
                new Thread(h.run).Start();
            }
        }
    }
}

