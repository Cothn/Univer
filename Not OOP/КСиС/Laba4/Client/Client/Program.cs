using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Net;
using System.Net.Sockets;

using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Client
{

    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                while (SendMessageFromSocket("smtp.yandex.ru", 465)) ;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
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
            byte[] BRecMess = new byte[1024]; ;
            int butesRec = Stream.Read(BRecMess, 0, BRecMess.Length);
            return Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
        }
        public static bool RemoteCertificateValidationCB(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // just returning True for any validation
            return true;
        }
        static bool SendMessageFromSocket(string Host, int port)
        {

            bool otv = false;
            String SRecMess;
            IPHostEntry ipHostEntry = null;

            //установка удаленной точки для сокета 217.69.139.160 //94.100.180.160
            ipHostEntry = Dns.GetHostEntry(Host);
            if (ipHostEntry == null || ipHostEntry.AddressList == null || ipHostEntry.AddressList.Length <= 0)
                throw new Exception("Не удалось определить IP-адрес по хосту.");
            IPAddress ipAddr = ipHostEntry.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            TcpClient client = new TcpClient();
            //client.Connect(ipEndPoint);
            client.Connect(ipEndPoint);
            //TcpClient client = new TcpClient(Host, port);
            //SslStream sslStream = new SslStream(client.GetStream(), false);
            //sslStream.ReadTimeout = 5000;
            //sslStream.WriteTimeout = 5000;
            SslStream sslStream;
            sslStream = new SslStream(client.GetStream(), false, RemoteCertificateValidationCB);
            // Аутентификация
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
            sslStream.ReadTimeout = 500;  // Тут еще не определился, какой таймаут выставлять
            sslStream.WriteTimeout = 500;

            //Сoздаем сокет Tcp/Ip
            //Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //Соеденяемся с удаленной точкой
            //sender.Connect(ipEndPoint);
            Console.WriteLine("Сокет соединяется с {0}", ipEndPoint);

            //butesRec = sender.Receive(BRecMess);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

            ////получаем свой ip
            string strHostName = Dns.GetHostName();
            IPHostEntry ipHostC = Dns.GetHostEntry(strHostName);
            IPAddress ipAddrC = ipHostEntry.AddressList[0];


            //// начало общения
            SendCommand( "EHLO " + ipAddrC.ToString() + "", sslStream);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

            //// Аутентификация            string enText = Convert.ToBase64String(simpleTextBytes);
            SendCommand("AUTH LOGIN", sslStream);
            SRecMess = RecOtv(sslStream).Substring(4);
            var enTextBytes = Convert.FromBase64String(SRecMess);
            SRecMess = Encoding.UTF8.GetString(enTextBytes);
            Console.WriteLine(SRecMess);

            //// логин
            var Base64TextBytes = Encoding.UTF8.GetBytes("KsisLaba4");
            String Base64Text = Convert.ToBase64String(Base64TextBytes);
            SendCommand( Base64Text, sslStream);
            SRecMess = RecOtv(sslStream).Substring(4);
            enTextBytes = Convert.FromBase64String(SRecMess);
            SRecMess = Encoding.UTF8.GetString(enTextBytes);
            Console.WriteLine(SRecMess);

            //// пароль
            Base64TextBytes = Encoding.UTF8.GetBytes("KsisLaba4321");
            Base64Text = Convert.ToBase64String(Base64TextBytes);
            SendCommand(Base64Text, sslStream);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

            //// Отправитель
            SendCommand("MAIL FROM:<" + "KsisLaba4@yandex.ru" + ">", sslStream);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

            ////Получатель
            SendCommand("RCPT TO:<" + "KsisLaba4@yandex.ru" + ">", sslStream);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

            ////Сообщаем о начале письма
            SendCommand("DATA", sslStream);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

            ////Письмо
            SendCommand("Test Cotn\r\n.", sslStream);
            //SendCommand(".", sslStream);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

            ////Конец
            SendCommand("QUIT", sslStream);
            SRecMess = RecOtv(sslStream);
            Console.WriteLine(SRecMess);

            ////Сообщаем о начале письма
            //BSendMess = Encoding.UTF8.GetBytes("DATA"+"\r\n");
            //bytesSent = sender.Send(BSendMess);
            //BRecMess = new byte[1024];
            //butesRec = sender.Receive(BRecMess);
            //SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            //Console.WriteLine(SRecMess);

            ////Письмо
            //BSendMess = Encoding.UTF8.GetBytes("Test Cotn" + "\r\n." + "\r\n");
            //bytesSent = sender.Send(BSendMess);
            //BRecMess = new byte[1024];
            //butesRec = sender.Receive(BRecMess);
            //SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            //Console.WriteLine(SRecMess);

            ////Конец
            //BSendMess = Encoding.UTF8.GetBytes("QUIT"+"\r\n");
            //bytesSent = sender.Send(BSendMess);
            //BRecMess = new byte[1024];
            //butesRec = sender.Receive(BRecMess);
            //SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            //Console.WriteLine(SRecMess);

            


            ////Освобождаем сокет
            //sender.Shutdown(SocketShutdown.Both);
            //sender.Close();


            return otv;

        }
    }
}