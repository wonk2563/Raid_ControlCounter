namespace Raid_ControlCounter
{
    partial class Form_update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_update));
            this.update_info_box = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_remindNextTime = new System.Windows.Forms.Button();
            this.btn_updateNow = new System.Windows.Forms.Button();
            this.update_info_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // update_info_box
            // 
            this.update_info_box.Controls.Add(this.label1);
            this.update_info_box.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.update_info_box.Location = new System.Drawing.Point(13, 10);
            this.update_info_box.Name = "update_info_box";
            this.update_info_box.Size = new System.Drawing.Size(274, 229);
            this.update_info_box.TabIndex = 9;
            this.update_info_box.TabStop = false;
            this.update_info_box.Text = "版本資訊";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 5;
            // 
            // btn_remindNextTime
            // 
            this.btn_remindNextTime.Enabled = false;
            this.btn_remindNextTime.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_remindNextTime.Location = new System.Drawing.Point(13, 243);
            this.btn_remindNextTime.Margin = new System.Windows.Forms.Padding(2);
            this.btn_remindNextTime.Name = "btn_remindNextTime";
            this.btn_remindNextTime.Size = new System.Drawing.Size(91, 24);
            this.btn_remindNextTime.TabIndex = 11;
            this.btn_remindNextTime.Text = "略過此次更新";
            this.btn_remindNextTime.UseVisualStyleBackColor = true;
            this.btn_remindNextTime.Click += new System.EventHandler(this.btn_remindNextTime_Click);
            // 
            // btn_updateNow
            // 
            this.btn_updateNow.Enabled = false;
            this.btn_updateNow.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_updateNow.Location = new System.Drawing.Point(200, 243);
            this.btn_updateNow.Margin = new System.Windows.Forms.Padding(2);
            this.btn_updateNow.Name = "btn_updateNow";
            this.btn_updateNow.Size = new System.Drawing.Size(87, 24);
            this.btn_updateNow.TabIndex = 10;
            this.btn_updateNow.Text = "立即更新";
            this.btn_updateNow.UseVisualStyleBackColor = true;
            this.btn_updateNow.Click += new System.EventHandler(this.btn_updateNow_Click);
            // 
            // Form_update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 278);
            this.Controls.Add(this.update_info_box);
            this.Controls.Add(this.btn_remindNextTime);
            this.Controls.Add(this.btn_updateNow);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "檢查更新";
            this.Shown += new System.EventHandler(this.updateForm_Shown);
            this.update_info_box.ResumeLayout(false);
            this.update_info_box.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox update_info_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_remindNextTime;
        private System.Windows.Forms.Button btn_updateNow;
    }
}