using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "settings.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(textBox1.Text);
                }
            }
            else
            {
                using (StreamWriter sr = File.CreateText(path))
                {
                    sr.WriteLine(textBox1.Text);
                }
                this.Hide();
                Form1 f2 = new Form1();
                f2.ShowDialog();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string curFile = "settings.txt";
            if (File.Exists(curFile))
            {
                using (var sr = new StreamReader(curFile))
                {
                    textBox1.Text = sr.ReadLine();
                }
                this.Hide();

            }
        }
    }
}
