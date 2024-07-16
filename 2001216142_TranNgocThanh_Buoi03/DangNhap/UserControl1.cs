using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ThuVien;

namespace DangNhap
{
    public partial class UserControl1 : UserControl
    {
        XuLy xl = new XuLy();

        public UserControl1()
        {
            InitializeComponent();
            xl.Init(); 
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = textBoxTDN.Text;
            string passWord = textBoxMK.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sử dụng phương thức getScalar của XuLy để lấy mật khẩu
            string getPasswordQuery = String.Format( "SELECT PassWord FROM Customer WHERE UserName = '{0}'",userName);
            object result = xl.getScalar(getPasswordQuery);
          
            if (result == null)
            {
                MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string storedPassword = result.ToString();
           
            // So sánh mật khẩu
              if (storedPassword.Trim() != passWord)
              {
                  MessageBox.Show("Mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
              }

            // Đăng nhập thành công
            MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}