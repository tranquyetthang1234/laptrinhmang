using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SimpleChatUDP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint localep = new IPEndPoint(IPAddress.Any, 9000);
            sck.Bind(localep);
            Console.WriteLine("Dang cho ket noi tu client...");
            EndPoint RemoteEp = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = new byte[1024];
            int receive = sck.ReceiveFrom(data, ref RemoteEp);
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, receive));
            string s;
            while (true)
            {
                data = new byte[1024];
                receive = sck.ReceiveFrom(data, ref RemoteEp);
                s = Encoding.ASCII.GetString(data, 0, receive);
                if (s == "EXIT")
                {
                    /* Khi nhận được chuỗi EXIT thì gửi ngược lại chuỗi đó cho Client để Client cũng thoát */
                    sck.SendTo(Encoding.ASCII.GetBytes(s), RemoteEp);
                    sck.Close();
                    return;
                }
                Console.WriteLine("Client: " + Encoding.ASCII.GetString(data, 0, receive));
                Console.Write("Server: ");
                sck.SendTo(Encoding.ASCII.GetBytes(Console.ReadLine()), RemoteEp);
            }
        }
    }
}
