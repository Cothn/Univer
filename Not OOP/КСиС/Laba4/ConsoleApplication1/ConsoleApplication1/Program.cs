using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Net;
using System.Net.Sockets;
namespace NetConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ListOfFile = new string[100];
            int KolFile = ReadListFile(ListOfFile);

            //конечная локальная точка
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[1];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 25);

            //Сoздаем сокет Ncp/Ip
            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //Сокет для локальной точки и прослушивание входящих сокетов
            try
            {

                sListener.Bind(ipEndPoint);
                sListener.Listen(7);

                //начинаем слушать
                while (true)
                {

                    //!!!
                    Console.WriteLine("Ожидаем соединения через {0}", ipEndPoint);

                    //Ожидаем соединения
                    Socket handler = sListener.Accept();
                    string data = null;

                    //общаемся с клиентом
                    //Отвечаем
                    string reply = "220 LocalMail SMTP is ready \r\n";
                    byte[] replyBuf = Encoding.UTF8.GetBytes(reply);
                    int bytesSent = handler.Send(replyBuf);

                    //получаем
                    byte[] bytes = new byte[1024];
                    int butesRec = handler.Receive(bytes);
                    data += Encoding.UTF8.GetString(bytes, 0, butesRec);
                    //Отвечаем
                    reply = "250 LocalMail\r\n";
                    replyBuf = Encoding.UTF8.GetBytes(reply);
                    bytesSent = handler.Send(replyBuf);

                    while (data != "QUIT\r\n")
                    {
                        bytesSent = handler.Send(replyBuf);
                        //получаем
                        bytes = new byte[1024];
                        butesRec = handler.Receive(bytes);
                        data += Encoding.UTF8.GetString(bytes, 0, butesRec);
                        //switch (data) { 
                         //   case "":
                        
                        
                        
                        
                        //}

                        //Отвечаем
                        reply = "250 OK\r\n";
                        replyBuf = Encoding.UTF8.GetBytes(reply);
                    }

                        reply = "221 LocalMail is closing chanel\r\n";
                        replyBuf = Encoding.UTF8.GetBytes(reply);
        
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }


            //CreateListFile(ListOfFile, kolStr);
        }


        //static public void CreateListFile(string[] FileList, int kolStr)
        //{

        //    FileStream file1 = new FileStream("ServFile\\test.txt", FileMode.Create); //создаем файловый поток
        //    StreamWriter writer = new StreamWriter(file1); //создаем «поток записиь» и связываем его с файловым потоком

        //    int i=0;
        //    while (i < kolStr)
        //    {
        //        writer.Write(FileList[i]); //записываем в файл
        //    }

        //    writer.Close(); //закрываем поток. Не закрыв поток, в файл ничего не запишется 

        //}

        static public int ReadListFile(string[] FileList)
        {

            FileStream file1 = new FileStream("ServFile\\FileList.txt", FileMode.Open); //создаем файловый поток
            StreamReader reader = new StreamReader(file1); //создаем «экземпляр чтения» и связываем его с файловым потоком

            int i = 0;
            while (!reader.EndOfStream && i < 100)
            {
                FileList[i] = reader.ReadLine(); //read
                i++;
            }

            reader.Close(); //закрываем поток.
            return i;

        }

        static public bool CheckListFile(string[] FileList, int kolFile, string sign)
        {

            int i = 0;
            while (i < kolFile)
            {
                if (FileList[i] == sign)
                {
                    return true;
                }
                i++;
            }

            return false;

        }
    }
}