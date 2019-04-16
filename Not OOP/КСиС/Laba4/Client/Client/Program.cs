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

                while (SendMessageFromSocket(11000));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
               // Console.ReadLine();
            }
        }

        static bool SendMessageFromSocket(int port){
            
            //установка удаленной точки для сокета
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[1];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            //Сoздаем сокет Tcp/Ip
            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //Соеденяемся с удаленной точкой
            sender.Connect(ipEndPoint);
            Console.WriteLine("Сокет соединяется с {0}", ipEndPoint);

            //Имя файла
            //Console.Write("Ввод: ");
            string nameKlient, nameServerKlient;
            Console.WriteLine("Имя пользователя клиента:");
            nameKlient = Console.ReadLine();
            Console.WriteLine("Имя пользователя сервера:");
            nameServerKlient = Console.ReadLine();


            //отправка через сокет
            byte[] mess = Encoding.UTF8.GetBytes((char)0+"");
            int bytesSent = sender.Send(mess);
            mess = Encoding.UTF8.GetBytes(nameKlient + (char)0);
            bytesSent = sender.Send(mess);
            mess = Encoding.UTF8.GetBytes(nameServerKlient + (char)0);
            bytesSent = sender.Send(mess);
            mess = Encoding.UTF8.GetBytes("PC_HP/3200" + (char)0);
            bytesSent = sender.Send(mess);
            bool otv = false;

            string message="1";
            //Проверка на конец сессии
            if (message[0] != 'q')
            {

                otv = true;

                //буфер записи
                byte[] WriteBuf = new byte[4096];


                //получаем
                int butesRec = sender.Receive(WriteBuf);
                if (WriteBuf[0] == 0)
                {

                    butesRec = sender.Receive(WriteBuf);
                    message = Encoding.UTF8.GetString(WriteBuf, 0, butesRec);


                    Console.Write(message);
                    if (message.Length != 0)
                    {
                        //Ввод данных
                        message = Console.ReadLine();
                        mess = Encoding.UTF8.GetBytes(message);
                        bytesSent = sender.Send(mess);


                        while (message[0] != 'q')
                        {
                            Console.Write("You: ");
                            message = Console.ReadLine();
                            mess = Encoding.UTF8.GetBytes("0");
                            mess[0] = (byte)message[0];
                            bytesSent = sender.Send(mess);
                            butesRec = sender.Receive(mess);
                            Console.WriteLine("Eho: " + Encoding.UTF8.GetString(mess, 0, butesRec) + "");
                        }

                    }
                    else
                    {
                        Console.Write("Error password");
                    }

                }
                else
                {
                    Console.Write("Error1");
                
                }

            }
            //Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();


            return otv;

        }
    }
}

