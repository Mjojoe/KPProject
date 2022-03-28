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
                while (true)
                {
                    count++;
                    Console.WriteLine("\nWaiting for connection...");
                    TcpClient ClientSocket = Listener.AcceptTcpClient();
                    //hier den thread starten und sagen er soll die nächste line ausführen
                    Console.WriteLine(count + ": Client Connectet!");
                    Running ConnectionRunner = new Running();
                    ConnectionRunner.HandleThreads(ClientSocket);
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

        public void EndConnection(TcpClient clientSocket)
        {
            clientSocket.Close();
        }


    }//end of class
}
