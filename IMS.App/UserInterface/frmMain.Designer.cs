namespace IMS.App.UserInterface
{
    partial class frmMain
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Item = new System.Windows.Forms.ToolStrip();
            this.ts_Item = new System.Windows.Forms.ToolStripDropDownButton();
            this.addItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.addCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.Item.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(136, 662);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1181, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Item
            // 
            this.Item.Dock = System.Windows.Forms.DockStyle.Left;
            this.Item.ImageScalingSize = new System.Drawing.Size(50, 35);
            this.Item.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_Item,
            this.toolStripLabel1,
            this.toolStripSplitButton1,
            this.toolStripLabel2});
            this.Item.Location = new System.Drawing.Point(0, 0);
            this.Item.Name = "Item";
            this.Item.Size = new System.Drawing.Size(136, 684);
            this.Item.TabIndex = 0;
            this.Item.Text = "toolStrip1";
            // 
            // ts_Item
            // 
            this.ts_Item.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_Item.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemsToolStripMenuItem,
            this.listItemToolStripMenuItem,
            this.itemMasterToolStripMenuItem});
            this.ts_Item.Image = global::IMS.App.Properties.Resources.icons8_product_50px;
            this.ts_Item.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_Item.Name = "ts_Item";
            this.ts_Item.Size = new System.Drawing.Size(133, 39);
            this.ts_Item.Text = "Item";
            // 
            // addItemsToolStripMenuItem
            // 
            this.addItemsToolStripMenuItem.Name = "addItemsToolStripMenuItem";
            this.addItemsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.addItemsToolStripMenuItem.Text = "Add Items";
            this.addItemsToolStripMenuItem.Click += new System.EventHandler(this.addItemsToolStripMenuItem_Click);
            // 
            // listItemToolStripMenuItem
            // 
            this.listItemToolStripMenuItem.Name = "listItemToolStripMenuItem";
            this.listItemToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.listItemToolStripMenuItem.Text = "List Item";
            this.listItemToolStripMenuItem.Click += new System.EventHandler(this.listItemToolStripMenuItem_Click);
            // 
            // itemMasterToolStripMenuItem
            // 
            this.itemMasterToolStripMenuItem.Name = "itemMasterToolStripMenuItem";
            this.itemMasterToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.itemMasterToolStripMenuItem.Text = "Main Category";
            this.itemMasterToolStripMenuItem.Click += new System.EventHandler(this.itemMasterToolStripMenuItem_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(133, 20);
            this.toolStripLabel1.Text = "Item";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomerToolStripMenuItem,
            this.listSupplierToolStripMenuItem,
            this.addCustomerToolStripMenuItem1,
            this.listCustomerToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::IMS.App.Properties.Resources.icons8_account_120px_2;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(133, 39);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // addCustomerToolStripMenuItem
            // 
            this.addCustomerToolStripMenuItem.Name = "addCustomerToolStripMenuItem";
            this.addCustomerToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.addCustomerToolStripMenuItem.Text = "Add Supplier";
            this.addCustomerToolStripMenuItem.Click += new System.EventHandler(this.addCustomerToolStripMenuItem_Click);
            // 
            // listSupplierToolStripMenuItem
            // 
            this.listSupplierToolStripMenuItem.Name = "listSupplierToolStripMenuItem";
            this.listSupplierToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.listSupplierToolStripMenuItem.Text = "List Supplier";
            // 
            // addCustomerToolStripMenuItem1
            // 
            this.addCustomerToolStripMenuItem1.Name = "addCustomerToolStripMenuItem1";
            this.addCustomerToolStripMenuItem1.Size = new System.Drawing.Size(179, 26);
            this.addCustomerToolStripMenuItem1.Text = "Add Customer";
            // 
            // listCustomerToolStripMenuItem
            // 
            this.listCustomerToolStripMenuItem.Name = "listCustomerToolStripMenuItem";
            this.listCustomerToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.listCustomerToolStripMenuItem.Text = "List Customer";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(133, 20);
            this.toolStripLabel2.Text = "Supplier & Customer";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 684);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Item);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory System Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Item.ResumeLayout(false);
            this.Item.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        private System.Windows.Forms.StatusStrip statusStrip1;
        #endregion

        private System.Windows.Forms.ToolStrip Item;
        private System.Windows.Forms.ToolStripDropDownButton ts_Item;
        private System.Windows.Forms.ToolStripMenuItem addItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem addCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCustomerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    }
}