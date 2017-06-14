using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace test0614_ReadWriteJSON {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            TLocation obj = new TLocation() { X = 100, Y = 200, Name = "TC" };
            string s = JsonConvert.SerializeObject(obj);
            textBox1.Text = s;
            // {"X":100,"Y":200,"Name":"TC"}
        }

        private void button2_Click(object sender, EventArgs e) {
            string s = textBox1.Text;
            TLocation obj = JsonConvert.DeserializeObject<TLocation>(s);
            button2.Text = obj.Name;
        }
    }

    public class TLocation {
        private int test = 101;
        public int X { set; get; }
        public int Y { set; get; }
        public string Name { set; get; }
        public int getTest() {
            return this.test;
        }
    }


}
