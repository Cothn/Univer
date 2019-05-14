using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClietn
{


    public partial class Form1 : Form
    {
        private static SslStream sslStream;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailSmtp.login = LoginBox.Text;
            MailSmtp.password = PassBox.Text;
            MailSmtp.LogBox = LogBox;
            LoginBox.Visible = false;
            PassBox.Visible = false;
            LogButt.Visible = false;
            LogOut.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            Send.Visible = true;
            sslStream = MailSmtp.ConnectSmtpServer("smtp.mail.ru", 465);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            LoginBox.Visible = true;
            PassBox.Visible = true;
            LogButt.Visible = true;
            LogOut.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            Send.Visible = false;
            MailSmtp.ExitSmtpAcount(sslStream);
        }

        private void Send_Click(object sender, EventArgs e)
        {
            string mess = "";
            if (ThemeBox.Text != "")
            { mess = "Subject: " + ThemeBox.Text + "\r\n";}
            mess = mess + MessBox.Text;
            MailSmtp.SendMail(sslStream, ToBox.Text, mess);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
