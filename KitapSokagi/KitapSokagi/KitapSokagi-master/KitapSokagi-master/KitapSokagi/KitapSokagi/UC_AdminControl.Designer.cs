namespace KitapSokagi
{
    partial class UC_AdminControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_AdminControl));
            this.pnlAdminProducts = new System.Windows.Forms.Panel();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.btnAdminBook = new System.Windows.Forms.Button();
            this.pnladminContainer = new System.Windows.Forms.Panel();
            this.pnlAdminProducts.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAdminProducts
            // 
            this.pnlAdminProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(126)))), ((int)(((byte)(139)))));
            this.pnlAdminProducts.Controls.Add(this.btnCustomers);
            this.pnlAdminProducts.Controls.Add(this.lblAdmin);
            this.pnlAdminProducts.Controls.Add(this.btnAdminBook);
            this.pnlAdminProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAdminProducts.Location = new System.Drawing.Point(0, 0);
            this.pnlAdminProducts.Name = "pnlAdminProducts";
            this.pnlAdminProducts.Size = new System.Drawing.Size(948, 101);
            this.pnlAdminProducts.TabIndex = 0;
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackgroundImage = global::KitapSokagi.Properties.Resources.user;
            this.btnCustomers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCustomers.Location = new System.Drawing.Point(601, 36);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(59, 59);
            this.btnCustomers.TabIndex = 5;
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAdmin.Location = new System.Drawing.Point(434, 9);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(154, 24);
            this.lblAdmin.TabIndex = 4;
            this.lblAdmin.Text = "YÖNETİCİ EKRANI";
            // 
            // btnAdminBook
            // 
            this.btnAdminBook.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdminBook.BackgroundImage")));
            this.btnAdminBook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdminBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdminBook.Location = new System.Drawing.Point(307, 36);
            this.btnAdminBook.Name = "btnAdminBook";
            this.btnAdminBook.Size = new System.Drawing.Size(59, 59);
            this.btnAdminBook.TabIndex = 1;
            this.btnAdminBook.UseVisualStyleBackColor = true;
            this.btnAdminBook.Click += new System.EventHandler(this.btnAdminBook_Click);
            // 
            // pnladminContainer
            // 
            this.pnladminContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnladminContainer.Location = new System.Drawing.Point(0, 101);
            this.pnladminContainer.Name = "pnladminContainer";
            this.pnladminContainer.Size = new System.Drawing.Size(948, 574);
            this.pnladminContainer.TabIndex = 1;
            // 
            // UC_AdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnladminContainer);
            this.Controls.Add(this.pnlAdminProducts);
            this.Name = "UC_AdminControl";
            this.Size = new System.Drawing.Size(948, 675);
            this.pnlAdminProducts.ResumeLayout(false);
            this.pnlAdminProducts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAdminProducts;
        private System.Windows.Forms.Button btnAdminBook;
        private System.Windows.Forms.Panel pnladminContainer;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Button btnCustomers;
    }
}
