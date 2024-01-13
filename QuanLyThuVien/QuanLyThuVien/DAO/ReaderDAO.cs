using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class ReaderDAO
    {
        private static ReaderDAO instance;

        public static ReaderDAO Instance
        {
            get { if (instance == null) instance = new ReaderDAO(); return instance; }
            private set { instance = value; }
        }

        private ReaderDAO() { }

        public DataTable GetReader()
        {

            string query = "select * from DocGia";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public bool InsertReader(string id, string name, string sex, DateTime birthdate, string address, string phone)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_ThemDocGia @MaDG , @TenDG , @GioiTinh , @NgaySinh , @DiaChi , @SDT ", new object[] { id, name, sex, birthdate, address, phone });

            return result > 0;
        }

        public bool UpdateReader(string id, string name, string sex, DateTime birthdate, string address, string phone)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_SuaDocgia @MaDG , @TenDG , @GioiTinh , @NgaySinh , @DiaChi , @SDT ", new object [] { id, name, sex, birthdate, address, phone } );
            return result > 0;
        }

        public bool DeleteReader(string id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_XoaDocGia @MaDG ", new object[] { id });

            return result > 0;
        }
    }
}
