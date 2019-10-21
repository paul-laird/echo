using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Echo
{
    class Client { 
// This code is adapted from a sample found at the URL 
// "http://blogs.msdn.com/b/jmanning/archive/2004/12/19/325699.aspx"
        static void Main(string[] args)
        {
            Console.WriteLine("Starting echo client...");

            int port = 1234;
            TcpClient client = new TcpClient("localhost", port);
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };

            while (true)
            {
                Console.Write("Enter to send: ");
                string lineToSend = Console.ReadLine();
                Console.WriteLine("Sending to server: " + lineToSend);
                writer.WriteLine(lineToSend);
                string lineReceived = reader.ReadLine();
                Console.WriteLine("Received from server: " + lineReceived);
            }
            
        }
    }
}
