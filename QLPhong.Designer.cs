
namespace BaiTapLon
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbb_trangthai = new System.Windows.Forms.ComboBox();
            this.cb_loaip = new System.Windows.Forms.ComboBox();
            this.btn_reset_der = new System.Windows.Forms.Button();
            this.btn_remove_der = new System.Windows.Forms.Button();
            this.btn_edit_der = new System.Windows.Forms.Button();
            this.btn_add_der = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_maphong = new System.Windows.Forms.TextBox();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(438, 9);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 397);
            this.panel2.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(438, 11);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(770, 398);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã phòng";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Loại phòng";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tình trạng";
            this.columnHeader3.Width = 100;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.cbb_trangthai);
            this.panel1.Controls.Add(this.cb_loaip);
            this.panel1.Controls.Add(this.btn_reset_der);
            this.panel1.Controls.Add(this.btn_remove_der);
            this.panel1.Controls.Add(this.btn_edit_der);
            this.panel1.Controls.Add(this.btn_add_der);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_maphong);
            this.panel1.Location = new System.Drawing.Point(50, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 397);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cbb_trangthai
            // 
            this.cbb_trangthai.FormattingEnabled = true;
            this.cbb_trangthai.Location = new System.Drawing.Point(143, 200);
            this.cbb_trangthai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbb_trangthai.Name = "cbb_trangthai";
            this.cbb_trangthai.Size = new System.Drawing.Size(133, 23);
            this.cbb_trangthai.TabIndex = 13;
            // 
            // cb_loaip
            // 
            this.cb_loaip.FormattingEnabled = true;
            this.cb_loaip.Location = new System.Drawing.Point(143, 134);
            this.cb_loaip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_loaip.Name = "cb_loaip";
            this.cb_loaip.Size = new System.Drawing.Size(133, 23);
            this.cb_loaip.TabIndex = 12;
            // 
            // btn_reset_der
            // 
            this.btn_reset_der.Location = new System.Drawing.Point(177, 352);
            this.btn_reset_der.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_reset_der.Name = "btn_reset_der";
            this.btn_reset_der.Size = new System.Drawing.Size(98, 33);
            this.btn_reset_der.TabIndex = 11;
            this.btn_reset_der.Text = "Làm mới";
            this.btn_reset_der.UseVisualStyleBackColor = true;
            this.btn_reset_der.Click += new System.EventHandler(this.btn_reset_der_Click);
            // 
            // btn_remove_der
            // 
            this.btn_remove_der.Location = new System.Drawing.Point(36, 352);
            this.btn_remove_der.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_remove_der.Name = "btn_remove_der";
            this.btn_remove_der.Size = new System.Drawing.Size(110, 33);
            this.btn_remove_der.TabIndex = 10;
            this.btn_remove_der.Text = "Xóa";
            this.btn_remove_der.UseVisualStyleBackColor = true;
            this.btn_remove_der.Click += new System.EventHandler(this.btn_remove_der_Click);
            // 
            // btn_edit_der
            // 
            this.btn_edit_der.Location = new System.Drawing.Point(177, 309);
            this.btn_edit_der.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_edit_der.Name = "btn_edit_der";
            this.btn_edit_der.Size = new System.Drawing.Size(98, 38);
            this.btn_edit_der.TabIndex = 9;
            this.btn_edit_der.Text = "Sửa";
            this.btn_edit_der.UseVisualStyleBackColor = true;
            this.btn_edit_der.Click += new System.EventHandler(this.btn_edit_der_Click);
            // 
            // btn_add_der
            // 
            this.btn_add_der.Location = new System.Drawing.Point(38, 309);
            this.btn_add_der.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_add_der.Name = "btn_add_der";
            this.btn_add_der.Size = new System.Drawing.Size(108, 38);
            this.btn_add_der.TabIndex = 8;
            this.btn_add_der.Text = "Thêm";
            this.btn_add_der.UseVisualStyleBackColor = true;
            this.btn_add_der.Click += new System.EventHandler(this.btn_add_der_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(39, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Trạng thái:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(36, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Loại phòng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(38, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã phòng:";
            // 
            // txt_maphong
            // 
            this.txt_maphong.Location = new System.Drawing.Point(143, 48);
            this.txt_maphong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_maphong.Name = "txt_maphong";
            this.txt_maphong.Size = new System.Drawing.Size(133, 23);
            this.txt_maphong.TabIndex = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Giá( 1ngay)";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Số người tối đa";
            this.columnHeader6.Width = 100;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1253, 432);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cb_loaip;
        private System.Windows.Forms.Button btn_reset_der;
        private System.Windows.Forms.Button btn_remove_der;
        private System.Windows.Forms.Button btn_edit_der;
        private System.Windows.Forms.Button btn_add_der;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_maphong;
        private System.Windows.Forms.ComboBox cbb_trangthai;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}