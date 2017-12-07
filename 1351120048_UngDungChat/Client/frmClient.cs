using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using LoginInfo;
namespace Client
{
    public partial class frmClient : Form
    {
        IPEndPoint serverIP;
        Socket client;
        Info information;
        Info infoFromServer;
        StreamReader rd;
        StreamWriter wr;
        int id;
        List<Info> clientInfo;
        public frmClient()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
            clientInfo = new List<Info>();
            rd = new StreamReader("id.txt");
            id = int.Parse(rd.ReadLine());
            rd.Close();
        }

        /// <summary>
        /// Kết nối tới server
        /// </summary>
        private void Connect()
        {
            serverIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(serverIP);
            }
            catch (Exception)
            {
                MessageBox.Show("Khong the ket noi den server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /* luồng nhận tin nhắn */
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        /// <summary>
        /// Ngắt kết nối khỏi server
        /// </summary>
        private void Close()
        {
            client.Close();
        }

        /// <summary>
        /// Gửi tin nhắn
        /// </summary>
        private void Send()
        {
            if (txtTyping.Text != string.Empty)
                client.Send(Serialize(txtTyping.Text));
        }

        /// <summary>
        /// Receive messages
        /// </summary>
        private void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024];
                    int size = client.Receive(data);
                    string s = Deserialize(data, size);
                    if (s.Contains("listHere452"))
                    {
                        listboxClient.Items.Clear();
                        data = new byte[1024];
                        size = client.Receive(data); //Nhận số lượng phần tử
                        int listSize = int.Parse(Deserialize(data, size));
                        for (int i = 0; i < listSize; i++)
                        {
                            client.Receive(data); //Nhận info
                            infoFromServer = Info.Desserialize(data);
                            if (information.Id != infoFromServer.Id)
                            {
                                listboxClient.Items.Add(infoFromServer.Name);
                                clientInfo.Add(infoFromServer);
                            }
                        }
                    }
                    else
                        AppendMessage(s);
                }
            }
            catch
            {
                Close();
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

        private void frmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
            AppendMessage(txtTyping.Text);
            txtTyping.Clear();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!txtUsername.Text.Equals(string.Empty))
            {
                if (client.Connected == false)
                    Connect();
                information = new Info(id, txtUsername.Text);
                byte[] infoData = information.Serialize();
                client.Send(infoData);
                txtTyping.Enabled = true;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                radioSendAll.Checked = true;
                wr = new StreamWriter("id.txt");
                id++;
                wr.WriteLine(id.ToString());
                wr.Close();
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Send(Serialize("disconnect!123"));
            client.Send(information.Serialize());
            Close();
            btnConnect.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            /* User muốn nhận danh sách các client hiện online */
            client.Send(Serialize("getList321"));
        }
    }
}
