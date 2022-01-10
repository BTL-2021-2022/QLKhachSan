
////using BaiTapLon.DataModels;
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
    public partial class QuanLyDichVu : Form
    {
        QLKhachSanContext db = new QLKhachSanContext();
        public QuanLyDichVu()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            HienThiDV();
        }
        private void HienThiDV()
        {
            listView1.Items.Clear();
            var sers_query = from dv in db.DichVus
                             join ldv in db.LoaiDichVus on dv.MaLoaiDv equals ldv.MaLoaiDv
                             select new
                             {
                                 MaDv = dv.MaDv,
                                 TenDv = dv.TenDv,
                                 LoaiDv = ldv.TenLoaiDv,
                                 DonGia = dv.DonGiaDv
                             };
            var ser = sers_query.ToList();

            for (var i = 0; i < ser.Count(); i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ser[i].MaDv;
                listView1.Items.Add(item);
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = ser[i].TenDv });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = ser[i].LoaiDv });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = ((int)(ser[i].DonGia)).ToString("N0") });

            }
            //load loai dich vu
            cb_loaidv.Items.Clear();
            var type_ser = (from ldv in db.LoaiDichVus
                            select ldv.TenLoaiDv).ToArray();
            foreach (var item in type_ser)
            {
                cb_loaidv.Items.Add(item);
            }
        }
        private bool Dulieuhople()
        {
            bool hople = false;

            if (!string.IsNullOrEmpty(txt_tendv.Text))
            {
                if (!string.IsNullOrEmpty(cb_loaidv.Text))
                {
                    if (!string.IsNullOrEmpty(txt_dongia.Text))
                    {
                        float check;
                        bool dongia = float.TryParse(txt_dongia.Text, out check);
                        if (dongia)
                        {
                            if (float.Parse(txt_dongia.Text) > 0)
                            {
                                hople = true;
                            }
                            else
                            {
                                MessageBox.Show("Đơn giá phải lớn hơn 0", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txt_dongia.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Bạn cần đơn giá là các chữ số ", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_dongia.Focus();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bạn cần nhập đơn giá dịch vụ ", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_tendv.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn loại dịch vụ ", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cb_loaidv.Focus();
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập tên dịch vụ ", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_tendv.Focus();
            }

            return hople;
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            var position = listView1.FocusedItem.Index;
            txt_madv.Text = listView1.Items[position].SubItems[0].Text;
            txt_tendv.Text = listView1.Items[position].SubItems[1].Text;
            cb_loaidv.Text = listView1.Items[position].SubItems[2].Text;
            txt_dongia.Text = listView1.Items[position].SubItems[3].Text;
        }
        private void btn_add_ser_Click(object sender, EventArgs e)
        {
            if (Dulieuhople())
            {
                var dv = from ser in db.DichVus
                         where ser.MaDv.Equals(txt_madv.Text)
                         select ser;
                txt_madv.Text = dv.ToArray().Length.ToString();
                if (dv.ToArray().Length < 0)
                {
                    DichVu service = new DichVu();
                    service.TenDv = txt_tendv.Text;
                    service.DonGiaDv = float.Parse(txt_dongia.Text);
                    var ma_ldv = from ldv in db.LoaiDichVus
                                 where ldv.TenLoaiDv.Equals(cb_loaidv.Text)
                                 select ldv.MaLoaiDv;
                    service.MaLoaiDv = ma_ldv.ToList().FirstOrDefault().ToString();
                    db.DichVus.Add(service);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDV();
                }
                else
                {
                    MessageBox.Show("Mã đang trùng! Vui lòng ấn Làm Mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Clear();
                }

            }
        }
        private void btn_edit_ser_Click(object sender, EventArgs e)
        {
            var modify_dv = from ser in db.DichVus
                            where ser.MaDv.Equals(txt_madv.Text)
                            select ser;
            DichVu service = modify_dv.FirstOrDefault();
            if (Dulieuhople())
            {
                if (modify_dv.ToList().Count > 0)
                {
                    service.TenDv = txt_tendv.Text;
                    service.DonGiaDv = float.Parse(txt_dongia.Text);
                    var ma_ldv = from ldv in db.LoaiDichVus
                                 where ldv.TenLoaiDv.Equals(cb_loaidv.Text)
                                 select ldv.MaLoaiDv;
                    service.MaLoaiDv = ma_ldv.ToList().FirstOrDefault().ToString();
                    MessageBox.Show("Đã chỉnh sửa xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.SaveChanges();

                    HienThiDV();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã dịch vụ ! Kiểm tra lại", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_madv.Focus();
                }
            }
        }

        private void btn_remove_ser_Click(object sender, EventArgs e)
        {
            var madv = from ser in db.DichVus
                       where ser.MaDv.Equals(txt_madv.Text)
                       select ser;
            if (madv.ToList().Count > 0)
            {
                DichVu dv = madv.FirstOrDefault();
                DialogResult check = MessageBox.Show("Bạn có muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    db.DichVus.Remove(dv);
                    db.SaveChanges();
                    HienThiDV();
                    Clear();
                }
            }
            else
            {
                MessageBox.Show("Mã dịch vụ không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txt_madv.Text = "";
            txt_tendv.Text = "";
            cb_loaidv.Text = "";
            txt_dongia.Text = "";
        }
        private void btn_reset_ser_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txt_tendv_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
