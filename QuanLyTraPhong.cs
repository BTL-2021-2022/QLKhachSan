using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTapLon.DataModels;
namespace BaiTapLon
{
    public partial class QuanLyTraPhong : Form
    {
        string user;
        QLKhachSanContext db = new QLKhachSanContext();
        public QuanLyTraPhong()
        {
            InitializeComponent();
        }
   
      
        public QuanLyTraPhong(string user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void phieuthuephong()
        {
            var query1 = from phong in db.PhieuThuePhongs
                         join chitiet in db.ChiTietThuePhongs on phong.MaPhieuThuePhong equals chitiet.MaPhieuThuePhong
                         join pho in db.Phongs on chitiet.MaPhong equals pho.MaPhong
                         join kh in db.KhachHangs on phong.MaKh equals kh.MaKh
                         join loaiphong in db.LoaiPhongs on pho.MaLoaiPhong equals loaiphong.MaLoaiPhong
                         select new { phong.MaPhieuThuePhong, phong.MaKh, phong.NgayDen, phong.NgayDi, pho.MaPhong,kh.SoCmnd,loaiphong.DonGia };
            ViewPhieuThuePhong.DataSource = query1.ToList();
        }
        private void dichvu()
        {
            var query1 = from PhieuDichVu in db.PhieuDichVus
                         join dichvu in db.DichVus on PhieuDichVu.MaDv equals dichvu.MaDv
                         select new { PhieuDichVu.MaDv, PhieuDichVu.MaPhieuThuePhong, PhieuDichVu.SoLuong, PhieuDichVu.TongTien, dichvu.TenDv, dichvu.DonGiaDv };
            viewPhieuDichVu.DataSource = query1.ToList();
        }
        private void phong()
        {
            var query1 = from phong in db.Phongs
                         join loaiphong in db.LoaiPhongs on phong.MaLoaiPhong equals loaiphong.MaLoaiPhong

                         select new { phong.MaPhong, phong.MaLoaiPhong, loaiphong.TenLoai, loaiphong.DonGia };
            ViewPhong.DataSource = query1.ToList();
        }
        private void QuanLyTraPhong_Load(object sender, EventArgs e)
        {
            phong();
            phieuthuephong();
            dichvu();
           
        }

        private void btnTimPhieuThue_Click(object sender, EventArgs e)
        {
            Phong ptpTim = (from pdp in db.Phongs
                            join chitiet in db.ChiTietThuePhongs on pdp.MaPhong equals chitiet.MaPhong
                            join phieuthue in db.PhieuThuePhongs on chitiet.MaPhieuThuePhong equals phieuthue.MaPhieuThuePhong
                            join kh in db.KhachHangs on phieuthue.MaKh equals kh.MaKh
                            where pdp.MaPhong == txtMaPhieuThue.Text || kh.SoCmnd == txtCccd.Text
                            select pdp).FirstOrDefault();

            var query1 = from phong in db.PhieuThuePhongs
                         join chitiet in db.ChiTietThuePhongs on phong.MaPhieuThuePhong equals chitiet.MaPhieuThuePhong
                         join pho in db.Phongs on chitiet.MaPhong equals pho.MaPhong
                         join kh in db.KhachHangs on phong.MaKh equals kh.MaKh
                         join loaiphong in db.LoaiPhongs on pho.MaLoaiPhong equals loaiphong.MaLoaiPhong
                         where (pho.MaPhong==txtMaPhieuThue.Text  || kh.SoCmnd==txtCccd.Text )
                         select new { phong.MaPhieuThuePhong, phong.MaKh, phong.NgayDen, phong.NgayDi, pho.MaPhong, kh.SoCmnd,loaiphong.DonGia };

            if (ptpTim == null)
            {
                MessageBox.Show("Không tồn tại mã phòng !" + txtMaDichVu.Text);
                txtMaPhong.Focus();
                phieuthuephong();
            }
            else
            {
                ViewPhieuThuePhong.DataSource = query1.ToList();

            }
        }

        private void btnTimPhong_Click(object sender, EventArgs e)
        {
            Phong ptpTim = (from pdp in db.Phongs
                            where pdp.MaPhong == txtMaPhong.Text
                            select pdp).FirstOrDefault();
            var query = from phong in db.Phongs
                        join loaiphong in db.LoaiPhongs on phong.MaLoaiPhong equals loaiphong.MaLoaiPhong
                        where phong.MaPhong == txtMaPhong.Text
                        select new { phong.MaPhong, phong.MaLoaiPhong, loaiphong.TenLoai, loaiphong.DonGia };

            if (ptpTim == null)
            {
                MessageBox.Show("Không tồn tại mã phòng !" + txtMaDichVu.Text);
                txtMaPhong.Focus();
                phong();
            }
            else
            {
                ViewPhong.DataSource = query.ToList();

            }
        }

        private void btnTimDichVu_Click(object sender, EventArgs e)
        {
    
            PhieuDichVu ptpTim = (from PhieuDichVu in db.PhieuDichVus
                             where PhieuDichVu.MaPhieuThuePhong == txtMaDichVu.Text
                             select PhieuDichVu).FirstOrDefault();
            var query = from PhieuDichVu in db.PhieuDichVus
                        join dichvu in db.DichVus on PhieuDichVu.MaDv equals dichvu.MaDv
                        where PhieuDichVu.MaPhieuThuePhong == txtMaDichVu.Text
                        select new { PhieuDichVu.MaDv, PhieuDichVu.MaPhieuThuePhong, PhieuDichVu.SoLuong, PhieuDichVu.TongTien, dichvu.TenDv, dichvu.DonGiaDv };

            if (ptpTim == null)
            {
                MessageBox.Show("Không tồn tại mã phiếu thuê phòng !" + txtMaDichVu.Text);
                txtMaDichVu.Focus();
                dichvu();
            }
            else
            {
                viewPhieuDichVu.DataSource = query.ToList();

            }
        }

        private void ViewPhieuThuePhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ViewPhieuThuePhong.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ViewPhieuThuePhong.CurrentRow.Selected = true;
                    txtPhieuThue.Text = ViewPhieuThuePhong.Rows[e.RowIndex].Cells["MaPhieuThuePhong"].FormattedValue.ToString();
                    txtMaKH.Text = ViewPhieuThuePhong.Rows[e.RowIndex].Cells["MaKH"].FormattedValue.ToString();
                    txtPhong.Text = ViewPhieuThuePhong.Rows[e.RowIndex].Cells["MaPhong"].FormattedValue.ToString();
                    txtNgayDen.Text = ViewPhieuThuePhong.Rows[e.RowIndex].Cells["NgayDen"].FormattedValue.ToString();
                    txtgiaPhong.Text = ViewPhieuThuePhong.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn3"].FormattedValue.ToString();
                    txtNgayDi.Text = ViewPhieuThuePhong.Rows[e.RowIndex].Cells["NgayDi"].FormattedValue.ToString();

                   
                }
            }
            catch(Exception ) {
               
            };
          
        }

        private void viewPhieuDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void viewPhieuDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
            if (viewPhieuDichVu.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                ViewPhieuThuePhong.CurrentRow.Selected = true;
          
                var tongtien = (from ptp in db.PhieuDichVus
                                where ptp.MaPhieuThuePhong == viewPhieuDichVu.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].FormattedValue.ToString()
                                select ptp);
                double a = 0;
                foreach (var group in tongtien)
                {

                    double x = double.Parse(group.TongTien.ToString());
                    a = a + x;

                }
                txtTienDichVu.Text = a.ToString();

            }
            }
            catch (Exception) { };
        }

        private void ViewPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            try { 
                if (txtNgayDi.Text == "")
            {
                string a = txtNgayDen.Text;
                txtNgayDi.Text = DateTime.Now.ToString();
                string b = txtNgayDi.Text;
                TimeSpan timeSpan;

                DateTime c = DateTime.Parse(a);
                DateTime d = d = DateTime.Now;
                timeSpan = d - c;

                txtSoNgayO.Text = timeSpan.Days.ToString();
                double x = double.Parse(txtSoNgayO.Text) * double.Parse(txtgiaPhong.Text);
                txtTienPhong.Text = x.ToString();
                PhieuThuePhong pt = (from ptp in db.PhieuThuePhongs
                                     where ptp.MaPhieuThuePhong == txtPhieuThue.Text
                                     select ptp).FirstOrDefault();
                pt.NgayDi = DateTime.Parse(txtNgayDi.Text);
                db.SaveChanges();
                btnTaoHoaDon.Visible = true;
                btnTinhTien.Visible = true;
                phieuthuephong();
            }
            else
            {
                MessageBox.Show("Phòng này đã được trả");
                btnTaoHoaDon.Visible = false;
                btnTinhTien.Visible = false;
            }
            }
            catch (Exception) { };
           

        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (txtTienDichVu.Text == "")
            {
                txtTienDichVu.Text = "0";
            }
            if (txtTienPhong.Text == "")
            {
                txtTienPhong.Text = "0";
            }
            double a = double.Parse(txtTienDichVu.Text) + double.Parse(txtTienPhong.Text);

            txtTongTien.Text = a.ToString();
            MessageBox.Show("Tổng tiền khách hàng cần thanh toán là: " + txtTongTien.Text);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            txtPhieuThue.Clear();
            txtMaKH.Clear();
            txtPhong.Clear();
            txtgiaPhong.Clear();
            txtNgayDen.Clear();
            txtNgayDi.Clear();
            txtSoNgayO.Clear();
            txtTienPhong.Clear();
            txtTienDichVu.Clear();
            txtTongTien.Clear();
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            if(txtNgayDi.Text != "")
            {

                fHoaDon fhd = new fHoaDon(user);
                fhd.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng trả phòng trước khi tạo hóa đơn");
            }

        }
    }
}
