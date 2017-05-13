using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/*

    Created by : Malinda Rathnayake
    Consultened by : Dilan Walgampaya
    Date : 2017-05-13
    Version : v01.0

    Verify : Run https://technet.microsoft.com/en-us/sysinternals/processexplorer.aspx and search for "MsWinZonesCacheCounterMutexA"

    Ref : https://gist.github.com/N3mes1s/afda0da98f6a0c63ec4a3d296d399636
    */

namespace Anti_WannaCry_Mutex_Desktop
{
    public partial class Form1 : Form
    {
        public static Mutex _mutey = null;
        private bool allowVisible;
        public Form1()
        {
            InitializeComponent();
        }


        protected override void SetVisibleCore(bool value)
        {
            if (!allowVisible)
            {
                value = false;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
            notifyIcon1.Visible = true;
            init();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.Visible = false;
            notifyIcon1.Visible = true;
            init();
        }

        public void init()
        {
            try
            {

                bool createdNew;

                _mutey = new Mutex(false, @"Global\MsWinZonesCacheCounterMutexA", out createdNew);
                _mutey.InitializeLifetimeService();


            }
            catch
            {


            }
            analytics();
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

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
            catch (Exception e)
            {

            }


        }

       
    }
}

