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
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fBookManage f = new fBookManage();
            f.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fStaffManage f = new fStaffManage();
            f.ShowDialog();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fReaderManage f = new fReaderManage();
            f.ShowDialog();
        }

        private void thẻĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCardReaderManage f = new fCardReaderManage();
            f.ShowDialog();
        }

        private void theoDõiMượnTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fBorrow_ReturnBook f = new fBorrow_ReturnBook();
            f.ShowDialog();
        }

        private void traCứuSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSearchBook f = new fSearchBook();
            f.ShowDialog();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fStatistical f = new fStatistical();
            f.ShowDialog();
        }
    }
}
