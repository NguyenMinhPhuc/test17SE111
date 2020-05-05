namespace QuanLyBanHang_17SE111.HeThong
{
    partial class Frm_DoiMatKhau
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
            this.gbCapLaiMatKhau = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.btnResetMatKhau = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtMatKhau1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDoiMatKhau = new System.Windows.Forms.Button();
            this.gbCapLaiMatKhau.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCapLaiMatKhau
            // 
            this.gbCapLaiMatKhau.Controls.Add(this.label1);
            this.gbCapLaiMatKhau.Controls.Add(this.btnResetMatKhau);
            this.gbCapLaiMatKhau.Controls.Add(this.cboNhanVien);
            this.gbCapLaiMatKhau.Enabled = false;
            this.gbCapLaiMatKhau.Location = new System.Drawing.Point(12, 12);
            this.gbCapLaiMatKhau.Name = "gbCapLaiMatKhau";
            this.gbCapLaiMatKhau.Size = new System.Drawing.Size(465, 163);
            this.gbCapLaiMatKhau.TabIndex = 0;
            this.gbCapLaiMatKhau.TabStop = false;
            this.gbCapLaiMatKhau.Text = "Cấp lại mật khẩu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDoiMatKhau);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtMatKhau1);
            this.groupBox2.Controls.Add(this.txtMatKhau);
            this.groupBox2.Location = new System.Drawing.Point(12, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 180);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đổi mật khẩu";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(11, 66);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(448, 32);
            this.cboNhanVien.TabIndex = 0;
            // 
            // btnResetMatKhau
            // 
            this.btnResetMatKhau.Location = new System.Drawing.Point(301, 104);
            this.btnResetMatKhau.Name = "btnResetMatKhau";
            this.btnResetMatKhau.Size = new System.Drawing.Size(158, 43);
            this.btnResetMatKhau.TabIndex = 1;
            this.btnResetMatKhau.Text = "Cấp lại";
            this.btnResetMatKhau.UseVisualStyleBackColor = true;
            this.btnResetMatKhau.Click += new System.EventHandler(this.btnResetMatKhau_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn nhân viên";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(231, 44);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(228, 29);
            this.txtMatKhau.TabIndex = 0;
            // 
            // txtMatKhau1
            // 
            this.txtMatKhau1.Location = new System.Drawing.Point(231, 92);
            this.txtMatKhau1.Name = "txtMatKhau1";
            this.txtMatKhau1.Size = new System.Drawing.Size(227, 29);
            this.txtMatKhau1.TabIndex = 1;
            this.txtMatKhau1.Leave += new System.EventHandler(this.txtMatKhau1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nhập lại mật khẩu mới";
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Enabled = false;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(301, 127);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(157, 40);
            this.btnDoiMatKhau.TabIndex = 4;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.UseVisualStyleBackColor = true;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // Frm_DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 367);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbCapLaiMatKhau);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Frm_DoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_DoiMatKhau";
            this.Load += new System.EventHandler(this.Frm_DoiMatKhau_Load);
            this.gbCapLaiMatKhau.ResumeLayout(false);
            this.gbCapLaiMatKhau.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCapLaiMatKhau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnResetMatKhau;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDoiMatKhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMatKhau1;
        private System.Windows.Forms.TextBox txtMatKhau;
    }
}