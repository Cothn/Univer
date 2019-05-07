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
                while (SendMessageFromSocket("smtp.yandex.ru", 25)) ;

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
        void SendCommand(string command, SslStream Stream)
        {

            byte[] commandBytes = System.Text.Encoding.ASCII.GetBytes(String.Format("{0}\r\n", command));

            // Пишем команду для сервера
            Stream.Write(commandBytes, 0, commandBytes.Length);
            Stream.Flush(); // Записывает содержимое потока
        }
        static bool SendMessageFromSocket(string Host, int port){
            
            bool otv = false;
            //byte[] BSendMess;
            //int bytesSent;
            //byte[] BRecMess;
            //int butesRec;
            //String SRecMess;
            IPHostEntry ipHost = null;

            //установка удаленной точки для сокета 217.69.139.160 //94.100.180.160
            ipHost = Dns.GetHostEntry(Host);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            TcpClient client = new TcpClient();
            client.Connect(ipEndPoint);
            //TcpClient client = new TcpClient(Host, port);
            //SslStream sslStream = new SslStream(client.GetStream(), false);
            //sslStream.ReadTimeout = 5000;
            //sslStream.WriteTimeout = 5000;
            SslStream sslStream;
            sslStream = new SslStream(client.GetStream(), false);
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
            //BRecMess = new byte[1024];

            ////string messageData = ReadMessage(sslStream);
            ////Console.WriteLine("Received: {0}", messageData);
            //butesRec = sender.Receive(BRecMess);
            //SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            //Console.WriteLine(SRecMess);

            ////получаем свой ip
            string strHostName = Dns.GetHostName();
            IPHostEntry ipHostC = Dns.GetHostEntry(strHostName);
            IPAddress ipAddrC = ipHost.AddressList[0];



            //// начало общения
            //BSendMess = Encoding.UTF8.GetBytes("EHLO " + ipAddrC.ToString() + "\r\n");
            ////BSendMess = Encoding.UTF8.GetBytes("HELO "+"<cothnpir@mail.ru>"+"\r\n");
            ////BSendMess = Encoding.UTF8.GetBytes("HELO " + "smtp.testbox" + "\r\n");
            //bytesSent = sender.Send(BSendMess);
            //BRecMess = new byte[4096];
            //butesRec = sender.Receive(BRecMess);
            //SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            //Console.WriteLine(SRecMess);

            //// запуск TSL
            //BSendMess = Encoding.UTF8.GetBytes("STARTTLS" + "\r\n");
            //bytesSent = sender.Send(BSendMess);
            //BRecMess = new byte[1024];
            //butesRec = sender.Receive(BRecMess);
            //SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            //Console.WriteLine(SRecMess);

            //// Аутентификация
            //BSendMess = Encoding.UTF8.GetBytes("AUTH" + "\r\n");
            //bytesSent = sender.Send(BSendMess);
            //BRecMess = new byte[1024];
            //butesRec = sender.Receive(BRecMess);
            //SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            //Console.WriteLine(SRecMess);

            //// Отправитель
            //BSendMess = Encoding.UTF8.GetBytes("MAIL FROM:<" + "sevkaa-0013@mail.ru" + ">\r\n");
            //bytesSent = sender.Send(BSendMess);
            //BRecMess = new byte[1024];
            //butesRec = sender.Receive(BRecMess);
            //SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            //Console.WriteLine(SRecMess);

            ////Получатель
            //BSendMess = Encoding.UTF8.GetBytes("RCPT TO:" + "<sevkaa-0013@mail.ru>" + "\r\n");
            //bytesSent = sender.Send(BSendMess);
            //BRecMess = new byte[1024];
            //butesRec = sender.Receive(BRecMess);
            //SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            //Console.WriteLine(SRecMess);

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

