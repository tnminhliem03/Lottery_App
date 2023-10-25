
namespace LotteryApp
{
    partial class FormHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHistory));
            this.lbWin = new System.Windows.Forms.Label();
            this.lbLose = new System.Windows.Forms.Label();
            this.lbPlay = new System.Windows.Forms.Label();
            this.lbMoney = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMaLanChoi = new System.Windows.Forms.TextBox();
            this.txtMauPhieu = new System.Windows.Forms.TextBox();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.btnXóa = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.lbSoTienHienTai = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnHienDs = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lbWin
            // 
            this.lbWin.AutoSize = true;
            this.lbWin.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWin.Location = new System.Drawing.Point(125, 90);
            this.lbWin.Name = "lbWin";
            this.lbWin.Size = new System.Drawing.Size(176, 41);
            this.lbWin.TabIndex = 0;
            this.lbWin.Text = "Mẫu phiếu:";
            // 
            // lbLose
            // 
            this.lbLose.AutoSize = true;
            this.lbLose.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLose.Location = new System.Drawing.Point(166, 140);
            this.lbLose.Name = "lbLose";
            this.lbLose.Size = new System.Drawing.Size(135, 41);
            this.lbLose.TabIndex = 0;
            this.lbLose.Text = "Kết quả:";
            // 
            // lbPlay
            // 
            this.lbPlay.AutoSize = true;
            this.lbPlay.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlay.Location = new System.Drawing.Point(109, 40);
            this.lbPlay.Name = "lbPlay";
            this.lbPlay.Size = new System.Drawing.Size(192, 41);
            this.lbPlay.TabIndex = 0;
            this.lbPlay.Text = "Mã lần chơi:";
            this.lbPlay.Click += new System.EventHandler(this.lbPlay_Click);
            // 
            // lbMoney
            // 
            this.lbMoney.AutoSize = true;
            this.lbMoney.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoney.Location = new System.Drawing.Point(179, 190);
            this.lbMoney.Name = "lbMoney";
            this.lbMoney.Size = new System.Drawing.Size(122, 41);
            this.lbMoney.TabIndex = 0;
            this.lbMoney.Text = "Số tiền:";
            // 
            // dgv
            // 
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgv.Location = new System.Drawing.Point(80, 262);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(812, 448);
            this.dgv.TabIndex = 1;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.Click += new System.EventHandler(this.dgv_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Ma Lan Choi";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mau Phieu";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 230;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ket Qua";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "So Tien";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 250;
            // 
            // txtMaLanChoi
            // 
            this.txtMaLanChoi.Location = new System.Drawing.Point(335, 52);
            this.txtMaLanChoi.Name = "txtMaLanChoi";
            this.txtMaLanChoi.Size = new System.Drawing.Size(300, 30);
            this.txtMaLanChoi.TabIndex = 2;
            // 
            // txtMauPhieu
            // 
            this.txtMauPhieu.Location = new System.Drawing.Point(335, 102);
            this.txtMauPhieu.Name = "txtMauPhieu";
            this.txtMauPhieu.Size = new System.Drawing.Size(300, 30);
            this.txtMauPhieu.TabIndex = 2;
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(335, 152);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(300, 30);
            this.txtKetQua.TabIndex = 2;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(335, 202);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(300, 30);
            this.txtSoTien.TabIndex = 2;
            // 
            // btnXóa
            // 
            this.btnXóa.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXóa.Location = new System.Drawing.Point(659, 40);
            this.btnXóa.Name = "btnXóa";
            this.btnXóa.Size = new System.Drawing.Size(104, 51);
            this.btnXóa.TabIndex = 3;
            this.btnXóa.Text = "Xóa";
            this.btnXóa.UseVisualStyleBackColor = true;
            this.btnXóa.Click += new System.EventHandler(this.btnXóa_Click);
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(672, 111);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(205, 51);
            this.btnTim.TabIndex = 3;
            this.btnTim.Text = "Tìm Kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // lbSoTienHienTai
            // 
            this.lbSoTienHienTai.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoTienHienTai.Location = new System.Drawing.Point(76, 727);
            this.lbSoTienHienTai.Name = "lbSoTienHienTai";
            this.lbSoTienHienTai.Size = new System.Drawing.Size(816, 38);
            this.lbSoTienHienTai.TabIndex = 4;
            this.lbSoTienHienTai.Text = "Số tiền hiện có:";
            this.lbSoTienHienTai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Silver;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(12, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(80, 60);
            this.btnHome.TabIndex = 53;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnHienDs
            // 
            this.btnHienDs.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienDs.Location = new System.Drawing.Point(659, 181);
            this.btnHienDs.Name = "btnHienDs";
            this.btnHienDs.Size = new System.Drawing.Size(233, 51);
            this.btnHienDs.TabIndex = 3;
            this.btnHienDs.Text = "Hiện danh sách";
            this.btnHienDs.UseVisualStyleBackColor = true;
            this.btnHienDs.Click += new System.EventHandler(this.btnHienDs_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(788, 40);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(104, 51);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // FormHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(983, 821);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.lbSoTienHienTai);
            this.Controls.Add(this.btnHienDs);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXóa);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.txtMauPhieu);
            this.Controls.Add(this.txtMaLanChoi);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lbLose);
            this.Controls.Add(this.lbMoney);
            this.Controls.Add(this.lbPlay);
            this.Controls.Add(this.lbWin);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(983, 821);
            this.MinimumSize = new System.Drawing.Size(983, 821);
            this.Name = "FormHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lô tô 2023";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormHistory_FormClosed);
            this.Load += new System.EventHandler(this.FormHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbWin;
        private System.Windows.Forms.Label lbLose;
        private System.Windows.Forms.Label lbPlay;
        private System.Windows.Forms.Label lbMoney;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txtMaLanChoi;
        private System.Windows.Forms.TextBox txtMauPhieu;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Button btnXóa;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label lbSoTienHienTai;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnHienDs;
        private System.Windows.Forms.Button btnSua;
    }
}