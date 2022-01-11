using BaiTapLon.DataModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheFont = System.Drawing.Font;

namespace BaiTapLon
{
    
    public partial class DoanhThuPhong : Form
    {
        QLKhachSanContext db = new QLKhachSanContext();
        DateTime since;
        DateTime _date;
        public DoanhThuPhong()
        {
            InitializeComponent();
        }
        private void DoanhThuPhong_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            since = dateTimePicker1.Value;
           _date = dateTimePicker2.Value;
            var result = (from hd in db.HoaDons
                          join phieutp in db.PhieuThuePhongs on hd.MaPhieuThuePhong equals phieutp.MaPhieuThuePhong
                          join cttp in db.ChiTietThuePhongs on hd.MaPhieuThuePhong equals cttp.MaPhieuThuePhong
                          where since <= hd.NgayThanhToan && hd.NgayThanhToan<= _date
                          select new
                          { 
                              mahd = hd.MaHoaDon,
                              maphieuthuep = phieutp.MaPhieuThuePhong,
                             //tongtien = hd.TongTien,
                              ngaythanhtoan = hd.NgayThanhToan,
                              makh = phieutp.MaKh
                          }).ToList();
            for (int i = 0; i < result.Count; i++)
            {
                var list = (from ct in db.ChiTietThuePhongs
                            where ct.MaPhieuThuePhong == result[i].maphieuthuep
                            join ps in db.Phongs on ct.MaPhong equals ps.MaPhong
                            select new
                            {
                                mp = ct.MaPhong,
                                mlp = ps.MaLoaiPhong,     
                            }).ToList().FirstOrDefault();
                data_doanhthudv.Rows.Add();
                data_doanhthudv.Rows[i].Cells[0].Value = list.mp.ToString();
                data_doanhthudv.Rows[i].Cells[1].Value = result[i].makh.ToString();
                data_doanhthudv.Rows[i].Cells[2].Value = String.Format("{0:dd/MM/yyyy}", result[i].ngaythanhtoan);
                var lp = (from d in db.LoaiPhongs
                          where d.MaLoaiPhong == list.mlp
                          select d.DonGia
                          ).ToList().FirstOrDefault();
                data_doanhthudv.Rows[i].Cells[3].Value = ((float)(lp)).ToString("N0");
            }
            thanhtien();
    }

        private void thanhtien()
        {
            int sc = data_doanhthudv.Rows.Count;
            float tien = 0;
            for (int m = 0; m < sc ; m++)
            {
                tien += float.Parse(data_doanhthudv.Rows[m].Cells[3].Value.ToString());
            }
            txt_tongtien.Text = tien.ToString("N0");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {
           
            if(data_doanhthudv.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "DoanhThuPhong.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(data_doanhthudv.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
                            BaseFont baseFont = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            iTextSharp.text.Font fontVN = new iTextSharp.text.Font(baseFont, 12);
                            iTextSharp.text.Font fontVN1 = new iTextSharp.text.Font(baseFont, 12,3, BaseColor.RED);

                            foreach (DataGridViewColumn column in data_doanhthudv.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText,fontVN));
                                cell.BackgroundColor = BaseColor.GREEN;
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in data_doanhthudv.Rows)
                            {
                               
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                        pdfTable.AddCell(cell.Value.ToString());
                                }
                                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                {
                                    string heading = "BÁO CÁO DOANH THU PHÒNG ";
                                    Paragraph p1 = new Paragraph(heading, fontVN);
                                    p1.Alignment = Element.ALIGN_CENTER;
                                    string title = $"Từ: {since.ToString("dd/MM/yyyy")}                                                                                   Đến:{_date.ToString("dd/MM/yyyy")} ";
                                    Paragraph p2 = new Paragraph(title, fontVN);
                                    p2.Alignment = Element.ALIGN_CENTER;
                                    p2.SpacingAfter = 12;
                                    int sc = data_doanhthudv.Rows.Count;
                                    float tien = 0;
                                    for (int m = 0; m < sc; m++)
                                    {
                                        tien += float.Parse(data_doanhthudv.Rows[m].Cells[3].Value.ToString());
                                    }
                                    Paragraph p3 = new Paragraph($"Tổng doanh thu: {tien.ToString("N0")} VND ", fontVN1);
                                    p3.Alignment = Element.ALIGN_RIGHT;
                                    p3.SpacingBefore = 12;
                                    Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                    PdfWriter.GetInstance(pdfDoc, stream);
                                    pdfDoc.Open();
                                    pdfDoc.Add(p1);
                                    pdfDoc.Add(p2);
                                    pdfDoc.Add(pdfTable);
                                    pdfDoc.Add(p3);
                                    pdfDoc.Close();
                                    stream.Close();
                                }  
                            }
                            MessageBox.Show("Dữ liệu Export thành công!!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Mô tả lỗi :" + ex.Message);
                        }
                    }
                }
            }
        else
            {
                MessageBox.Show("Không có bản ghi nào được Export!!!", "Info");
            }
        }
    }
}
