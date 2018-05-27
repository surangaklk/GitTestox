using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ss = await meth1();
                log("after all in the click method resume");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"catch clause in button1 click - {ex.Message}");
            }
        }



        private async Task<string> meth1()
        {
            try
            {
                string result = "from meth1";
                log("meth1 - before all");                
                Task<string> longTask = Task.Run<string>(() => { return methLongTask(); });
                log($"meth1 - after long task call");                
                log($"meth1 - after long task call - another print");
                //Thread.Sleep(1000);
                log($"meth1 - after long task call - another print2- after 1 second delay");
                
                string resLongTask = await longTask;
                Thread.Sleep(10000);
                log($"meth1 - after 10000 delay");
                log($"meth1 - after AWATTING long task call - long result={resLongTask}");
                return $"{result} - {resLongTask}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"catch clause in meth1 - {ex.Message}");
                throw ex;
            }
        }

        private string meth2()
        {
            return "";
        }

        private string methLongTask()
        {
            //try
            //{
                log($"methLongTask - just enterd methLongTask");
                //int xx = int.Parse("asdfsdf");
                Thread.Sleep(6000);
                log($"methLongTask - just at end of methLongTask");
                return "methLongTask-after 6000 delay";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"catch clause in methLongTask - {ex.Message}");
            //    throw ex;
            //}            
        }

        private void log(string msg)
        {
            Console.WriteLine($"{msg} - {DateTime.Now.ToString("HH:mm:ss  ms")}");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    double j = Math.Sqrt(i + 1);
                    Console.WriteLine(j);
                }
            });
        }

        public async void myMeth()
        {
            string s = "";
            string rr = await Task.Run<string>(() => { return methLongTask(); });
        }
    }
}
