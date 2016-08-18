using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YmsDAL
{
    public class SqlHelper
    {
        #region Fields

        private readonly string _connectString;

        #endregion

        #region Constructors

        public SqlHelper()
        {
        }

        public SqlHelper(string connectString)
        {
            _connectString = connectString;
        }

        #endregion

        #region Property ConnectionString

        public string ConnectionString
        {
            get { return _connectString; }
        }

        #endregion

        #region Method ExecuteNonQuery

        public int ExecuteNonQuery(string commandText)
        {
            return this.ExecuteNonQuery(commandText, CommandType.Text, null);
        }

        public int ExecuteNonQuery(string commandText, MySqlParameter[] paras)
        {
            return this.ExecuteNonQuery(commandText, CommandType.Text, paras);
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType, MySqlParameter[] paras)
        {
            int result = 0;
            using (MySqlConnection connection = new MySqlConnection(this._connectString))
            {
                connection.Open();
                result = this.ExecuteNonQuery(commandText, commandType, paras, connection);
                connection.Close();
            }

            return result;
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlConnection connection)
        {
            MySqlCommand command = this.CreateCommandHelper(commandText, commandType, paras, connection);
            int result = command.ExecuteNonQuery();
            command.Dispose();

            return result;
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlTransaction trans)
        {
            MySqlCommand command = this.CreateCommandHelper(commandText, commandType, paras, trans);
            int result = command.ExecuteNonQuery();
            command.Dispose();

            return result;
        }

        #endregion

        #region Method ExecuteScalar

        public int ExecuteScalar(string commandText)
        {
            return this.ExecuteScalar(commandText, CommandType.Text, null);
        }

        public int ExecuteScalar(string commandText, MySqlParameter[] paras)
        {
            return this.ExecuteScalar(commandText, CommandType.Text, paras);
        }

        public int ExecuteScalar(string commandText, CommandType commandType, MySqlParameter[] paras)
        {
            int result = 0;
            using (MySqlConnection connection = new MySqlConnection(this._connectString))
            {
                connection.Open();
                result = ExecuteScalar(commandText, commandType, paras, connection);
                connection.Close();
            }

            return result;
        }

        public int ExecuteScalar(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlConnection connection)
        {
            MySqlCommand command = this.CreateCommandHelper(commandText, commandType, paras, connection);
            object result = command.ExecuteScalar();
            command.Dispose();

            if (result == null || result + "" == "")
                return 0;

            return Convert.ToInt32(result);
        }

        public int ExecuteScalar(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlTransaction trans)
        {
            MySqlCommand command = this.CreateCommandHelper(commandText, commandType, paras, trans);
            object result = command.ExecuteScalar();
            command.Dispose();

            if (result == null)
                return 0;

            return (int)result;
        }

        #endregion

        #region Method ExecuteObjectScalar

        public object ExecuteObjectScalar(string commandText)
        {
            return this.ExecuteObjectScalar(commandText, CommandType.Text, null);
        }

        public object ExecuteObjectScalar(string commandText, MySqlParameter[] paras)
        {
            return this.ExecuteObjectScalar(commandText, CommandType.Text, paras);
        }

        public object ExecuteObjectScalar(string commandText, CommandType commandType, MySqlParameter[] paras)
        {
            object result;
            using (MySqlConnection connection = new MySqlConnection(this._connectString))
            {
                connection.Open();
                result = ExecuteObjectScalar(commandText, commandType, paras, connection);
                connection.Close();
            }

            return result;
        }

        public object ExecuteObjectScalar(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlConnection connection)
        {
            MySqlCommand command = this.CreateCommandHelper(commandText, commandType, paras, connection);
            object result = command.ExecuteScalar();
            command.Dispose();

            if (result == null || result + "" == "")
                return null;

            return result;
        }

        public object ExecuteObjectScalar(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlTransaction trans)
        {
            MySqlCommand command = this.CreateCommandHelper(commandText, commandType, paras, trans);
            object result = command.ExecuteScalar();
            command.Dispose();

            if (result == null)
                return null;

            return result;
        }

        #endregion

        #region Method ExecuteStringScalar

        public string ExecuteStringScalar(string commandText)
        {
            return this.ExecuteStringScalar(commandText, CommandType.Text, null);
        }

        public string ExecuteStringScalar(string commandText, MySqlParameter[] paras)
        {
            return this.ExecuteStringScalar(commandText, CommandType.Text, paras);
        }

        public string ExecuteStringScalar(string commandText, CommandType commandType, MySqlParameter[] paras)
        {
            string result = "";
            using (MySqlConnection connection = new MySqlConnection(this._connectString))
            {
                connection.Open();
                result = ExecuteStringScalar(commandText, commandType, paras, connection);
                connection.Close();
            }

            return result;
        }

        public string ExecuteStringScalar(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlConnection connection)
        {
            MySqlCommand command = this.CreateCommandHelper(commandText, commandType, paras, connection);
            object result = command.ExecuteScalar();
            command.Dispose();

            if (result == null)
                return "";

            return result.ToString();
        }

        public string ExecuteStringScalar(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlTransaction trans)
        {
            MySqlCommand command = this.CreateCommandHelper(commandText, commandType, paras, trans);
            object result = command.ExecuteScalar();
            command.Dispose();

            if (result == null)
                return "";

            return result.ToString();
        }

        #endregion

        #region Method ExecuteDataTable

        public DataTable ExecuteDataTable(string commandText)
        {
            return this.ExecuteDataTable(commandText, CommandType.Text, null);
        }

        public DataTable ExecuteDataTable(string commandText, MySqlParameter[] paras)
        {
            return this.ExecuteDataTable(commandText, CommandType.Text, paras);
        }

        public DataTable ExecuteDataTable(string commandText, CommandType commandType, MySqlParameter[] paras)
        {
            DataTable dt = null;
            using (MySqlConnection connection = new MySqlConnection(this._connectString))
            {
                connection.Open();
                dt = this.ExecuteDataTable(commandText, commandType, paras, connection);
                connection.Close();
            }

            return dt;
        }

        public DataTable ExecuteDataTable(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlConnection connection)
        {
            DataTable dt = new DataTable();
            MySqlCommand command = this.CreateCommandHelper(commandText, commandType, paras, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dt);
            command.Dispose();
            adapter.Dispose();

            return dt;
        }

        public DataTable ExecuteDataTable(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlTransaction trans)
        {
            DataTable dt = new DataTable();
            MySqlCommand command = this.CreateCommandHelper(commandText, commandType, paras, trans);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dt);
            command.Dispose();
            adapter.Dispose();

            return dt;
        }

        #endregion

        #region Method ExecuteDataSet

        public DataSet ExecuteDataSet(string commandText)
        {
            return this.ExecuteDataSet(commandText, CommandType.Text, null);
        }

        public DataSet ExecuteDataSet(string commandText, MySqlParameter[] paras)
        {
            return this.ExecuteDataSet(commandText, CommandType.Text, paras);
        }

        public DataSet ExecuteDataSet(string commandText, CommandType commandType, MySqlParameter[] paras)
        {
            DataSet ds = null;
            using (MySqlConnection connection = new MySqlConnection(_connectString))
            {
                connection.Open();
                ds = this.ExecuteDataSet(commandText, commandType, paras, connection);
                connection.Close();
            }

            return ds;
        }

        public DataSet ExecuteDataSet(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlConnection connection)
        {
            DataSet ds = new DataSet();
            MySqlCommand command = this.CreateCommandHelper(commandText, commandType, paras, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(ds);
            command.Dispose();
            adapter.Dispose();

            return ds;
        }

        public DataSet ExecuteDataSet(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlTransaction trans)
        {
            DataSet ds = new DataSet();
            MySqlCommand command = this.CreateCommandHelper(commandText, commandType, paras, trans);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(ds);
            command.Dispose();
            adapter.Dispose();

            return ds;
        }

        #endregion

        #region Method ExecuteEntity
        private static T ExecuteDataReader<T>(MySqlDataReader dr)
        {
            T obj = default(T);
            Type type = typeof(T);
            PropertyInfo[] propertyInfos = type.GetProperties();
            int columnCount = dr.FieldCount;
            obj = Activator.CreateInstance<T>();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                string propertyName = propertyInfo.Name;
                for (int i = 0; i < columnCount; i++)
                {
                    string columnName = dr.GetName(i);
                    if (string.Compare(propertyName, columnName, true) == 0)
                    {
                        object value = dr.GetValue(i);
                        if (value != null && value != DBNull.Value)
                        {
                            //propertyInfo.SetValue(obj, value, null);
                            propertyInfo.SetValue(obj, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                        }
                        break;
                    }
                }
            }
            return obj;
        }

        public T ExecuteEntity<T>(string commandText)
        {
            return this.ExecuteEntity<T>(commandText, CommandType.Text, null);
        }

        public T ExecuteEntity<T>(string commandText, MySqlParameter[] paras)
        {
            return this.ExecuteEntity<T>(commandText, CommandType.Text, paras);
        }

        public T ExecuteEntity<T>(string commandText, CommandType commandType, MySqlParameter[] paras)
        {
            T obj = default(T);
            using (MySqlConnection connection = new MySqlConnection(_connectString))
            {
                connection.Open();
                obj = this.ExecuteEntity<T>(commandText, commandType, paras, connection);
                connection.Close();
            }

            return obj;
        }

        public T ExecuteEntity<T>(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlConnection connection)
        {
            T obj = default(T);
            using (MySqlCommand cmd = new MySqlCommand(commandText, connection))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(paras);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        obj = ExecuteDataReader<T>(dr);
                        break;
                    }
                }
            }
            return obj;
        }
        #endregion

        #region Method ExecuteList
        public List<T> ExecuteList<T>(string sql)
        {
            return this.ExecuteList<T>(sql, CommandType.Text, null);
        }

        public List<T> ExecuteList<T>(string commandText, MySqlParameter[] paras)
        {
            return this.ExecuteList<T>(commandText, CommandType.Text, paras);
        }

        public List<T> ExecuteList<T>(string commandText, CommandType commandType, MySqlParameter[] paras)
        {
            List<T> list = new List<T>();
            using (MySqlConnection connection = new MySqlConnection(_connectString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                list = this.ExecuteList<T>(commandText, commandType, paras, connection);
                connection.Close();
            }

            return list;

        }

        public List<T> ExecuteList<T>(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlConnection connection)
        {
            List<T> list = new List<T>();

            MySqlCommand command = this.CreateCommandHelper(commandText, commandType, paras, connection);
            using (MySqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                {
                    T obj = ExecuteDataReader<T>(dr);
                    list.Add(obj);
                }
            }
            command.Dispose();

            return list;
        }

        public List<T> ExecuteList<T>(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlTransaction trans)
        {
            List<T> list = new List<T>();

            MySqlCommand command = this.CreateCommandHelper(commandText, commandType, paras, trans);
            using (MySqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (dr.Read())
                {
                    T obj = ExecuteDataReader<T>(dr);
                    list.Add(obj);
                }
            }
            command.Dispose();

            return list;
        }
        #endregion

        #region Method InsertBatch

        public int InsertBatch(string commandText, DataTable data, MySqlParameter[] paras, MySqlTransaction trans)
        {
            MySqlCommand command = this.CreateCommandHelper(commandText, CommandType.Text, paras, trans);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.InsertCommand = command;
            int result = adapter.Update(data);

            adapter.Dispose();
            command.Dispose();

            return result;
        }



        #endregion

        #region Private Method CreateCommandHelper

        private MySqlCommand CreateCommandHelper(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;
            command.Connection = connection;

            if (paras != null && paras.Length > 0)
            {
                foreach (MySqlParameter p in paras)
                {
                    /*Update 修改无法使用 ParameterDirection.Output 来输出值的Bug*/
                    //MySqlParameter paraNew = new MySqlParameter();
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        /*
                        paraNew.ParameterName = p.ParameterName;
                        paraNew.MySqlDbType = p.MySqlDbType;
                        paraNew.DbType = p.DbType;
                        paraNew.SourceColumn = p.SourceColumn;
                        paraNew.Value = p.Value;
                         */

                        command.Parameters.Add(p);
                    }

                }
            }

            return command;
        }

        private MySqlCommand CreateCommandHelper(string commandText, CommandType commandType, MySqlParameter[] paras, MySqlTransaction trans)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;
            command.Connection = trans.Connection;
            command.Transaction = trans;

            if (paras != null && paras.Length > 0)
            {
                foreach (MySqlParameter p in paras)
                {
                    MySqlParameter paraNew = new MySqlParameter();
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }

                        paraNew.ParameterName = p.ParameterName;
                        paraNew.MySqlDbType = p.MySqlDbType;
                        paraNew.DbType = p.DbType;
                        paraNew.SourceColumn = p.SourceColumn;
                        paraNew.Value = p.Value;
                    }
                    command.Parameters.Add(paraNew);
                }
            }

            return command;
        }

        #endregion
    }
}
