using QuanLyThuVien.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        
        private void buttonLogin_Click(object sender, EventArgs e) // Xử lý bấm vào nút đăng nhập sẽ hiện ra form Phần mềm quản lý
        {
            string username = textBoxUserName.Text;
            string password = textBoxPassword.Text;
            if (Login(username, password) == true)
            {
                fTableManager ftableManager = new fTableManager();
                this.Hide();
                ftableManager.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn đã điền sai tên tài khoản hoặc mật khẩu!");
            }
        }

        bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      
        private void fLogin_FormClosing(object sender, FormClosingEventArgs e) // Xử lý thoát chương trình
        {
            if(MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK )
            {
                e.Cancel = true;
            }    
        }


    }
}
