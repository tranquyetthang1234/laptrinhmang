using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginInfo;
namespace Server
{
    public partial class frmServer : Form
    {
        IPEndPoint serverIP;
        Socket server;
        List<Socket> clientList;
        List<Info> clientInfo;
        public frmServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        /// <summary>
        /// Nhận kết nối từ các client
        /// </summary>
        private void Connect()
        {
            clientList = new List<Socket>();
            clientInfo = new List<Info>();
            serverIP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(serverIP);

            /* Luồng nhận tin nhắn từ các client */
            Thread listen = new Thread(() =>
            {
                try
                {
                    /* mỗi lần lặp là lắng nghe một client */
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientList.Add(client);

                        byte[] data = new byte[1024];
                        client.Receive(data);

                        Info info = Info.Desserialize(data);
                        clientInfo.Add(info);
                        userList.Items.Add(info.Name);
                        txtTyping.Enabled = true;

                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch (Exception)
                {
                    serverIP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
            });
            listen.IsBackground = true;
            listen.Start();
        }

        /// <summary>
        /// Ngắt kết nối
        /// </summary>
        private void Close()
        {
            server.Close();
        }

        /// <summary>
        /// Thoát chương trình
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            foreach (Socket client in clientList)
                Send(client);
            AppendMessage(txtTyping.Text);
            txtTyping.Clear();
        }

        /// <summary>
        /// Xử lý gửi tin nhắn
        /// </summary>
        private void Send(Socket client)
        {
            if (txtTyping.Text != string.Empty && client != null)
                client.Send(Serialize(txtTyping.Text));
        }

        /// <summary>
        /// Xử lý nhận tin nhắn
        /// </summary>
        private void Receive(Object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    int size = client.Receive(data);
                    string message = Deserialize(data, size);
                    if (message.Contains("getList321"))
                    {
                        client.Send(Serialize("listHere452")); //xác nhận để chuẩn bị gửi danh sách info qua client
                        client.Send(Serialize(clientInfo.Count.ToString())); //gửi số lượng phần tử qua client
                        foreach (Info info in clientInfo)
                        {
                            if (info != null)
                                client.Send(info.Serialize());
                        }
                    }
                    else if (message.Contains("disconnect!123"))
                    {
                        data = new byte[1024 * 5000];
                        client.Receive(data);
                        Info info = Info.Desserialize(data);
                        clientInfo.Remove(info);
                        userList.Items.Remove(info.Name);
                    }
                    else
                    {
                        /* Nhận tin nhắn xong gửi cho toàn bộ các client còn lại */
                        foreach (Socket element in clientList)
                        {
                            if (element != null && element != client)
                                element.Send(Serialize(message));
                        }
                        AppendMessage(message);
                    }
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }
        }

        /// <summary>
        /// Thêm tin nhắn vào khung chat
        /// </summary>
        /// <param name="message"></param>
        void AppendMessage(string message)
        {
            txtShow.AppendText(message);
            txtShow.AppendText(Environment.NewLine);
        }

        /// <summary>
        /// Chuyển string thành mảng byte
        /// </summary>
        private byte[] Serialize(string s)
        {
            byte[] data = Encoding.ASCII.GetBytes(s);
            return data;
        }

        /// <summary>
        /// Chuyển mảng byte thành string
        /// </summary>
        private string Deserialize(byte[] data, int size)
        {
            string result = Encoding.ASCII.GetString(data, 0, size);
            return result;
        }
    }
}
