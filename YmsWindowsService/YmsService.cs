using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using YmsDAL;
using System.IO;
namespace YmsWindowsService
{
    public partial class YmsService : ServiceBase
    {
        public YmsService()
        {
            InitializeComponent();
        }

        private Msg_ccsms_sendDAL msg_ccsms_sendDAL = new Msg_ccsms_sendDAL();

        protected override void OnStart(string[] args)
        {

            //定时器
            Timer MT = new Timer();

            MT.Enabled = true;
            MT.Interval = (3600000);//每小时运行一次

            MT.Elapsed += new System.Timers.ElapsedEventHandler((object sender, ElapsedEventArgs e) =>
            {
               
                using (StreamWriter sw = new StreamWriter("C:\\log.txt", true))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "获取以发送短信到区政府平台间隔大于一小时的数据!");
                }
                /*获取以发送短信到区政府平台间隔大于一小时的数据*/
                var list = msg_ccsms_sendDAL.GetSqlList();
                var http = new EasyHttp.Http.HttpClient();
                http.Post("url", list, EasyHttp.Http.HttpContentTypes.ApplicationJson);
            });//每小时执行一次
        }


        protected override void OnStop()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\log.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Stop.");
            }
        }
    }
}
