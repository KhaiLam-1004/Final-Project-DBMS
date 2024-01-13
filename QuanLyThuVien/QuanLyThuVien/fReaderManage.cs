using QuanLyThuVien.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class fReaderManage : Form
    {
        public fReaderManage()
        {
            InitializeComponent();
            LoadReader();
            //LoadReaderList();
        }

        void LoadReader()
        {
            DataTable listReader = ReaderDAO.Instance.GetReader();
            dataGridView1.DataSource = listReader;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtReaderID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtReaderName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if ((dataGridView1.CurrentRow.Cells[2].Value.ToString() == "Nam"))
            {
                RbtnNam.Checked = true;
                RbtnNu.Checked = false;
            }
            else
            {
                RbtnNam.Checked = false;
                RbtnNu.Checked = true;
            }
            dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;
            txtReaderAddress.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtReaderPhone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtReaderID.Text;
            string name = txtReaderName.Text;
            string sex = "Nam";
            if (RbtnNu.Checked)
            {
                sex = "Nữ";
            }
            DateTime birthdate = dateTimePicker1.Value;
            string address = txtReaderAddress.Text;
            string phone = txtReaderPhone.Text;

            try
            {
                if (ReaderDAO.Instance.InsertReader(id, name, sex, birthdate, address, phone))
                {
                }
            }catch(Exception ex)
            {
                LoadReader();
                MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = txtReaderID.Text;
            string name = txtReaderName.Text;
            string sex = "Nam";
            if (RbtnNu.Checked)
            {
                sex = "Nữ";
            }
            DateTime birthdate = dateTimePicker1.Value;
            string address = txtReaderAddress.Text;
            string phone = txtReaderPhone.Text;
            string idReader = txtReaderID.Text;

            try
            {

                if (ReaderDAO.Instance.UpdateReader(id, name, sex, birthdate, address, phone))
                {
                }
            } catch (Exception ex)
            {
                LoadReader();
                MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtReaderID.Text;

            try
            {
                if (ReaderDAO.Instance.DeleteReader(id))
                {
                }
            }catch(Exception ex)
            {
                LoadReader();
                MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK);
            }
        }
    }
}
