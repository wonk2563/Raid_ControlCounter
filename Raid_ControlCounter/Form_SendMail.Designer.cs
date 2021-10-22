namespace Raid_ControlCounter
{
    partial class Form_SendMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SendMail));
            this.panel_CTRLBar = new System.Windows.Forms.Panel();
            this.pictureBox_EXIT = new System.Windows.Forms.PictureBox();
            this.label_Box = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_refresh = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker_send = new System.ComponentModel.BackgroundWorker();
            this.panel_CTRLBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EXIT)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_CTRLBar
            // 
            this.panel_CTRLBar.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel_CTRLBar.Controls.Add(this.pictureBox_EXIT);
            this.panel_CTRLBar.Controls.Add(this.label_Box);
            this.panel_CTRLBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_CTRLBar.Location = new System.Drawing.Point(0, 0);
            this.panel_CTRLBar.Name = "panel_CTRLBar";
            this.panel_CTRLBar.Size = new System.Drawing.Size(198, 32);
            this.panel_CTRLBar.TabIndex = 13;
            this.panel_CTRLBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_CTRLBar_MouseDown);
            this.panel_CTRLBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_CTRLBar_MouseMove);
            // 
            // pictureBox_EXIT
            // 
            this.pictureBox_EXIT.BackgroundImage = global::Raid_ControlCounter.Properties.Resources.EXIT;
            this.pictureBox_EXIT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_EXIT.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_EXIT.Location = new System.Drawing.Point(162, 4);
            this.pictureBox_EXIT.Name = "pictureBox_EXIT";
            this.pictureBox_EXIT.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_EXIT.TabIndex = 16;
            this.pictureBox_EXIT.TabStop = false;
            this.pictureBox_EXIT.Click += new System.EventHandler(this.pictureBox_EXIT_Click);
            this.pictureBox_EXIT.MouseEnter += new System.EventHandler(this.pictureBox_EXIT_MouseEnter);
            this.pictureBox_EXIT.MouseLeave += new System.EventHandler(this.pictureBox_EXIT_MouseLeave);
            // 
            // label_Box
            // 
            this.label_Box.AutoSize = true;
            this.label_Box.Font = new System.Drawing.Font("OPPOSans M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Box.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label_Box.Location = new System.Drawing.Point(13, 7);
            this.label_Box.Name = "label_Box";
            this.label_Box.Size = new System.Drawing.Size(39, 20);
            this.label_Box.TabIndex = 1;
            this.label_Box.Text = "標題";
            this.label_Box.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_Box_MouseDown);
            this.label_Box.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_Box_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox_refresh);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel_CTRLBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 180);
            this.panel1.TabIndex = 14;
            // 
            // pictureBox_refresh
            // 
            this.pictureBox_refresh.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_refresh.BackgroundImage = global::Raid_ControlCounter.Properties.Resources.refresh2;
            this.pictureBox_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_refresh.Location = new System.Drawing.Point(162, 38);
            this.pictureBox_refresh.Name = "pictureBox_refresh";
            this.pictureBox_refresh.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_refresh.TabIndex = 17;
            this.pictureBox_refresh.TabStop = false;
            this.pictureBox_refresh.Visible = false;
            this.pictureBox_refresh.Click += new System.EventHandler(this.pictureBox_refresh_Click);
            this.pictureBox_refresh.MouseEnter += new System.EventHandler(this.pictureBox_refresh_MouseEnter);
            this.pictureBox_refresh.MouseLeave += new System.EventHandler(this.pictureBox_refresh_MouseLeave);
            this.pictureBox_refresh.MouseHover += new System.EventHandler(this.pictureBox_refresh_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Raid_ControlCounter.Properties.Resources.loading;
            this.pictureBox1.Location = new System.Drawing.Point(59, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("OPPOSans M", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backgroundWorker_send
            // 
            this.backgroundWorker_send.WorkerReportsProgress = true;
            this.backgroundWorker_send.WorkerSupportsCancellation = true;
            this.backgroundWorker_send.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_send_DoWork);
            this.backgroundWorker_send.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_send_ProgressChanged);
            this.backgroundWorker_send.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_send_RunWorkerCompleted);
            // 
            // Form_SendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 180);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_SendMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "回報";
            this.panel_CTRLBar.ResumeLayout(false);
            this.panel_CTRLBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EXIT)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_CTRLBar;
        private System.Windows.Forms.Label label_Box;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker_send;
        private System.Windows.Forms.PictureBox pictureBox_EXIT;
        private System.Windows.Forms.PictureBox pictureBox_refresh;
    }
}