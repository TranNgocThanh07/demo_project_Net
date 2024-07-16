using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ThuVien
{
    public class XuLy
    {
        private SqlConnection connect;
        public XuLy()
        {

        }
        const string strConnect = "Data Source= A109PC34;Initial Catalog = KhachHang;Integrated Security=True";
        //const string strConnect = "Server=A109PC34;Database=KhachHang;User ID=SA;Password=123;";

        public void Init()
        {
            connect = new SqlConnection(strConnect);
            try
            {
                connect.Open();
                Console.WriteLine("Kết nối thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kết nối: " + ex.Message);
            }
        }

        public void Close()
        {
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
        }

        public DataTable getDatatable(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, connect);
            da.Fill(dt);
            return dt;
        }

        public void open()
        {
            if (connect.State == ConnectionState.Closed)
                connect.Open();
        }
        public void close()
        {
            if (connect.State == ConnectionState.Open)
                connect.Close();
        }
        public object getScalar(string sql)
        {
            try
            {
                open();
                SqlDataAdapter da = new SqlDataAdapter(sql, connect);
                object kq = da.SelectCommand.ExecuteScalar();
                return kq;
            }
            finally
            {
                close();
            }
        }

        public bool Insert(string pQuery)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(pQuery, connect);
                da.SelectCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm dữ liệu: " + ex.Message);
                return false;
            }
        }

        public bool Update(string pQuery)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(pQuery, connect);
                da.SelectCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật dữ liệu: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string pQuery)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(pQuery, connect);
                da.SelectCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa dữ liệu: " + ex.Message);
                return false;
            }
        }
    }
}