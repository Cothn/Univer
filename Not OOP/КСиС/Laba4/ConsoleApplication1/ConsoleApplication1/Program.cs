using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Net;
using System.Net.Sockets;

namespace Server1
{

    class Program
    {
        static void Main(string[] args)
        {


            string[] ListOfUser = new string[100];
            int KolUser = ReadListFile(ListOfUser);

            //конечная локальная точка
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[1];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

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
                    string data, nameKlient, nameServerKlient= "", TermTypeSpeed;

                    //общаемся с клиентом
                    bool Korrekt = true;
                    byte[] bytes = new byte[1024];
                    int butesRec = handler.Receive(bytes);
                    if (bytes[0] == 0)
                    {
                        butesRec = handler.Receive(bytes);
                        nameKlient = Encoding.UTF8.GetString(bytes, 0, butesRec - 1);
                        if (bytes[butesRec - 1] == 0)
                        {
                            butesRec = handler.Receive(bytes);
                            nameServerKlient = Encoding.UTF8.GetString(bytes, 0, butesRec - 1);
                            if (bytes[butesRec - 1] == 0)
                            {
                                butesRec = handler.Receive(bytes);
                                TermTypeSpeed = Encoding.UTF8.GetString(bytes, 0, butesRec - 1);
                                if (bytes[butesRec - 1] != 0)
                                {
                                    Korrekt = false;
                                }
                            }
                            else
                            {
                                Korrekt = false;
                            }
                        }
                        else
                        {
                            Korrekt = false;
                        }
                    }
                    else
                    {
                        Korrekt = false;
                    }

                    //Подтверждаем
                    byte Buf;
                    if (Korrekt)
                    {
                        Buf = 0;
                    }
                    else
                    {
                        Buf = 1;
                    }
                    byte[] Bufe = Encoding.UTF8.GetBytes("0");
                    Bufe[0] = Buf;
                    int bytesSent = handler.Send(Bufe);

                    /*bool Korrekt = true;
                    int j = 0, k = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (bytes[j] == 0)
                        {
                            j++;
                            k = 1;
                            while ((bytes[j] != 0) && (j < butesRec))
                            {
                                j++;
                            }
                            nameKlient = Encoding.UTF8.GetString(bytes, k, j);
                        }

                    } */

                    if (Korrekt)
                    {
                        //Ввод данных
                        string message = "Password: ";
                        byte[] mess = Encoding.UTF8.GetBytes(message);
                        bytesSent = handler.Send(mess);

                        //пароль
                        butesRec = handler.Receive(bytes);
                        data = Encoding.UTF8.GetString(bytes, 0, butesRec);

                        //Пробегаем по массиву имен
                        bool Check = CheckListFile(ListOfUser, KolUser, nameServerKlient + "/" + data);

                        //Отвечаем
                        //string reply = "Ответ: " +Check+ "\n\n";
                        //byte[] replyBuf = Encoding.UTF8.GetBytes(reply);
                        //bytesSent = handler.Send(replyBuf);
                        mess = Encoding.UTF8.GetBytes("1");
                        mess[0] = 1;
                        while (Check && ((char)mess[0] != 'q'))
                        {
                            butesRec = handler.Receive(mess);
                            bytesSent = handler.Send(mess);

                        }
                    }
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
            while ( i < kolFile)
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
