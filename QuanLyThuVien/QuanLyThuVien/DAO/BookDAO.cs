using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuanLyThuVien.DAO
{
    public class BookDAO
    {
        private static BookDAO instance;

        public static BookDAO Instance
        {
            get { if (instance == null) instance = new BookDAO(); return instance; }
            private set { instance = value; }
        }

        private BookDAO() { }

        public DataTable GetBook()
        {

            string query = "select * from Sach";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public bool InsertBook(int idBook, string nameBook, string idWriter, int idTypeBook, int idTypeLanguage, string idNXB, string idPos, int idStatus, int amount, int price)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_ThemSach @MaSach , @TenSach , @MaTG , @MaTL , @MaNN , @MaNXB , @MaVT , @MaTT , @SoLuong , @GiaTien ", 
                new object[] { idBook, nameBook, idWriter, idTypeBook, idTypeLanguage, idNXB, idPos, idStatus, amount, price});

            return result > 0;
        }

        public bool UpdateBook(int idBook, string nameBook, string idWriter, int idTypeBook, int idTypeLanguage, string idNXB, string idPos, int idStatus, int amount, int price)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_SuaSach @MaSach , @TenSach , @MaTG , @MaTL , @MaNN , @MaNXB , @MaVT , @MaTT , @SoLuong , @GiaTien ", 
                new object[] { idBook, nameBook, idWriter, idTypeBook, idTypeLanguage, idNXB, idPos, idStatus, amount, price });

            return result > 0;
        }

        public bool DeleteBook(int id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_XoaSach @MaSach ", new object[] { id });

            return result > 0;
        }
    }
}
