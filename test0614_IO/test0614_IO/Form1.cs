using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace test0614_IO {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Directory.CreateDirectory(@"c:\abc\123\456\789");
            Directory.Delete(@"c:\abc\123\456\789");
            Directory.Delete(@"c:\abc\123\456");
            Directory.Delete(@"c:\abc\123");
            Directory.Delete(@"c:\abc");
            button1.Text = "OK";
        }

        private void button2_Click(object sender, EventArgs e) {
            DirectoryInfo di = new DirectoryInfo(@"c:\temp");
            FileInfo[] fileList = di.GetFiles("*.txt", SearchOption.AllDirectories);
            foreach (FileInfo f in fileList) {
                textBox1.Text += f.FullName + "\r\n";
            }

        }

        private void button3_Click(object sender, EventArgs e) {
            // File.Copy(@"c:\temp\test1.txt", @"c:\temp\test2.txt");
            FileInfo fi = new FileInfo(@"c:\temp\test1.txt");
            if (File.Exists(@"c:\temp\test2.txt")) {
                DialogResult answer = MessageBox.Show("Overwrite?", "Asking", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes) {
                    fi.CopyTo(@"c:\temp\test2.txt", true);
                }
            }
            
        }
    }

    class CTest {
        public CTest(int value) {

        }
    }


}
