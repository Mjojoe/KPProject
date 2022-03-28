using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class StreamHandler
    {
        public StreamHandler() { }

        //Reads and returns the NetworkStream
        public string ReadStream(NetworkStream clientStream)
        {
            int i = 0;
            string clientMessage = null;

            byte[] bytes = new byte[10025];

            while (clientStream.DataAvailable)
            {
                i = clientStream.Read(bytes, 0, bytes.Length);
                clientMessage = Encoding.ASCII.GetString(bytes, 0, i);

            }
            // Console.WriteLine(clientMessage);
            clientStream.Flush();
            if (clientMessage == null)
            {
                return null;
            }
            return clientMessage;
        }
    }
}
