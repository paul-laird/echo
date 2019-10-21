using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Handler
    {
        private TcpClient client;

        public Handler(TcpClient client)
        {
            this.client = client;
        }

        public void run()
        {
            NetworkStream stream = client.GetStream();
            StreamWriter writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);

            string inputLine = "";
            try
            {
                while (inputLine != null)
                {
                    inputLine = reader.ReadLine();
                    writer.WriteLine("Echoing string: " + inputLine);
                    Console.WriteLine("Echoing string: " + inputLine);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Server saw disconnect from client.");
            }
        }
    }
}
