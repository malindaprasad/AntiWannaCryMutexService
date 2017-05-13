using System;

using System.Diagnostics;

using System.Net;
using System.Security.AccessControl;
using System.Security.Principal;
using System.ServiceProcess;

using System.Threading;


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
        public static Mutex _mutey = null;
        public AntiWannaCryMutex()
        {
            InitializeComponent();

        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
                      
            try
            {
              
                bool createdNew;

                _mutey = new Mutex(false, @"Global\MsWinZonesCacheCounterMutexA", out createdNew);
                _mutey.InitializeLifetimeService();
                 PrintLog("Mutex Created", EventLogEntryType.Information);
               
            }
            catch
            {
                PrintLog("Mutex Doesnt Exist", EventLogEntryType.Information);
               
            }
            analytics();

        }


        void InitLog()
        {
            try {
                this.ServiceName = "AntiWannaCryMutexService";
                this.EventLog.Source = this.ServiceName;
                this.EventLog.Log = "AntiWannaCryMutexService";

                if (!System.Diagnostics.EventLog.SourceExists(this.ServiceName))
                {
                    System.Diagnostics.EventLog.CreateEventSource(
                       this.ServiceName, "AntiWannaCryMutexService");
                }
            }catch(Exception e)
            {

            }
        }


        void PrintLog(String msg, EventLogEntryType type)
        {
            try
            {
                this.EventLog.WriteEntry("Mutex Creation failed", type);

            }
            catch(Exception e)
            {

            }
        }

        protected override void OnStop()
        {
            try
            {

                _mutey.ReleaseMutex();
                GC.KeepAlive(_mutey);
                this.EventLog.WriteEntry("Mutex Released", EventLogEntryType.Information);

            }
            catch (Exception e)
            {
                this.EventLog.WriteEntry("Mutex Release error", EventLogEntryType.Information);
            }

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
