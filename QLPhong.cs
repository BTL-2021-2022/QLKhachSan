
using BaiTapLon.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon
{
    public partial class Form3 : Form
    {
        QLKhachSanContext db = new QLKhachSanContext();
        public Form3()
        {
            InitializeComponent();
        }
        private void HienThiPhong()
        {
            listView1.Items.Clear();
            var phong_query = from phong in db.Phongs
                              join loaiphong in db.LoaiPhongs on phong.MaLoaiPhong equals loaiphong.MaLoaiPhong
                              select new
                              {
                                  MaPhong = phong.MaPhong,
                                  LoaiPhong = loaiphong.TenLoai,
                                  TinhTrang = phong.TrangThai,
                                  Gia = loaiphong.DonGia,
                                  Songuoitoida = loaiphong.SoNguoiToiDa
                              };
            var DS_Phong = phong_query.ToList();

            for (var i = 0; i < DS_Phong.Count(); i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = DS_Phong[i].MaPhong;
                listView1.Items.Add(item);
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = DS_Phong[i].LoaiPhong });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = DS_Phong[i].TinhTrang });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = DS_Phong[i].Gia.ToString() });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = DS_Phong[i].Songuoitoida.ToString() });
            }
            //load loai phong va trang thai
            var loai_phong = (from loaip in db.LoaiPhongs
                              select loaip.TenLoai).ToArray();
            cb_loaip.Items.Clear();
            cbb_trangthai.Items.Clear();
            foreach (var item in loai_phong)
            {
                cb_loaip.Items.Add(item);
            }
            var trang_thai = (from status in db.Phongs
                              select status.TrangThai).Distinct().ToArray();
            foreach (var item in trang_thai)
            {
                cbb_trangthai.Items.Add(item);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private bool Dulieuhople()
        {
            bool hople = false;
            if (!string.IsNullOrEmpty(txt_maphong.Text))
            {
                if (!string.IsNullOrEmpty(cbb_trangthai.Text))
                {
                    if (!string.IsNullOrEmpty(cb_loaip.Text))
                    {
                        hople = true;
                    }
                    else
                    {
                        MessageBox.Show("Bạn cần chọn loại phòng", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_maphong.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn trang thai", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_maphong.Focus();
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập mã phòng ", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_maphong.Focus();
            }
            return hople;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            HienThiPhong();
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            var position = listView1.FocusedItem.Index;
            txt_maphong.Text = listView1.Items[position].SubItems[0].Text;
            cb_loaip.Text = listView1.Items[position].SubItems[1].Text;
            cbb_trangthai.Text = listView1.Items[position].SubItems[2].Text;

        }
        private void btn_add_der_Click(object sender, EventArgs e)
        {
            if (Dulieuhople())
            {
                var ds_phong = from phong in db.Phongs
                               where phong.MaPhong.Equals(txt_maphong.Text)
                               select phong;
                if (ds_phong.ToList().Count <= 0)
                {
                    Phong p = new Phong();
                    p.MaPhong = txt_maphong.Text;
                    //p.TrangThai = cbb_trangthai.Text;
                    var loaiP = from lp in db.LoaiPhongs
                                where lp.TenLoai.Equals(cb_loaip.Text)
                                select lp.MaLoaiPhong;
                    p.MaLoaiPhong = loaiP.ToList().FirstOrDefault().ToString();
                    db.Phongs.Add(p);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiPhong();
                }
                else
                {
                    MessageBox.Show("Mã phòng đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_edit_der_Click(object sender, EventArgs e)
        {
            var ds_phong = from phong in db.Phongs
                           where phong.MaPhong.Equals(txt_maphong.Text)
                           select phong;
            Phong p = ds_phong.FirstOrDefault();
            if (Dulieuhople())
            {
                if (ds_phong.ToList().Count > 0)
                {
                    //p.TrangThai = cbb_trangthai.Text;

                    var loaiP = from lp in db.LoaiPhongs
                                where lp.TenLoai.Equals(cb_loaip.Text)
                                select lp.MaLoaiPhong;
                    p.MaLoaiPhong = loaiP.ToList().FirstOrDefault().ToString();
                    MessageBox.Show("Đã chỉnh sửa xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.SaveChanges();
                    HienThiPhong();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã phòng ! Kiểm tra lại", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_maphong.Focus();
                }
            }
        }

        private void btn_remove_der_Click(object sender, EventArgs e)
        {
            var ds_phong = from phong in db.Phongs
                           where phong.MaPhong.Equals(txt_maphong.Text)
                           select phong;
            if (ds_phong.ToList().Count > 0)
            {
                Phong p = ds_phong.FirstOrDefault();
                DialogResult check = MessageBox.Show("Bạn có muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    db.Phongs.Remove(p);
                    db.SaveChanges();
                    HienThiPhong();
                }
            }
            else
            {
                MessageBox.Show("Mã phòng không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_reset_der_Click(object sender, EventArgs e)
        {
            txt_maphong.Text = "";
            cbb_trangthai.Text = "";
            cb_loaip.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
