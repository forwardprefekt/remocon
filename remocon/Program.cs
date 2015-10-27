using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remocon
{
    class Program
    {
        static void Main(string[] args)
        {

            server thissrv = new server();
            thissrv.createListener();


        }
    }
}
