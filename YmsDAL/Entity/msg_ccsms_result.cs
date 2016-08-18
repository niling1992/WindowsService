using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YmsDAL.Entity
{
   public  class msg_ccsms_result
    {
        public int AutoSn { get; set; }

        public string MOBILE { get; set; }

        public string RPT_CODE { get; set; }

        public string RPT_DESC { get; set; }

        public DateTime RPT_TIME { get; set; }

        public int send_id { get; set; }
        public string sms_id { get; set; }
    }
}
