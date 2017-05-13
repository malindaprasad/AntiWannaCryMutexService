using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Anti_WannaCry_Mutex
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new AntiWannaCryMutex()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
