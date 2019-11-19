using System;
using System.IO;
using System.Net.Sockets;

namespace TcpChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Client side of a TCP chat server.
            TcpClient clientSocket = new TcpClient("127.0.0.1", 6789);
            Console.WriteLine("Client started!");
            NetworkStream ns = clientSocket.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader st = new StreamReader(ns);
            sw.AutoFlush = true;

            while (true)
            {
                string message = Console.ReadLine();
                sw.WriteLine(message);
                string message1 = st.ReadLine();
                Console.WriteLine("Server: " + message1);
                
                
                if (message1 == "EXIT")
                {
                    Console.ReadLine();
                    ns.Close();
                    clientSocket.Close();
                    return;
                }

            }
            

        }
    }
}
