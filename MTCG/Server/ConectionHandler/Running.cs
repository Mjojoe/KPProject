using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server.ConectionHandler
{
    class Running
    {
        StreamHandler StreamHandler;
        InputConverter InputData;
        TcpClient ClientSocket;

        public Running()
        {
            StreamHandler = new();
            //Connection = new();
           
        }
        public void RunConnection()
        {
            NetworkStream clientStream = ClientSocket.GetStream();
            string message = StreamHandler.ReadStream(clientStream);

            //Console.WriteLine(message);

            if (message == null)
            {
                Console.WriteLine("Connection Error: Message could not be received");
                Connection.EndConnection(ClientSocket);
            }
            else
            {
                InputData = InputConverter.GetInputConverter();
                string[] splitMessage = InputData.ExtractData(message);

                CommandHandler commandHandler = new CommandHandler();

                if (splitMessage[0].Contains("POST"))
                {
                    Console.WriteLine(commandHandler.PostMethod(splitMessage));
                }
                else if (splitMessage[0].Contains("GET"))
                {
                    Console.WriteLine(commandHandler.GetMethod(splitMessage));
                }
                else if (splitMessage[0].Contains("PUT"))
                {
                    Console.WriteLine(commandHandler.PutMethod(splitMessage));
                }
                Connection.EndConnection(ClientSocket);
            }
            
        }
        public void RunThreads(TcpClient clientSocket)
        {
            ClientSocket = clientSocket;
            Thread ctThread = new Thread(RunConnection);
            ctThread.Start();
        }

    }
}
