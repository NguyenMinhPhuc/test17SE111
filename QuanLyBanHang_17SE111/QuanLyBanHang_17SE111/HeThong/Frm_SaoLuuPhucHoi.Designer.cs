namespace QuanLyBanHang_17SE111.HeThong
{
    partial class Frm_SaoLuuPhucHoi
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.btnThucThi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường dẫn file:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(155, 26);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(504, 29);
            this.txtPath.TabIndex = 1;
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(665, 22);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(96, 39);
            this.btnChonFile.TabIndex = 2;
            this.btnChonFile.Text = "Chọn file";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // btnThucThi
            // 
            this.btnThucThi.Location = new System.Drawing.Point(504, 61);
            this.btnThucThi.Name = "btnThucThi";
            this.btnThucThi.Size = new System.Drawing.Size(155, 41);
            this.btnThucThi.TabIndex = 3;
            this.btnThucThi.Text = "Sao lưu";
            this.btnThucThi.UseVisualStyleBackColor = true;
            this.btnThucThi.Click += new System.EventHandler(this.btnThucThi_Click);
            // 
            // Frm_SaoLuuPhucHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 112);
            this.Controls.Add(this.btnThucThi);
            this.Controls.Add(this.btnChonFile);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Frm_SaoLuuPhucHoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_SaoLuuPhucHoi";
            this.Load += new System.EventHandler(this.Frm_SaoLuuPhucHoi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.Button btnThucThi;
    }
}