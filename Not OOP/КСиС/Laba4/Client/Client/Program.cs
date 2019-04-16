using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Net;
using System.Net.Sockets;

namespace Client
{

    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                while (SendMessageFromSocket("smtp.mail.ru", 25)) ;

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

        static bool SendMessageFromSocket(string Host, int port){
            
            bool otv = false;
            byte[] BSendMess;
            int bytesSent;
            byte[] BRecMess;
            int butesRec;
            String SRecMess;
            IPHostEntry ipHost = null;

            //установка удаленной точки для сокета 217.69.139.160 //94.100.180.160
            ipHost = Dns.GetHostEntry(Host);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            //Сoздаем сокет Tcp/Ip
            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);


            //Соеденяемся с удаленной точкой
            sender.Connect(ipEndPoint);
            Console.WriteLine("Сокет соединяется с {0}", ipEndPoint);
            BRecMess = new byte[1024];
            butesRec = sender.Receive(BRecMess);
            SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            Console.WriteLine(SRecMess);

            //получаем свой ip
            string strHostName = Dns.GetHostName();
            IPHostEntry ipHostC = Dns.GetHostEntry(strHostName);
            IPAddress ipAddrC = ipHost.AddressList[0];

            // запуск TSL
            //BSendMess = Encoding.UTF8.GetBytes("STARTTLS" + "\r\n");
            //bytesSent = sender.Send(BSendMess);
            //BRecMess = new byte[1024];
            //butesRec = sender.Receive(BRecMess);
            //SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            //Console.WriteLine(SRecMess);

            // начало общения
            BSendMess = Encoding.UTF8.GetBytes("EHLO " + ipAddrC.ToString() + "\r\n");
            //BSendMess = Encoding.UTF8.GetBytes("HELO "+"<cothnpir@mail.ru>"+"\r\n");
            //BSendMess = Encoding.UTF8.GetBytes("HELO " + "smtp.testbox" + "\r\n");
            bytesSent = sender.Send(BSendMess);
            BRecMess = new byte[4096];
            butesRec = sender.Receive(BRecMess);
            SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            Console.WriteLine(SRecMess);

            // Аутентификация
            //BSendMess = Encoding.UTF8.GetBytes("AUTH LOGIN <sevkaa>" + "\r\n");
            //bytesSent = sender.Send(BSendMess);
            //BRecMess = new byte[1024];
            //butesRec = sender.Receive(BRecMess);
            //SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            //Console.WriteLine(SRecMess);

            // Отправитель
            BSendMess = Encoding.UTF8.GetBytes("MAIL FROM:<" + "mymail@list.ru" + ">\r\n");
            bytesSent = sender.Send(BSendMess);
            BRecMess = new byte[1024];
            butesRec = sender.Receive(BRecMess);
            SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            Console.WriteLine(SRecMess);

            //Получатель
            BSendMess = Encoding.UTF8.GetBytes("RCPT TO:" + "<sevkaa0013@gmail.com>" + "\r\n");
            bytesSent = sender.Send(BSendMess);
            BRecMess = new byte[1024];
            butesRec = sender.Receive(BRecMess);
            SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            Console.WriteLine(SRecMess);

            //Сообщаем о начале письма
            BSendMess = Encoding.UTF8.GetBytes("DATA"+"\r\n");
            bytesSent = sender.Send(BSendMess);
            BRecMess = new byte[1024];
            butesRec = sender.Receive(BRecMess);
            SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            Console.WriteLine(SRecMess);

            //Письмо
            BSendMess = Encoding.UTF8.GetBytes("Test Cotn" + "\r\n." + "\r\n");
            bytesSent = sender.Send(BSendMess);
            BRecMess = new byte[1024];
            butesRec = sender.Receive(BRecMess);
            SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            Console.WriteLine(SRecMess);

            //Конец
            BSendMess = Encoding.UTF8.GetBytes("QUIT"+"\r\n");
            bytesSent = sender.Send(BSendMess);
            BRecMess = new byte[1024];
            butesRec = sender.Receive(BRecMess);
            SRecMess = Encoding.UTF8.GetString(BRecMess, 0, butesRec - 1);
            Console.WriteLine(SRecMess);


            //Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();


            return otv;

        }
    }
}

