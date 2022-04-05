using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Server.ConectionHandler
{
    class Connection
    {
        TcpListener Listener;
        

        public TcpClient ClientSocket { get; private set; }

        public Connection()
        {
            Listener = null;
            
        }

        public void BuildTheConnection()
        {
            try
            {
                Listener = new TcpListener(IPAddress.Loopback, 10001);
                Listener.Start(5);
                Console.CancelKeyPress += (sender, e) => Environment.Exit(0);
                int count = 0;
                Console.WriteLine("\nWaiting for connection...");

                while (true)
                {
                    count++;
                    TcpClient ClientSocket = Listener.AcceptTcpClient();
                    Console.WriteLine("\n"+count + ": Client Connectet!");
                    Running runner = new();
                    runner.RunThreads(ClientSocket);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e}");
            }
            catch (Exception exc)
            {
                Console.WriteLine($"error occurred: {exc.Message}");
            }
            finally
            {
                Listener.Stop();
            }

        }

        public static void EndConnection(TcpClient clientSocket)
        {
            clientSocket.Close();
        }
    }
}
