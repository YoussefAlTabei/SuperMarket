namespace SuperMarket
{
    partial class frmCashier
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
            this.txtBarcodeSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblReceit = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.btnRemoveLast = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.cbxItemToRemove = new System.Windows.Forms.ComboBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModifyQt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBarcodeSearch
            // 
            this.txtBarcodeSearch.Location = new System.Drawing.Point(85, 390);
            this.txtBarcodeSearch.Name = "txtBarcodeSearch";
            this.txtBarcodeSearch.Size = new System.Drawing.Size(169, 22);
            this.txtBarcodeSearch.TabIndex = 0;
            this.txtBarcodeSearch.TextChanged += new System.EventHandler(this.txtBarcodeSearch_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(305, 389);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add item";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblReceit
            // 
            this.lblReceit.AutoSize = true;
            this.lblReceit.Location = new System.Drawing.Point(84, 33);
            this.lblReceit.Name = "lblReceit";
            this.lblReceit.Size = new System.Drawing.Size(0, 16);
            this.lblReceit.TabIndex = 2;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(82, 308);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 16);
            this.lblTotal.TabIndex = 3;
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.Location = new System.Drawing.Point(453, 415);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(91, 69);
            this.btnPrintReceipt.TabIndex = 4;
            this.btnPrintReceipt.Text = "Print receit";
            this.btnPrintReceipt.UseVisualStyleBackColor = true;
            this.btnPrintReceipt.Click += new System.EventHandler(this.btnReciet_Click);
            // 
            // btnRemoveLast
            // 
            this.btnRemoveLast.Location = new System.Drawing.Point(255, 520);
            this.btnRemoveLast.Name = "btnRemoveLast";
            this.btnRemoveLast.Size = new System.Drawing.Size(130, 23);
            this.btnRemoveLast.TabIndex = 5;
            this.btnRemoveLast.Text = "Remove last item";
            this.btnRemoveLast.UseVisualStyleBackColor = true;
            this.btnRemoveLast.Click += new System.EventHandler(this.btnRemoveLast_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(255, 479);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(113, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove item";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // cbxItemToRemove
            // 
            this.cbxItemToRemove.FormattingEnabled = true;
            this.cbxItemToRemove.Location = new System.Drawing.Point(103, 479);
            this.cbxItemToRemove.Name = "cbxItemToRemove";
            this.cbxItemToRemove.Size = new System.Drawing.Size(121, 24);
            this.cbxItemToRemove.TabIndex = 7;
            this.cbxItemToRemove.SelectedIndexChanged += new System.EventHandler(this.cbxItemToRemove_SelectedIndexChanged);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(769, 519);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(32, 13);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(0, 16);
            this.lblWelcome.TabIndex = 9;
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Location = new System.Drawing.Point(705, 390);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(68, 22);
            this.txtPaidAmount.TabIndex = 10;
            this.txtPaidAmount.TextChanged += new System.EventHandler(this.txtPaidAmount_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Paid amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 431);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Modify Quantity:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtModifyQt
            // 
            this.txtModifyQt.Location = new System.Drawing.Point(191, 428);
            this.txtModifyQt.Name = "txtModifyQt";
            this.txtModifyQt.Size = new System.Drawing.Size(63, 22);
            this.txtModifyQt.TabIndex = 14;
            this.txtModifyQt.TextChanged += new System.EventHandler(this.txtModifyQt_TextChanged);
            // 
            // frmCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 554);
            this.Controls.Add(this.txtModifyQt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPaidAmount);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.cbxItemToRemove);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnRemoveLast);
            this.Controls.Add(this.btnPrintReceipt);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblReceit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtBarcodeSearch);
            this.Name = "frmCashier";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBarcodeSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblReceit;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.Button btnRemoveLast;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ComboBox cbxItemToRemove;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModifyQt;
    }
}

