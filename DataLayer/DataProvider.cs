using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataProvider
    {
        private SqlConnection cn;
        public SqlConnection Connection
        {
            get { return cn; }
        }

        //Khởi tạo
        public DataProvider()
        {
            string cnStr = "Data Source=.;Initial Catalog=QLCuaHang;Integrated Security=True";
            cn = new SqlConnection(cnStr);
        }

        public void Connect()
        {
            try
            {
                if (cn != null && cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public void DisConnect()
        {
            try
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public object MyExecuteScalar(string sql, CommandType type, SqlParameter[] parameters = null)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters); // Thêm danh sách tham số vào câu lệnh SQL
            }

            try
            {
                Connect();
                return cmd.ExecuteScalar(); // Trả về kết quả đầu tiên của truy vấn
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }


        public int MyExecuteNonQuery(string sql, CommandType type, SqlParameter[] parameters = null)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            try
            {
                Connect();
                return cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public DataTable MyExecuteReader(string sql, CommandType type, SqlParameter[] parameters = null)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            try
            {
                Connect();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
