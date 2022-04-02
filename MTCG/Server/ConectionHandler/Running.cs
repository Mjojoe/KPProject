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
        StreamHandler streamHandler;
        InputConverter inputData;
        Connection connection;

        TcpClient clientSocket;
        public Running()
        {
            streamHandler = new();
            connection = new();
        }
        public void RunConnection()
        {
            NetworkStream clientStream = clientSocket.GetStream();
            string message = streamHandler.ReadStream(clientStream);

            //Console.WriteLine(message);

            if (message == null)
            {
                Console.WriteLine("Connection Error: Message could not be received");
                Connection.EndConnection(clientSocket);
            }
            else
            {
                inputData = InputConverter.GetInputConverter();
                string[] splitMessage = inputData.ExtractData(message);

                CommandHandler commandHandler = new CommandHandler();

                if (splitMessage[0].Contains("POST"))
                {
                    commandHandler.PostMethod(splitMessage);
                }
                else if (splitMessage[0].Contains("GET"))
                {
                    commandHandler.GetMethod(splitMessage);
                }
                else if (splitMessage[0].Contains("PUT"))
                {
                    commandHandler.PutMethod(splitMessage);
                }
                Connection.EndConnection(clientSocket);
            }
            
        }

    }
}
