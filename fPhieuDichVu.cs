using BaiTapLon.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon
{
    public partial class fPhieuDichVu : Form
    {
        QLKhachSanContext db = new QLKhachSanContext();
        int i = 0;
        int d;
        double tongtien = 0;
        public fPhieuDichVu()
        {
            InitializeComponent();
        }

        private void fPhieuDichVu_Load(object sender, EventArgs e)
        {
            var dv = from d in db.DichVus
                     select d;
            cboMaDichVu.DataSource = dv.ToList();
            cboMaDichVu.DisplayMember = "TenDv";
            cboMaDichVu.ValueMember = "MaDv";
           
        }
        private void HienThi()
        {
            dgvDV.Rows.Clear();
            var dv = (from d in db.DichVus join p in db.PhieuDichVus on d.MaDv equals p.MaDv
                      where d.MaDv.Equals(cboMaDichVu.SelectedValue.ToString())
                      select new
                      {
                          MaDichVu = d.MaDv,
                          TenDichVu = d.TenDv,
                          SoLuong = int.Parse(txtSoLuong.Text),
                          DonGia = d.DonGiaDv,
                          ThanhTien = int.Parse(txtSoLuong.Text) * d.DonGiaDv
                      });
            dgvDV.DataSource = dv.ToList();
        }
        public void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                
                var dv = (from d in db.DichVus
                          where d.MaDv.Equals(cboMaDichVu.SelectedValue.ToString())
                          select new
                          {
                              MaDichVu = d.MaDv,
                              TenDichVu = d.TenDv,
                              SoLuong = int.Parse(txtSoLuong.Text),
                              DonGia = d.DonGiaDv,
                              ThanhTien = int.Parse(txtSoLuong.Text) * d.DonGiaDv
                          }).FirstOrDefault();
                PhieuDichVu pdvMoi = new PhieuDichVu();
                pdvMoi.MaDv = cboMaDichVu.SelectedValue.ToString();
                pdvMoi.MaPhieuThuePhong = txtMPT.Text;
                pdvMoi.SoLuong = int.Parse(txtSoLuong.Text);
                pdvMoi.TongTien = dv.ThanhTien;

                dgvDV.Rows.Add();
                dgvDV.Rows[i].Cells[0].Value = dv.MaDichVu.ToString();
                dgvDV.Rows[i].Cells[1].Value = dv.TenDichVu.ToString();
                dgvDV.Rows[i].Cells[2].Value = dv.SoLuong.ToString();
                dgvDV.Rows[i].Cells[3].Value = dv.DonGia.ToString();
                dgvDV.Rows[i].Cells[4].Value = dv.ThanhTien.ToString();

                i++;
                txtdem.Text = i.ToString();
                tongtien += double.Parse(dv.ThanhTien.ToString());
                txtTongTien.Text = tongtien.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi nhập liệu","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtSoLuong.Focus();
            }
            //HienThi();

        }

        public void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMPT.Text!="")
                {

                    for (int j = 0; j < dgvDV.RowCount - 1; j++)
                    {
                        PhieuDichVu pdvMoi = new PhieuDichVu();
                        pdvMoi.MaDv = dgvDV.Rows[j].Cells[0].Value.ToString();
                        pdvMoi.MaPhieuThuePhong = txtMPT.Text;
                        pdvMoi.SoLuong = int.Parse(dgvDV.Rows[j].Cells[2].Value.ToString());
                        pdvMoi.TongTien = double.Parse(dgvDV.Rows[j].Cells[4].Value.ToString());
                        db.PhieuDichVus.Add(pdvMoi);

                    }
                    db.SaveChanges();

                    MessageBox.Show("Đã lưu phiếu dịch vụ thành công", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thiếu mã phiếu thuê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi nhập liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                var makh = (from kh in db.KhachHangs
                            where kh.SoCmnd.Equals(txtTen.Text)
                            select kh).FirstOrDefault();
                var mapt = (from pt in db.PhieuThuePhongs
                            where pt.MaKh.Equals(makh.MaKh)
                            select pt).FirstOrDefault();

                if (mapt!= null)
                {
                    txtMPT.Text = mapt.MaPhieuThuePhong.ToString(); 
                }
                else
                {
                    MessageBox.Show("Không tồn tại khách hàng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi nhâp liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
            }
        }

        
        
    }
}
