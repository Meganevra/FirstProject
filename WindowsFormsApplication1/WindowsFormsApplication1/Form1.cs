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
using System.Windows.Forms;

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
            // создаем процесс cmd.exe с параметрами "ipconfig /all"
            
    ProcessStartInfo psiOpt = new ProcessStartInfo(@"cmd.exe", @"/C ipconfig /all");
            
    // скрываем окно запущенного процесса

    psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
           
    psiOpt.RedirectStandardOutput = true;
            
    psiOpt.UseShellExecute = false;
            
    psiOpt.CreateNoWindow = true;
            
    // запускаем процесс

    Process procCommand = Process.Start(psiOpt);
            
    // получаем ответ запущенного процесса

    StreamReader srIncoming = procCommand.StandardOutput;
           
    // выводим результат

    Console.WriteLine(srIncoming.ReadToEnd());
            
    // закрываем процесс

    procCommand.WaitForExit();
    Console.ReadKey();

        }
    }
}
