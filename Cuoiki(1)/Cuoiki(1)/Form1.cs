using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cuoiki_1_
{
    public partial class Form1 : Form
    {
        private List<Account> accounts = new List<Account>
        {
            new Account { Username = "admin", Password = "admin", Role = "admin" },
            new Account { Username = "nhanvien1", Password = "1234", Role = "nhanvien" }
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Kiểm tra thông tin đăng nhập
            var account = accounts.Find(a => a.Username == username && a.Password == password);
            if (account != null)
            {
                MessageBox.Show($"Đăng nhập thành công với vai trò: {account.Role}");
                // Hiển thị Form2 sau khi đăng nhập thành công
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
            }
        }
        public class Account
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
        }
    }
}
