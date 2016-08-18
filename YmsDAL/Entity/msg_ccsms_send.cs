using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YmsDAL.Entity
{
    public  class msg_ccsms_send
    {

        public int id { get; set; }

        public string phone_no { get; set; }

        public string content { get; set; }

        public int sender { get; set; }

        public DateTime send_time { get; set; }

        public int submit_time { get; set; }
        public string currentStatus { get; set; }
        public string smsId { get; set; }
    }
}
