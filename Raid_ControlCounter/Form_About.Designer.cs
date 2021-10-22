namespace Raid_ControlCounter
{
    partial class Form_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_About));
            this.panel_CTRLBar = new System.Windows.Forms.Panel();
            this.label_Box = new System.Windows.Forms.Label();
            this.pictureBox_EXIT = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_CTRLBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EXIT)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_CTRLBar
            // 
            this.panel_CTRLBar.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel_CTRLBar.Controls.Add(this.label_Box);
            this.panel_CTRLBar.Controls.Add(this.pictureBox_EXIT);
            this.panel_CTRLBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_CTRLBar.Location = new System.Drawing.Point(0, 0);
            this.panel_CTRLBar.Name = "panel_CTRLBar";
            this.panel_CTRLBar.Size = new System.Drawing.Size(347, 32);
            this.panel_CTRLBar.TabIndex = 13;
            this.panel_CTRLBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_CTRLBar_MouseDown);
            this.panel_CTRLBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_CTRLBar_MouseMove);
            // 
            // label_Box
            // 
            this.label_Box.AutoSize = true;
            this.label_Box.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Box.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label_Box.Location = new System.Drawing.Point(13, 7);
            this.label_Box.Name = "label_Box";
            this.label_Box.Size = new System.Drawing.Size(39, 19);
            this.label_Box.TabIndex = 1;
            this.label_Box.Text = "標題";
            this.label_Box.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_Box_MouseDown);
            this.label_Box.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_Box_MouseMove);
            // 
            // pictureBox_EXIT
            // 
            this.pictureBox_EXIT.BackgroundImage = global::Raid_ControlCounter.Properties.Resources.EXIT;
            this.pictureBox_EXIT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_EXIT.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_EXIT.Location = new System.Drawing.Point(311, 4);
            this.pictureBox_EXIT.Name = "pictureBox_EXIT";
            this.pictureBox_EXIT.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_EXIT.TabIndex = 0;
            this.pictureBox_EXIT.TabStop = false;
            this.pictureBox_EXIT.Click += new System.EventHandler(this.pictureBox_EXIT_Click);
            this.pictureBox_EXIT.MouseEnter += new System.EventHandler(this.pictureBox_EXIT_MouseEnter);
            this.pictureBox_EXIT.MouseLeave += new System.EventHandler(this.pictureBox_EXIT_MouseLeave);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("OPPOSans M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(5, 28);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(309, 20);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "【閒聊】魔界襲擊戰控場與降抗相關資料整理";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Font = new System.Drawing.Font("OPPOSans M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel4.Location = new System.Drawing.Point(5, 90);
            this.linkLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(129, 20);
            this.linkLabel4.TabIndex = 10;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "星辰預言技能介紹";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("OPPOSans M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel3.Location = new System.Drawing.Point(5, 59);
            this.linkLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(286, 20);
            this.linkLabel3.TabIndex = 9;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "【討論】有關BQ血疊的降抗數值測試報告";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel3);
            this.groupBox1.Controls.Add(this.linkLabel4);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Font = new System.Drawing.Font("OPPOSans M", 8.999999F);
            this.groupBox1.Location = new System.Drawing.Point(12, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 122);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "計算公式來源";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OPPOSans M", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(141, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "大毛";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("OPPOSans M", 8.999999F);
            this.groupBox2.Location = new System.Drawing.Point(12, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 56);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "製作者";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.panel_CTRLBar);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 242);
            this.panel1.TabIndex = 14;
            // 
            // Form_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 242);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "關於";
            this.panel_CTRLBar.ResumeLayout(false);
            this.panel_CTRLBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EXIT)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_CTRLBar;
        private System.Windows.Forms.Label label_Box;
        private System.Windows.Forms.PictureBox pictureBox_EXIT;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
    }
}