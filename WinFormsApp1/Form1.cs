namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            this.TopMost = true;
            string curFile = "settings.txt";
            if (File.Exists(curFile)){
                using (var sr = new StreamReader(curFile))
                {
                    textBox2.Text = sr.ReadLine();
                }
                this.Hide();

            } 
            else
            {
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
          

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {


            using (var client = new HttpClient())
            {
                if (textBox2.Text == "") { }
                else
                {
                    var url = "https://api.ethermine.org/miner/" + textBox2.Text + "/dashboard";
                    string resultContent = await client.GetStringAsync(url);


                    var text = resultContent.Split(new[] { "currentHashrate\":" }, StringSplitOptions.None)[1];
                    var text2 = resultContent.Split(new[] { "status\":\"" }, StringSplitOptions.None)[1];
                    var text3 = resultContent.Split(new[] { "activeWorkers\":" }, StringSplitOptions.None)[1];
                    var text4 = resultContent.Split(new[] { "validShares\":" }, StringSplitOptions.None)[1];
                    label1.Text = "Hashrate: " + text.Substring(0, 3) + "." + text.Substring(3, 2);
                    label2.Text = "Status:" + text2.Substring(0, 2);
                    var workers = "Active Workers: " + text3.Substring(0, 2);
                    var shards = "Shards: " + text4.Substring(0, 4);
                    string cleanAmount = workers.Replace("}", string.Empty);
                    string cleanAmount2 = shards.Replace(",", string.Empty);
                    label3.Text = cleanAmount;
                    label4.Text = cleanAmount2;
                }
            }



        }
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //this.Location = MousePosition;
            timer2.Start();

        }
        private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            timer2.Stop();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(MousePosition.X, MousePosition.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}