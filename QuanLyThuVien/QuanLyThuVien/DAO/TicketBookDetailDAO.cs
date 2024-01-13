using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    internal class TicketBookDetailDAO
    {
        private static TicketBookDetailDAO instance;

        public static TicketBookDetailDAO Instance
        {
            get { if (instance == null) instance = new TicketBookDetailDAO(); return instance; }
            private set { instance = value; }
        }

        private TicketBookDetailDAO() { }

        // Dùng để lấy dữ liệu từ bảng PhieuSachCT ở Database lên Winform dùng cho tab(Chi tiết mượn và chi tiết trả)
        public DataTable GetTicketBookDetail()
        {

            string query = "select * from PhieuSachCT";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        // Dùng để lấy ra mã sách và tên sách load vào comboBox ở tab (Chi tiết mượn)
        public DataTable GetBookID()
        {

            string query = "select MaSach, TenSach from Sach";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        // Dùng để cập nhật sách mượn của độc giả vào PhieuSachCT(dùng cho tab Chi tiết Mượn)
        public bool UpdateTicketBookDetail(int idBook, int idTicketBook, int STT)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_UpdateMaSach @MaPhieu , @STT , @MaSach ", new object[] { idTicketBook, STT, idBook });

            return result > 0;
        }

        // Dùng để lấy dữ liệu từ PhieuSachCT ở Database lên Winform dùng cho tab(In phiếu mượn)
        public DataTable SearchTicketBook_Muon_ByIDTicketBook(int idTicketBook)
        {

            string query = string.Format("select * from InPhieuMuon({0})", idTicketBook);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        // Dùng để chạy proc trả sách ở dưới Database với mục đích là để trả sách (dùng ở tab Chi tiết Trả)
        public bool ReturnTicketBookDetail(int idTicketBook, int STT)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec Proc_TraSach @MaPhieu , @STT ", new object[] { idTicketBook, STT });

            return result > 0;
        }

        // Dùng để kiểm tra tiền phạt mỗi khi độc giả làm hư hại sách (dùng ở tab Chi tiết trả)
        public bool CheckFineMoney(int idTicketBook, int STT, int idBook, int idStatus)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Exec CapNhatTienPhat @MaPhieu , @STT , @MaSach , @MaTT ", new object[] { idTicketBook, STT, idBook, idStatus});

            return result > 0;
        }

        // Dùng để lấy dữ liệu từ PhieuSachCT ở Database lên Winform dùng cho tab(In phiếu trả)
        public DataTable SearchTicketBook_Tra_ByIDTicketBook(int idTicketBook)
        {

            string query = string.Format("select * from InPhieuTra({0})", idTicketBook);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public int CalTinhTienPhat(int idTicketBook)
        {
            int result = int.Parse(DataProvider.Instance.ExecuteScalar("select dbo.TongTienPhat( @MaPhieu ) ", new object[] { idTicketBook }).ToString());

            return result;
        }

    }
}
