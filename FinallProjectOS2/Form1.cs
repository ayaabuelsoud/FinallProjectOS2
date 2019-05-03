using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace FinallProjectOS2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // --------- Open SOcial Media & google srearch
        private void button1_Click(object sender, EventArgs e)
        {
            void searchsocial(string t)
            {
                Process.Start("http://www.facebook.com/?q" + t);
                Process.Start("http://www.Twitter.com/?q" + t);
                Process.Start("http://www.instgram.com/?q" + t);
            }
            searchsocial("http://www.program.com/");
        }
        //---------- Search google 
        private void button6_Click(object sender, EventArgs e)
        {
            void searchgoogle(string t)
            {
                Process.Start("https://www.google.com/search?ei=bw_LXMbaJo-9UturoNAN&q=mohamed+salah&oq=mohamed+salah&gs_l=psy-ab.3..0l10.6390.13582..14126...1.0..3.141.2199.0j19......0....1..gws-wiz.....6..0i71j35i39j0i10i67j0i10j0i131i67j0i131j0i67j0i3.mkc0bPM-ETM" + t);
                Process.Start("http://www.google.com/?q" + t);

            }
            searchgoogle("http://www.program.com/");
        }
        //--------- open any program i want, ex: open new notepad
        private void button2_Click(object sender, EventArgs e)
        {
            string urprogram = textBox1.Text;
            Process var = new Process();
            var.StartInfo.FileName = urprogram;
            var.Start();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // open Files
        [STAThread]
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "c# corner open file dialog";
            fdlg.InitialDirectory = @"c:\";         // to open c:\
            fdlg.Filter = "All files (*.*)|*.*| All files (*.*)|*.* ";

            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                Process.Start(fdlg.FileName);

                string path = fdlg.FileName;

                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string text = sr.ReadToEnd(); //all text will be saved
                    }
                }
            }
        }
        // --- show me all process worked now
        private void button4_Click(object sender, EventArgs e) 
        {
            Process[] pros = Process.GetProcesses();
            foreach (var p in pros)
            {
                richTextBox1.Text += (p.ProcessName +": id= "+ p.Id +": " + p.PeakPagedMemorySize64) + "\n";
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        { }

        //---------  kill the process i want by name
        private void textBox2_TextChanged(object sender, EventArgs e)
        { }
        private void button5_Click(object sender, EventArgs e) 
        {
            Process[] proceToKilled = Process.GetProcessesByName(textBox1.Text);
            proceToKilled[0].Kill();
        }
        //________ Deal with file
 
        string file_path = "favMusic.txt";

        // content info
        private void button7_Click(object sender, EventArgs e)
        {
            if (File.Exists(file_path))
            {
                richTextBox2.Text = File.ReadAllText(file_path);
            }
            else
                MessageBox.Show("File not found");
            textBox7.Text = ("Num Line: "+numLine().ToString());
            textBox8.Text = ("Num World: "+numWords().ToString());
        }
        // change on content
        private void button8_Click(object sender, EventArgs e)
        {
            if (File.Exists(file_path))
            {
                string newcontent = richTextBox2.Text;
                File.WriteAllText(file_path, newcontent);
                if (newcontent == File.ReadAllText(file_path))
                {
                    MessageBox.Show("you've changed the content successfully");
                }
            }
            else
                MessageBox.Show("File not found");
            textBox7.Text = ("Num Line: "+numLine().ToString());
            textBox8.Text = ("Num World: " + numWords().ToString());

        }
        // Rename the file : Do not Forget .txt on the end of new name
        private void button9_Click(object sender, EventArgs e)
        {
            string new_name = textBox6.Text;
            File.WriteAllText(file_path, new_name);
            if (File.Exists(file_path) && new_name != string.Empty)
            {
                File.Move(file_path, new_name);
                if (File.Exists(new_name))
                {
                    MessageBox.Show("you've changed the name successfully");
                }
            }

        }
        
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        { }
        private void textBox6_TextChanged(object sender, EventArgs e)
        { }
        private void textBox7_TextChanged(object sender, EventArgs e)
        { }
        private void textBox8_TextChanged(object sender, EventArgs e)
        { }

        private
        //function for get number of lines
        int numLine()
        {
            if (File.Exists(file_path))
            {
                string[] lines = File.ReadAllLines(file_path);
                return lines.Length;
            }
            else
                MessageBox.Show("File not found");
            return 0;
        }
        //function for get number of words
        int numWords()
        {
            if (File.Exists(file_path))
            {
                string[] lines = File.ReadAllLines(file_path);
                string[] words = new string[lines.Length];
                int i = 0;
                foreach (var item in lines)
                {
                    if (item != " ")
                    {
                        words = item.Split();
                        i += words.Length;
                    }
                }
                return i;
            }
            else
                MessageBox.Show("File not found");
            return 0;
        }

        //____________ NETWORK_____________

        //--------- Get URL adress
        private void button10_Click(object sender, EventArgs e)
        {
            string HostName = textBox11.Text;
            IPAddress[] iPAddress = Dns.GetHostAddresses(HostName);
            foreach (IPAddress adress in iPAddress)
            {
                richTextBox3.Text = (HostName + adress);
            }

        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        { }
        private void richTextBox3_TextChanged(object sender, EventArgs e)
        { }

        // get Network interface info
        private void button11_Click(object sender, EventArgs e)
        {
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                richTextBox4.Text = ("network ID " + networkInterface.Id + "\n" + "network Name "
                    + networkInterface.Name + "\n" + "network description\n " + networkInterface.Description);
            }

        }
        private void richTextBox4_TextChanged(object sender, EventArgs e)
        { }

        //---Ping an ip address
        private void button13_Click(object sender, EventArgs e)
        {
            string pingAdress = textBox12.Text;
            Ping p = new Ping();
            PingReply reply = p.Send(pingAdress);

            richTextBox5.Text = ("Address :" + reply.Address + "\n"
                + "Buffer :" + reply.Buffer + "\n"
                + "Statues :" + reply.Status + "\n"
                + "Round Ttiptime :" + reply.RoundtripTime + "\n"
                + "#Network Nodes :" + reply.Options.Ttl + "\n");
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        { }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        { }
        // -----Download page and convert to text
        private void button12_Click(object sender, EventArgs e)
        {
            string adress = textBox13.Text;
            WebClient webClient = new WebClient();

            byte[] response = webClient.DownloadData("http://www." + adress + ".com");
            string str = System.Text.ASCIIEncoding.Default.GetString(response);
            richTextBox6.Text = (str);

        }
        private void textBox13_TextChanged(object sender, EventArgs e)
        { }
        private void richTextBox6_TextChanged(object sender, EventArgs e)
        { }

        //--- Download and save page 
        private void button14_Click(object sender, EventArgs e)
        {
            string adres = textBox14.Text;
            WebClient webClient = new WebClient();
            byte[] response = webClient.DownloadData("http://www." + adres + ".com");
            string content = System.Text.ASCIIEncoding.Default.GetString(response);
            richTextBox7.Text = ("test.txt"+ content);
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        { }
        private void richTextBox7_TextChanged(object sender, EventArgs e)
        { }
    }
}
