using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SimpleChatUDP_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            EndPoint RemoteEp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000);
            Console.WriteLine("Da ket noi voi " + RemoteEp.ToString());
            byte[] notify = Encoding.ASCII.GetBytes("Ket noi thanh cong!");
            sck.SendTo(notify, RemoteEp);
            byte[] data = new byte[1024];
            int receive;
            string s;
            while (true)
            {
                Console.Write("Client: ");
                sck.SendTo(Encoding.ASCII.GetBytes(Console.ReadLine()), RemoteEp);
                receive = sck.ReceiveFrom(data, ref RemoteEp);
                s = Encoding.ASCII.GetString(data, 0, receive);
                if (s == "EXIT")
                {
                    sck.SendTo(Encoding.ASCII.GetBytes(s), RemoteEp);
                    sck.Close();
                    return;
                }
                Console.WriteLine("Server: " + Encoding.ASCII.GetString(data, 0, receive));
            }
        }
    }
}
