using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace YmsWindowsService
{
    public partial class YmsService : ServiceBase
    {
        public YmsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            //dynamic customer = new ExpandoObject();
            //customer.Name = "Joe";
            //customer.Email = "joe@smith.com";
            //var http = new EasyHttp.Http.HttpClient();
            //http.Post("url", customer, EasyHttp.Http.HttpContentTypes.ApplicationJson);

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\log.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Start.");
            }
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
