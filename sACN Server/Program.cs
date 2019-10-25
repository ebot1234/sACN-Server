using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using sACN_Server;

namespace sACN_Server
{
    class Program
    {
        UdpClient listener = new UdpClient(5555);
        IPEndPoint UdpIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);

         static public void Main(string[] args)
        {
            Program program = new Program();
            
            
            while (true)
            {
                program.Send(program.setChannel(255));
            }
            
        }

        public  void Send(byte[] data)
        {
            SACNSender sender = new SACNSender(Guid.NewGuid(), "sACN Server");
            IPAddress ip = IPAddress.Parse("10.0.0.1");

           
                sender.Send(1, data, ip);
                Console.WriteLine("Sent Data");
                Thread.Sleep(100);
            
        }

        public  byte[] setChannel(byte value)
        {
            byte[] data = new byte[] { value };

            return data;
        }

        public byte[] Receive()
        {
            byte[] data;

            while (true)
            {
                   data = listener.Receive(ref UdpIPEndPoint);
                    return data;
            }
        }
    }
}
