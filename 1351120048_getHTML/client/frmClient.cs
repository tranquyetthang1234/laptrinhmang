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
using System.Xml;
using System.Collections;

namespace client
{
    public partial class frmClient : Form
    {
        ArrayList list;
        public frmClient()
        {
            InitializeComponent();
            list = new ArrayList();
        }

        delegate void UpdateGUI(string s);

        void UpdateTextBox(string s)
        {
            txtHTML.Text += s + "\r\n";
        }

        void OutputText(string s)
        {
            txtHTML.Invoke(new UpdateGUI(UpdateTextBox), new object[] { s });
        }

        /// <summary>
        /// Show dữ liệu của url khi bấm nút Get Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getData_Click(object sender, EventArgs e)
        {
            string link = txtURL.Text;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string content = sr.ReadToEnd();
            sr.Close();
            XmlReader reader = XmlReader.Create(new StringReader(content));
            reader.ReadToFollowing("ratelist");
            reader.MoveToFirstAttribute(); //thuoc tinh "updated"
            OutputText("Cap nhat luc: " + reader.Value);
            reader.MoveToNextAttribute(); // Thuoc tinh unit
            OutputText("Don vi tinh: " + reader.Value);

            while (reader.ReadToFollowing("city"))
            {
                reader.MoveToFirstAttribute();
                City city = new City();
                city.Name = reader.Value;
                OutputText("Thanh pho: " + reader.Value);
                cbCity.Items.Add(city.Name);
                reader.MoveToElement();
                XmlReader r = reader.ReadSubtree();
                while (r.ReadToFollowing("item"))
                {
                    Item item = new Item();
                    r.MoveToFirstAttribute();//buy
                    item.Buy = float.Parse(reader.Value);
                    OutputText("Gia mua: " + reader.Value);
                    r.MoveToNextAttribute(); //sell
                    item.Sell = float.Parse(reader.Value);
                    OutputText("Gia ban: " + reader.Value);
                    r.MoveToNextAttribute(); //type
                    item.Type = reader.Value;
                    OutputText("Gia ban: " + reader.Value);
                    city.List.Add(item);
                }
                list.Add(city);
            }
        }


        /// <summary>
        /// Xử lý khi người dùng chọn thành phố
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHTML.Clear();
            foreach (City element in list)
            {
                if (element.Name.Equals(cbCity.Text))
                {
                    OutputText("City: " + element.Name);
                    foreach (Item item in element.List)
                    {
                        OutputText("Gia mua: " + item.Buy);
                        OutputText("Gia ban: " + item.Sell);
                        OutputText("Loai: " + item.Type);
                    }
                }
            }
        }
    }
}
