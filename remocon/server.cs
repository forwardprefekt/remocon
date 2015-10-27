using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace remocon
{
    class server
    {

        public bool createListener()
        {

            int lPort = 31337;

            TcpListener tListener = null;

            IPAddress ipAddr = IPAddress.Any;

            try
            {
                tListener = new TcpListener(ipAddr, lPort);
                tListener.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to create listener... %s", e.Message);
                return false;
            }

            while (true)
            {

                Thread.Sleep(10);
                TcpClient tcpClient = tListener.AcceptTcpClient();
                byte[] buf = new byte[256];
                NetworkStream stream = tcpClient.GetStream();
                stream.Read(buf, 0, 1); //TODO: change to read in command class type (read length for command/file xfer)
                command curCommand = new command();
                curCommand.cmd = (command.command_type)buf[0];
                stream.Read(buf, 0, 1); //todo, this will only work for my test 3 char DIR command... need to change to support file xfer
                curCommand.length = (int)buf[0];
                byte[] payloadbuf = new byte[curCommand.length];
                stream.Read(payloadbuf, 0, payloadbuf.Length);
                curCommand.payload = payloadbuf;
                curCommand.doit();
            }
            
            return true;
        }


    }
}
