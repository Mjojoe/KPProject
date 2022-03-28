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
        //DataConverter ConvertData;
        Connection Connection;

        TcpClient ClientSocket;
        public Running()
        {
            StreamHandler = new StreamHandler();
            Connection = new Connection();
        }
        public void RunTheConnection()
        {
            string message = null;

            NetworkStream clientStream = ClientSocket.GetStream();

            message = StreamHandler.ReadStream(clientStream);

            Console.WriteLine(message);

            //Check if message was succesfully received
            /*
            if (message == null)
            {
                Console.WriteLine("Connection Error: Message could not be received");
                Connection.EndConnection(ClientSocket);
            }
            else
            {
                ConvertData = DataConverter.GetDataConverter();
                string[] splitMessage = ConvertData.ExtractData(message);


                CommandHandler commandHandler = new CommandHandler();
                string returnMessage = null;

                //go to right http method
                if (splitMessage[0].Contains("POST"))
                {

                    returnMessage = commandHandler.PostMethod(splitMessage);

                }
                else if (splitMessage[0].Contains("GET"))
                {
                    // token in header
                    returnMessage = commandHandler.GetMethod(splitMessage);

                }
                else if (splitMessage[0].Contains("PUT"))
                {
                    //daten und token?
                    returnMessage = commandHandler.PutMethod(splitMessage);
                }
                //zuesrt hole ich das kommand heraus aus der message


                if (returnMessage != null)
                {
                    StreamWriting sendMessage = new StreamWriting();
                    sendMessage.WriteStream(returnMessage, clientStream);
                }



                ConnectionEnd.EndTheConnection(ClientSocket);
            }
            */

        }
        public void HandleThreads(TcpClient clientSocket)
        {
            ClientSocket = clientSocket;
            Thread ctThread = new Thread(RunTheConnection);
            ctThread.Start();
        }
    }
}
