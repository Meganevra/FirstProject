using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(Properties.Settings.Default.Path))
                {
                    StreamReader objReader = new StreamReader(Properties.Settings.Default.Path);
                    string sLine = "";
                    ArrayList arrText = new ArrayList();
                    while (sLine != null)
                    {
                        sLine = objReader.ReadLine();
                        if (sLine != null)
                            arrText.Add(sLine);
                    }
                    objReader.Close();
                    Ping ping = new System.Net.NetworkInformation.Ping();
                    PingReply pingReply = null;
                    int i = 0;
                    int j = 1;
                    while (i < arrText.Count)
                    {
                        (Controls["label" + j.ToString()] as Label).Text = arrText[i + 1].ToString();
                        pingReply = ping.Send(arrText[i].ToString());
                        if (pingReply.Status == IPStatus.Success)
                        {
                            (Controls["TextBox" + j.ToString()] as TextBox).Text = "OK";
                        }
                        else
                        {
                            (Controls["TextBox" + j.ToString()] as TextBox).Text = "FAIL";
                        }
                        i = i + 2;
                        j = j + 1;
                    }
                }
                else
                {
                    ErrorBox.Visible = true;
                    ErrorBox.Text = "Wrong path to txt document";
                    button4.Visible = true;
                    
                }
            }
            catch
            {
                
                Console.WriteLine("Error" );
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 8; i++)
            {
                (Controls["TextBox" + i.ToString()] as TextBox).Text = "";
            }
            ErrorBox.Text = "";
            ErrorBox.Visible = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Properties.Settings.Default.Path = openFileDialog1.FileName;
            Properties.Settings.Default.Save();
            button2_Click(sender, e);
            button1_Click(sender, e);
        }
    }
}
