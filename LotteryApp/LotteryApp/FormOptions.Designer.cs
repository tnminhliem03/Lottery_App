
namespace LotteryApp
{
    partial class FormOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
            this.btOption1 = new System.Windows.Forms.Button();
            this.btOption2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btOption3 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.nhacNen = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhacNen)).BeginInit();
            this.SuspendLayout();
            // 
            // btOption1
            // 
            this.btOption1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btOption1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOption1.ForeColor = System.Drawing.Color.White;
            this.btOption1.Location = new System.Drawing.Point(471, 517);
            this.btOption1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOption1.Name = "btOption1";
            this.btOption1.Size = new System.Drawing.Size(211, 72);
            this.btOption1.TabIndex = 1;
            this.btOption1.Text = "CHỌN PHIẾU";
            this.btOption1.UseVisualStyleBackColor = false;
            this.btOption1.Click += new System.EventHandler(this.btOption1_Click);
            // 
            // btOption2
            // 
            this.btOption2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btOption2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOption2.ForeColor = System.Drawing.Color.White;
            this.btOption2.Location = new System.Drawing.Point(471, 399);
            this.btOption2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOption2.Name = "btOption2";
            this.btOption2.Size = new System.Drawing.Size(211, 95);
            this.btOption2.TabIndex = 3;
            this.btOption2.Text = "CHỌN NGẪU NHIÊN\r\n(Máy đoán số tự động lần quay ra)";
            this.btOption2.UseVisualStyleBackColor = false;
            this.btOption2.Click += new System.EventHandler(this.btOption2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(274, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(588, 338);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btOption3
            // 
            this.btOption3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btOption3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOption3.ForeColor = System.Drawing.Color.White;
            this.btOption3.Location = new System.Drawing.Point(471, 629);
            this.btOption3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOption3.Name = "btOption3";
            this.btOption3.Size = new System.Drawing.Size(211, 72);
            this.btOption3.TabIndex = 4;
            this.btOption3.Text = "LỊCH SỬ";
            this.btOption3.UseVisualStyleBackColor = false;
            this.btOption3.Click += new System.EventHandler(this.btOption3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::LotteryApp.Properties.Resources.cross;
            this.pictureBox2.Location = new System.Drawing.Point(1028, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // nhacNen
            // 
            this.nhacNen.Enabled = true;
            this.nhacNen.Location = new System.Drawing.Point(491, 173);
            this.nhacNen.Name = "nhacNen";
            this.nhacNen.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("nhacNen.OcxState")));
            this.nhacNen.Size = new System.Drawing.Size(100, 31);
            this.nhacNen.TabIndex = 0;
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1154, 837);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btOption3);
            this.Controls.Add(this.btOption2);
            this.Controls.Add(this.btOption1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.nhacNen);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1154, 837);
            this.MinimumSize = new System.Drawing.Size(1154, 837);
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lô tô 2023";
            this.Load += new System.EventHandler(this.FormOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhacNen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btOption1;
        private System.Windows.Forms.Button btOption2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btOption3;
        public AxWMPLib.AxWindowsMediaPlayer nhacNen;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}