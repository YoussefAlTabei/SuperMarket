namespace SuperMarket
{
    partial class frmManagerView
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
            this.btnViewEmp = new System.Windows.Forms.Button();
            this.btnViewReceipts = new System.Windows.Forms.Button();
            this.btnViewStatistics = new System.Windows.Forms.Button();
            this.btnViewData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnViewEmp
            // 
            this.btnViewEmp.Location = new System.Drawing.Point(54, 169);
            this.btnViewEmp.Name = "btnViewEmp";
            this.btnViewEmp.Size = new System.Drawing.Size(128, 112);
            this.btnViewEmp.TabIndex = 1;
            this.btnViewEmp.Text = "View Employees";
            this.btnViewEmp.UseVisualStyleBackColor = true;
            this.btnViewEmp.Click += new System.EventHandler(this.btnViewEmp_Click);
            // 
            // btnViewReceipts
            // 
            this.btnViewReceipts.Location = new System.Drawing.Point(218, 169);
            this.btnViewReceipts.Name = "btnViewReceipts";
            this.btnViewReceipts.Size = new System.Drawing.Size(128, 112);
            this.btnViewReceipts.TabIndex = 2;
            this.btnViewReceipts.Text = "View Receipts";
            this.btnViewReceipts.UseVisualStyleBackColor = true;
            this.btnViewReceipts.Click += new System.EventHandler(this.btnViewReceipts_Click);
            // 
            // btnViewStatistics
            // 
            this.btnViewStatistics.Location = new System.Drawing.Point(384, 169);
            this.btnViewStatistics.Name = "btnViewStatistics";
            this.btnViewStatistics.Size = new System.Drawing.Size(128, 112);
            this.btnViewStatistics.TabIndex = 3;
            this.btnViewStatistics.Text = "View Statistics";
            this.btnViewStatistics.UseVisualStyleBackColor = true;
            this.btnViewStatistics.Click += new System.EventHandler(this.btnViewStatistics_Click);
            // 
            // btnViewData
            // 
            this.btnViewData.Location = new System.Drawing.Point(549, 169);
            this.btnViewData.Name = "btnViewData";
            this.btnViewData.Size = new System.Drawing.Size(128, 112);
            this.btnViewData.TabIndex = 4;
            this.btnViewData.Text = "View DataBase";
            this.btnViewData.UseVisualStyleBackColor = true;
            this.btnViewData.Click += new System.EventHandler(this.btnViewData_Click);
            // 
            // frmManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnViewData);
            this.Controls.Add(this.btnViewStatistics);
            this.Controls.Add(this.btnViewReceipts);
            this.Controls.Add(this.btnViewEmp);
            this.Name = "frmManagerView";
            this.Text = "frmManagerView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewEmp;
        private System.Windows.Forms.Button btnViewReceipts;
        private System.Windows.Forms.Button btnViewStatistics;
        private System.Windows.Forms.Button btnViewData;
    }
}