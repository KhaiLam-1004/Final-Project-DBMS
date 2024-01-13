using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class SearchBookDAO
    {
        private static SearchBookDAO instance;

        public static SearchBookDAO Instance
        {
            get { if (instance == null) instance = new SearchBookDAO(); return instance; }
            private set { instance = value; }
        }

        private SearchBookDAO() { }

        public DataTable GetBookInfo()
        {

            string query = "select * from [Thông Tin Sách]";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }
        
        public DataTable SearchBookByID(int idBook)
        {
            string query = string.Format("select * from TimSachTheoMaSach({0})", idBook);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public DataTable SearchBookByName(string nameBook)
        {

            string query = string.Format("select * from TimSachTheoTenSach(N'{0}')", nameBook);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public DataTable SearchBookByTypeBook(string typeBook)
        {

            string query = string.Format("select * from TimSachTheoTheLoai(N'{0}')", typeBook);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public DataTable SearchBookByWriter(string writer)
        {

            string query = string.Format("select * from TimSachTheoTacGia(N'{0}')", writer);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public DataTable SearchBookByLanguage(string language)
        {

            string query = string.Format("select * from TimSachTheoNgonNgu(N'{0}')", language);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }
    }
}
