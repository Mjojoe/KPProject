using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Server.ConectionHandler;

namespace Server
{
    internal class Server
    {
        public static void Main(string[] args)
        {
            Connection client = new Connection();
            client.BuildTheConnection();
        }
    }
}
