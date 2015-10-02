namespace PLMNFCQueuingApp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblDate = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblLongTime = new System.Windows.Forms.Label();
            this.lblStudSmartCardUID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.lblSmartcardStatus = new System.Windows.Forms.Label();
            this.violationCounter = new System.Windows.Forms.Label();
            this.lblPendingViolation = new System.Windows.Forms.Label();
            this.tbRemarks = new System.Windows.Forms.RichTextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(6, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 65);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(12, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(12, 481);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 37);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 732);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(184, 734);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.button1_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDate.Location = new System.Drawing.Point(866, 628);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(323, 30);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Wednesday, September 22, 2010";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lblLongTime
            // 
            this.lblLongTime.AutoSize = true;
            this.lblLongTime.BackColor = System.Drawing.Color.Transparent;
            this.lblLongTime.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLongTime.Location = new System.Drawing.Point(867, 662);
            this.lblLongTime.Name = "lblLongTime";
            this.lblLongTime.Size = new System.Drawing.Size(98, 30);
            this.lblLongTime.TabIndex = 10;
            this.lblLongTime.Text = "DynTime";
            // 
            // lblStudSmartCardUID
            // 
            this.lblStudSmartCardUID.AutoSize = true;
            this.lblStudSmartCardUID.Location = new System.Drawing.Point(10, 740);
            this.lblStudSmartCardUID.Name = "lblStudSmartCardUID";
            this.lblStudSmartCardUID.Size = new System.Drawing.Size(107, 13);
            this.lblStudSmartCardUID.TabIndex = 11;
            this.lblStudSmartCardUID.Text = "lblStudSmartCardUID";
            this.lblStudSmartCardUID.TextChanged += new System.EventHandler(this.lblStudSmartCardUID_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(883, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 327);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // lblSmartcardStatus
            // 
            this.lblSmartcardStatus.AutoSize = true;
            this.lblSmartcardStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblSmartcardStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSmartcardStatus.ForeColor = System.Drawing.Color.Red;
            this.lblSmartcardStatus.Location = new System.Drawing.Point(958, 487);
            this.lblSmartcardStatus.Name = "lblSmartcardStatus";
            this.lblSmartcardStatus.Size = new System.Drawing.Size(148, 21);
            this.lblSmartcardStatus.TabIndex = 13;
            this.lblSmartcardStatus.Text = "lblSmartcardStatus";
            // 
            // violationCounter
            // 
            this.violationCounter.AutoSize = true;
            this.violationCounter.BackColor = System.Drawing.Color.Transparent;
            this.violationCounter.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.violationCounter.Location = new System.Drawing.Point(898, 500);
            this.violationCounter.Name = "violationCounter";
            this.violationCounter.Size = new System.Drawing.Size(34, 40);
            this.violationCounter.TabIndex = 14;
            this.violationCounter.Text = "0";
            // 
            // lblPendingViolation
            // 
            this.lblPendingViolation.AutoSize = true;
            this.lblPendingViolation.BackColor = System.Drawing.Color.Transparent;
            this.lblPendingViolation.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingViolation.Location = new System.Drawing.Point(954, 507);
            this.lblPendingViolation.Name = "lblPendingViolation";
            this.lblPendingViolation.Size = new System.Drawing.Size(219, 30);
            this.lblPendingViolation.TabIndex = 15;
            this.lblPendingViolation.Text = "Unsettled Violation(s)";
            // 
            // tbRemarks
            // 
            this.tbRemarks.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.tbRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbRemarks.DetectUrls = false;
            this.tbRemarks.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRemarks.ForeColor = System.Drawing.SystemColors.Info;
            this.tbRemarks.HideSelection = false;
            this.tbRemarks.Location = new System.Drawing.Point(64, 626);
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.ReadOnly = true;
            this.tbRemarks.Size = new System.Drawing.Size(612, 79);
            this.tbRemarks.TabIndex = 16;
            this.tbRemarks.Text = "";
            this.tbRemarks.TextChanged += new System.EventHandler(this.tbRemarks_TextChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblFrom.Location = new System.Drawing.Point(390, 596);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(87, 30);
            this.lblFrom.TabIndex = 17;
            this.lblFrom.Text = "lblFrom";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PLMNFCQueuingApp.Properties.Resources.PLM_Queuing_Interface_v9;
            this.ClientSize = new System.Drawing.Size(1264, 719);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.tbRemarks);
            this.Controls.Add(this.lblPendingViolation);
            this.Controls.Add(this.violationCounter);
            this.Controls.Add(this.lblSmartcardStatus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblStudSmartCardUID);
            this.Controls.Add(this.lblLongTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1280, 768);
            this.MinimumSize = new System.Drawing.Size(1280, 726);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLM NFC Identification System - Student Queuing Module";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblLongTime;
        private System.Windows.Forms.Label lblStudSmartCardUID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label lblSmartcardStatus;
        private System.Windows.Forms.Label violationCounter;
        private System.Windows.Forms.Label lblPendingViolation;
        private System.Windows.Forms.RichTextBox tbRemarks;
        private System.Windows.Forms.Label lblFrom;
    }
}