using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PLAutoMapperLib.PMapExport
{
    // 미완료 작성중...
    public class PMapExportClient
    {
        private Thread thread;
        private PMapExportPacket lastPacket;


        public event PMapExportEventHandler PMapExportEvent;

        private void OnPMapEvent(PMapExportPacket packet)
        {
            PMapExportEventHandler pMapExportEvent = this.PMapExportEvent;
            if(pMapExportEvent == null) { return; }
            pMapExportEvent(packet);
        }

        public int Port { get; set; }
        public TcpClient client { get; set; }
        private NetworkStream stream { get; set; }
        private byte[] Query;
        public bool IsConnected { get; set; }
        private string IpAdress { get; set; }
        private bool IsReleased { get; set; }

        public PMapExportClient()
        {
            client = new TcpClient();
            Port = 10001;
            IsConnected = client.Connected;
            IsReleased = false;
            Query = new byte[8];
        }
        public void Connect()
        {
            try
            {
                client.Connect(this.IpAdress, this.Port);
                client.ReceiveBufferSize = 104857600;
                client.SendBufferSize = 102400;
                client.SendTimeout = 200;
                client.ReceiveTimeout = 200;
                stream = client.GetStream();
                thread = new Thread(new ThreadStart(this.Run));
                thread.Name = "Clinet Communication Thread";
                thread.Start();
            }
            catch (Exception ex)
            {
                
            }
        }
        public void Connect(string addr, int port)
        {
            try
            {
                Port = port;
                IpAdress = addr;
                client = new TcpClient();
                client.ReceiveBufferSize = 102400;
                client.SendBufferSize = 1024000;
                client.SendTimeout = 200;
                client.ReceiveTimeout = 200;
                stream = client.GetStream();
                IsConnected = true;
            }
            catch (Exception ex)
            {
                IsConnected = false;
            }
            this.ThreadRun();
        }
        public void Release()
        {
            try
            {
                IsReleased = true;
                IsConnected = false;
                if (stream != null)
                    stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                //Log
            }
        }
        private void ThreadRun()
        {
            try
            {
                IsConnected = true;
                thread = new Thread(new ThreadStart(Run));
                thread.Name = "연결되었습니다.";
                thread.Start();
            }
            catch (Exception ex)
            {
                IsConnected=false;
            }
        }

        private void Run()
        {
            try
            {
                IsConnected = true;
                DateTime dateTime = DateTime.Now;
                while (IsConnected)
                {
                    try
                    {
                        if(client != null)
                        {
                            if (!client.Connected)
                            {
                                try
                                {
                                    client.Close();
                                    Reconnect();
                                }
                                catch (Exception ex)
                                {
                                    Thread.Sleep(100);
                                    continue;
                                }
                            }
                        }
                        if(client == null)
                        {
                            client = new TcpClient();
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            if (client.Connected)
                            {
                                try
                                {
                                    List<byte> source = new List<byte>();
                                    if (stream.DataAvailable)
                                    {
                                        dateTime = DateTime.Now.AddSeconds(10.0);
                                        byte num1 = byte.MaxValue;
                                        byte num2 = byte.MaxValue;
                                        while (num1 != (byte)13 || num2 != 10)
                                        {
                                            num1 = num2;
                                            num2 = (byte)stream.ReadByte();
                                            source.Add(num2);
                                            if (source.Count > 10000)
                                            {
                                                stream.Close();
                                            }
                                        }
                                        ParseStream(Encoding.UTF8.GetString(source.Take<byte>(source.Count - 2).ToArray<byte>()));
                                        if (stream.CanWrite)
                                        {
                                            stream.Write(source.ToArray(), 0, source.Count);
                                        }
                                        Thread.Sleep(1);
                                    }
                                    Thread.Sleep(1);
                                }
                                catch (IOException ex)
                                {
                                    //
                                }
                                catch (Exception ex)
                                {
                                    this.stream.Close();
                                }
                            }
                            Thread.Sleep(100);
                        }
                    }
                    catch (Exception ex)
                    {
                        //
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                IsConnected = false;
            }
        }

        private void ParseStream(string sDummy)
        {
            try
            {
                lastPacket = new PMapExportPacket();
                lastPacket.Parse(sDummy);
                switch (lastPacket.Command)
                {
                    case ePMapExportCommands.None:
                        //Log
                        break;
                    case ePMapExportCommands.Error:
                        //Log
                        break;
                    default:
                        OnPMapEvent(lastPacket);
                        break;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
        }
        public byte[] GetBytes(string sDummy) => Encoding.ASCII.GetBytes(sDummy);
        private void Reconnect()
        {
            throw new NotImplementedException();
        }
    }
}
