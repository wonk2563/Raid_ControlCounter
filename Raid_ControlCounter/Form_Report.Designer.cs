namespace Raid_ControlCounter
{
    partial class Form_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Report));
            this.panel_CTRLBar = new System.Windows.Forms.Panel();
            this.label_Box = new System.Windows.Forms.Label();
            this.pictureBox_EXIT = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox_content = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox_main = new System.Windows.Forms.RichTextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.panel_CTRLBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EXIT)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox_content);
            this.groupBox1.Font = new System.Drawing.Font("OPPOSans M", 8.999999F);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 187);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "問題描述";
            // 
            // richTextBox_content
            // 
            this.richTextBox_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_content.Font = new System.Drawing.Font("OPPOSans M", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_content.Location = new System.Drawing.Point(3, 19);
            this.richTextBox_content.Name = "richTextBox_content";
            this.richTextBox_content.Size = new System.Drawing.Size(318, 165);
            this.richTextBox_content.TabIndex = 1;
            this.richTextBox_content.Text = "";
            this.richTextBox_content.TextChanged += new System.EventHandler(this.richTextBox_content_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btn_send);
            this.panel1.Controls.Add(this.panel_CTRLBar);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 336);
            this.panel1.TabIndex = 14;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("OPPOSans M", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(189, 293);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(85, 30);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox_main);
            this.groupBox2.Font = new System.Drawing.Font("OPPOSans M", 8.999999F);
            this.groupBox2.Location = new System.Drawing.Point(12, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 52);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "主旨";
            // 
            // richTextBox_main
            // 
            this.richTextBox_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_main.Font = new System.Drawing.Font("OPPOSans M", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_main.Location = new System.Drawing.Point(3, 19);
            this.richTextBox_main.Name = "richTextBox_main";
            this.richTextBox_main.Size = new System.Drawing.Size(315, 30);
            this.richTextBox_main.TabIndex = 0;
            this.richTextBox_main.Text = "";
            this.richTextBox_main.TextChanged += new System.EventHandler(this.richTextBox_main_TextChanged);
            // 
            // btn_send
            // 
            this.btn_send.Enabled = false;
            this.btn_send.Font = new System.Drawing.Font("OPPOSans M", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.Location = new System.Drawing.Point(66, 293);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(85, 30);
            this.btn_send.TabIndex = 2;
            this.btn_send.Text = "回報";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // Form_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 336);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "回報";
            this.Activated += new System.EventHandler(this.Form_Report_Activated);
            this.panel_CTRLBar.ResumeLayout(false);
            this.panel_CTRLBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EXIT)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_CTRLBar;
        private System.Windows.Forms.Label label_Box;
        private System.Windows.Forms.PictureBox pictureBox_EXIT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox_content;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox_main;
        private System.Windows.Forms.Button btn_send;
    }
}