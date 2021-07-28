using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ardunioProject
{
    public partial class Form1 : Form
    {

        bool isOpenLed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM3"; //arduino hangi girişteyse onu yaz.
            serialPort1.BaudRate = 9600; //pc'nin varsayılan hızı

            serialPort1.Open();
            button2.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // isOpenLed = true;
            if (timer1.Enabled == false)
            { 
                timer1.Start();
                timer1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  serialPort1.
            serialPort1.Write("0");
            label1.Text = "LED OFF";
            button1.Enabled = true;
            button2.Enabled = false;

            timer1.Enabled = false;
            timer1.Stop();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //form kapatıldığında aynı zamanda port açıksa o da kapatılsın.
            if (serialPort1.IsOpen == true)
                serialPort1.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                //if (!isOpenLed)
                {
                    serialPort1.Write("1");
                    label1.Text = "LED ON";
                    button1.Enabled = false;
                    button2.Enabled = true;
                    isOpenLed = true;
                }

                // else
                {
                    byte[] read = new byte[1];
               //     int res = serialPort1.Read(read, 0, 1);
                 //   label1.Text = res.ToString();

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
          

        }
    }
}
