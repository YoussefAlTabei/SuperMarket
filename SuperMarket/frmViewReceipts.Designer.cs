namespace SuperMarket
{
    partial class frmViewReceipts
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
            this.cbxReceiptNames = new System.Windows.Forms.ComboBox();
            this.btnShowReceipt = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRefund = new System.Windows.Forms.Button();
            this.cbxRefund = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxReceiptNames
            // 
            this.cbxReceiptNames.FormattingEnabled = true;
            this.cbxReceiptNames.Location = new System.Drawing.Point(87, 495);
            this.cbxReceiptNames.Name = "cbxReceiptNames";
            this.cbxReceiptNames.Size = new System.Drawing.Size(272, 24);
            this.cbxReceiptNames.TabIndex = 1;
            this.cbxReceiptNames.SelectedIndexChanged += new System.EventHandler(this.cbxReceiptNames_SelectedIndexChanged);
            // 
            // btnShowReceipt
            // 
            this.btnShowReceipt.Location = new System.Drawing.Point(409, 490);
            this.btnShowReceipt.Name = "btnShowReceipt";
            this.btnShowReceipt.Size = new System.Drawing.Size(108, 29);
            this.btnShowReceipt.TabIndex = 2;
            this.btnShowReceipt.Text = "View Receipt";
            this.btnShowReceipt.UseVisualStyleBackColor = true;
            this.btnShowReceipt.Click += new System.EventHandler(this.btnShowReceipt_Click);
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnBack.Location = new System.Drawing.Point(755, 556);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRefund
            // 
            this.btnRefund.Location = new System.Drawing.Point(409, 550);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(108, 29);
            this.btnRefund.TabIndex = 18;
            this.btnRefund.Text = "Refund Item";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // cbxRefund
            // 
            this.cbxRefund.FormattingEnabled = true;
            this.cbxRefund.Location = new System.Drawing.Point(87, 550);
            this.cbxRefund.Name = "cbxRefund";
            this.cbxRefund.Size = new System.Drawing.Size(272, 24);
            this.cbxRefund.TabIndex = 17;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(553, 490);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 29);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete Receipt";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(683, 402);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // frmViewReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 591);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefund);
            this.Controls.Add(this.cbxRefund);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnShowReceipt);
            this.Controls.Add(this.cbxReceiptNames);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmViewReceipts";
            this.Text = "frmViewReceipts";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxReceiptNames;
        private System.Windows.Forms.Button btnShowReceipt;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.ComboBox cbxRefund;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}