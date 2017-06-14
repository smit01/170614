using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace test0614_readXML {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            System.Net.WebClient objWebClient = new System.Net.WebClient();
            objWebClient.DownloadFile(
                "https://udn.com/rssfeed/news/2/6638?ch=news",
                @"c:\temp\udn.xml");
            button1.Text = "OK";
        }

        private void button2_Click(object sender, EventArgs e) {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\temp\udn.xml");

            XmlNode objNodeRss = doc.SelectSingleNode("/rss");
            listBox1.Items.Add(objNodeRss.Attributes["version"].Value);

            XmlNode objNode = doc.SelectSingleNode("/rss/channel/title");
            if (objNode == null) { // not found
                listBox1.Items.Add("Not found");
                return;
            }
            listBox1.Items.Add(objNode.InnerText);

            XmlNodeList nodeList = doc.SelectNodes("/rss/channel/item");
            foreach (XmlNode node in nodeList) {
                string s = node.SelectSingleNode("./title").InnerText;
                listBox1.Items.Add(s);
            }

            button2.Text = "OK";
        }
    }
}
