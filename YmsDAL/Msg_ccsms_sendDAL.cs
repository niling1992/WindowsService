using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YmsDAL.Entity;
using System.Configuration;
namespace YmsDAL
{
    public class Msg_ccsms_sendDAL
    {
        private static string connectString =
            ConfigurationManager.AppSettings["ConnectionString"];
        private SqlHelper he = new SqlHelper(connectString);
        private string[] status = { "MSG02"};
        /// <summary>
        /// 获取以发送短信到区政府平台间隔大于一小时的数据
        /// </summary>
        /// <returns></returns>
        public List<msg_ccsms_send> GetSqlList()
        {
            var sqlstr =
                "select *from msg_ccsms_send where currentStatus in ({0}) and  TIMESTAMPDIFF(HOUR,`send_time`,DATE_ADD(Now(),INTERVAL +1 hour))>0";
            List<msg_ccsms_send> sqldepartmentusers =
                he.ExecuteList<msg_ccsms_send>(string.Format(sqlstr, string.Join(",", status)));
            return (sqldepartmentusers);
        }
    }
}
