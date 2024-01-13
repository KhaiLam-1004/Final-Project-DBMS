using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class TicketBookDAO
    {
        private static TicketBookDAO instance;

        public static TicketBookDAO Instance
        {
            get { if (instance == null) instance = new TicketBookDAO(); return instance; }
            private set { instance = value; }
        }

        private TicketBookDAO() {}

        //Tạo 1 
        //public int CreateTicketBook()
        //{
        //    return DataProvider.Instance.ExecuteNonQuery(" Insert into PhieuSach values ('',''); ");
        //}

        //public int GetNewestTickerBook()
        //{
        //    int TickBid;
        //    return TickBid = Int32.Parse(DataProvider.Instance.ExecuteScalar("select max(MaPhieu) from PhieuSach").ToString());
        //}

        public DataTable GetTicketBook()
        {

            string query = "select * from PhieuSach";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }
        public bool InsertTicketBook(string idStaff, string idReader, int amount)
        {
            //string query = string.Format("INSERT dbo.PhieuSach (MaNV, MaDG, SoSachMuon) VALUES (N'{0}', N'{1}', '{2}')", idStaff, idReader, amount);
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_ThemPhieuSach @MaNV , @MaDG , @SoSachMuon ", new object[] { idStaff, idReader, amount });

            return result > 0;
        }

        //public bool UpdateTicketBook(string idTicketBook, string idStaff, string idReader)
        //{
        //    string query = string.Format("UPDATE dbo.PhieuSach SET MaNV = N'{0}', MaDG = N'{1}' where MaPhieu = '{2}'", idStaff, idReader, idTicketBook);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);

        //    return result > 0;
        //}
    }
}
