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
        private List<TcpClient> clients;

        public Handler(TcpClient client, List<TcpClient> clients)
        {
            this.client = client;
            this.clients = clients;
        }

        public void run()
        {
            NetworkStream stream = client.GetStream();
            //StreamWriter writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);

            string inputLine = "";
            try
            {
                while (inputLine != null)
                {
                    inputLine = reader.ReadLine();
                    foreach(TcpClient client in clients) {
                        try
                        {
                            NetworkStream stream1 = client.GetStream();
                            StreamWriter writer = new StreamWriter(stream1, Encoding.ASCII) { AutoFlush = true };

                            writer.WriteLine("Echoing string: " + inputLine);
                            Console.WriteLine("Echoing string: " + inputLine);
                        }
                        catch (IOException)
                        {
                            Console.WriteLine("Dead client");
                        }
                    }
                }
                Console.WriteLine("Server saw disconnect from client.");
                clients.Remove(client);
            }
            catch (IOException)
            {
                Console.WriteLine("Server saw disconnect from client.");
                clients.Remove(client);
            }
        }
    }
}
