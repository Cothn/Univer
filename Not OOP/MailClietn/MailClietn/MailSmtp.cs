using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;


namespace MailClietn
{
    class MailSmtp
    {
        public static string login;
        public static string password;
        public static Stream LogStream;
        public static bool SendCommand(String command, SslStream Stream)
        {

            byte[] commandBytes = System.Text.Encoding.UTF8.GetBytes(String.Format("{0}\r\n", command));

            // Пишем команду для сервера
            Stream.Write(commandBytes, 0, commandBytes.Length);
            Stream.Flush(); // Записывает содержимое потока

            return true;
        }
        public static String RecOtv(SslStream Stream)
        {
            // Получаем ответ
            byte[] BRecMess = new byte[1024]; ;
            int butesRec = Stream.Read(BRecMess, 0, BRecMess.Length);
            return Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
        }
        public static bool RemoteCertificateValidationCB(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // just returning True for any validation
            return true;
        }
        public static SslStream ConnectSmtpServer(string Host, int port)
        {
            //bool otv = false;
            String SRecMess;
            IPHostEntry ipHostEntry = null;

            //установка удаленной точки для сокета
            ipHostEntry = Dns.GetHostEntry(Host);
            if (ipHostEntry == null || ipHostEntry.AddressList == null || ipHostEntry.AddressList.Length <= 0)
                throw new Exception("Не удалось определить IP-адрес по хосту.");
            IPAddress ipAddr = ipHostEntry.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            TcpClient client = new TcpClient();


            //Соеденяемся с удаленной точкой
            client.Connect(ipEndPoint);
            Console.WriteLine("Сокет соединяется с {0}", ipEndPoint);

            //Создаем ssl поток
            SslStream sslStream;
            sslStream = new SslStream(client.GetStream(), false, RemoteCertificateValidationCB);
            // Аутентификация ssl
            try
            {
                sslStream.AuthenticateAsClient(Host);
            }
            catch (Exception ex)
            {
                client.Close();
                throw ex;
            }

            if (sslStream.IsAuthenticated == false)
            {
                client.Close();
                throw new Exception("Аутентификация не была пройдена.");
            }
            sslStream.ReadTimeout = 5000;
            sslStream.WriteTimeout = 5000;

            //butesRec = sender.Receive(BRecMess);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

            ////получаем свой ip
            string strHostName = Dns.GetHostName();
            IPHostEntry ipHostC = Dns.GetHostEntry(strHostName);
            IPAddress ipAddrC = ipHostEntry.AddressList[0];


            //// начало общения
            SendCommand("EHLO " + ipAddrC.ToString() + "", sslStream);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

            //// Аутентификация       
            SendCommand("AUTH LOGIN", sslStream);
            SRecMess = RecOtv(sslStream).Substring(4);
            var enTextBytes = Convert.FromBase64String(SRecMess);
            SRecMess = Encoding.UTF8.GetString(enTextBytes);
            Console.WriteLine(SRecMess);

            //// логин
            var Base64TextBytes = Encoding.UTF8.GetBytes("ksis_laba4@mail.ru");
            String Base64Text = Convert.ToBase64String(Base64TextBytes);
            SendCommand(Base64Text, sslStream);
            SRecMess = RecOtv(sslStream).Substring(4);
            enTextBytes = Convert.FromBase64String(SRecMess);
            SRecMess = Encoding.UTF8.GetString(enTextBytes);
            Console.WriteLine(SRecMess);

            //// пароль
            Base64TextBytes = Encoding.UTF8.GetBytes("25g25g2000g");
            Base64Text = Convert.ToBase64String(Base64TextBytes);
            SendCommand(Base64Text, sslStream);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

            return sslStream;
        }
        public static void SendMail(SslStream sslStream)
        {
            ////получаем свой ip
            String SRecMess;

            //// Отправитель
            SendCommand("MAIL FROM:<" + "ksis_laba4@mail.ru" + ">", sslStream);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

            ////Получатель
            SendCommand("RCPT TO:<" + "ksis_laba4@mail.ru" + ">", sslStream);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

            ////Сообщаем о начале письма
            SendCommand("DATA", sslStream);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

            ////Письмо
            SendCommand("Test Cotn1\r\nTest\r\n.", sslStream);
            //SendCommand(".", sslStream);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

        }
        public static void ExitSmtpAcount(SslStream sslStream)
        {
            ////Конец
            SendCommand("QUIT", sslStream);
            Console.WriteLine(RecOtv(sslStream));

            sslStream.Close();
            //client.Close();
        }
    }
}
