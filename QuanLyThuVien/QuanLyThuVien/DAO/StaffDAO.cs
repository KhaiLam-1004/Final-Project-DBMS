using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuanLyThuVien.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return instance; }
            private set { instance = value; }
        }

        private StaffDAO() { }

        public DataTable GetStaff()
        {

            string query = "select * from NhanVien";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public bool InsertStaff(string id, string name, DateTime birthdate, string sex, string phone)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_ThemNhanVien @MaNV , @TenNV , @NgaySinh , @GioiTinh , @SDT ", new object[] { id, name, birthdate, sex, phone });

            return result > 0;
        }

        public bool UpdateStaff(string id, string name, DateTime birthdate, string sex, string phone)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_SuaNhanVien @MaNV , @TenNV , @NgaySinh , @GioiTinh , @SDT ", new object[] { id, name, birthdate, sex, phone });

            return result > 0;
        }

        public bool DeleteStaff(string id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_XoaNhanVien @MaNV ", new object[] { id });

            return result > 0;
        }
    }
}
