using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YmsDAL.Entity
{
    public class msg_history
    {
        public int id { get; set; }

        public int creator { get; set; }

        public string phone { get; set; }

        public int message { get; set; }

        public DateTime save_time { get; set; }

        public int send_id { get; set; }
        public string flowstatus { get; set; }
    }
}
