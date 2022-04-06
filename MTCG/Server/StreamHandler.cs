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
            try {
                int i = 0;
                string clientMessage = null;
                byte[] bytes = new byte[8192];

                while ((i = clientStream.Read(bytes, 0, bytes.Length))!=0)
                {
                    clientMessage = Encoding.ASCII.GetString(bytes, 0, i);
                    return clientMessage;
                }
            }
            catch (Exception e) {
                Console.WriteLine("Error: " + e.Message);
            }
            return null;
        }
    }
}
