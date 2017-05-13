using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

/*

    Created by : Malinda Rathnayake
    Consultened by : Dilan Walgampaya
    Date : 2017-05-13
    Version : v01.0

    Verify : Run https://technet.microsoft.com/en-us/sysinternals/processexplorer.aspx and search for "MsWinZonesCacheCounterMutexA"

    Ref : https://gist.github.com/N3mes1s/afda0da98f6a0c63ec4a3d296d399636
    */
namespace Anti_WannaCry_Mutex
{
    public partial class AntiWannaCryMutex : ServiceBase
    {
        public static System.Threading.Mutex _mutey = null;
        public AntiWannaCryMutex()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            System.Threading.Mutex _mutey = null;
            try
            {
                _mutey = System.Threading.Mutex.OpenExisting("MsWinZonesCacheCounterMutexA");
                //we got Mutey and can try to obtain a lock by waitone
                _mutey.WaitOne();
            }
            catch
            {
                //the specified mutex doesn't exist, we should create it
                _mutey = new System.Threading.Mutex(false,"MsWinZonesCacheCounterMutexA"); //these names need to match.
            }
            //analytics();

        }

        protected override void OnStop()
        {
            _mutey.ReleaseMutex();
        }

        public void analytics()
        {
            try
            {
                String s = System.Net.Dns.GetHostName();
                String address = "http://apps.malidaprasad.com/report/?app=AntiWannaCryMutex&ver=v1.0&machine=" + s;
                using (WebClient client = new WebClient())
                {
                    client.DownloadString(address);
                }
            }
            catch(Exception e)
            {

            }
            

        }
    }
}
