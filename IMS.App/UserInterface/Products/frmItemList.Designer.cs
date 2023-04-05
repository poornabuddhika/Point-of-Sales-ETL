namespace IMS.App.UserInterface.Products
{
    partial class frmItemList
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
            this.lblinc = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.btnlast = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnprev = new System.Windows.Forms.Button();
            this.btnfirst = new System.Windows.Forms.Button();
            this.lblmax = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.GridViewItem = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblinc
            // 
            this.lblinc.AutoSize = true;
            this.lblinc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinc.Location = new System.Drawing.Point(526, 90);
            this.lblinc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblinc.Name = "lblinc";
            this.lblinc.Size = new System.Drawing.Size(19, 20);
            this.lblinc.TabIndex = 75;
            this.lblinc.Text = "1";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(555, 90);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(25, 20);
            this.Label9.TabIndex = 70;
            this.Label9.Text = "of";
            // 
            // btnlast
            // 
            this.btnlast.BackColor = System.Drawing.Color.Transparent;
            this.btnlast.ForeColor = System.Drawing.Color.Black;
            this.btnlast.Location = new System.Drawing.Point(803, 83);
            this.btnlast.Margin = new System.Windows.Forms.Padding(4);
            this.btnlast.Name = "btnlast";
            this.btnlast.Size = new System.Drawing.Size(52, 37);
            this.btnlast.TabIndex = 71;
            this.btnlast.Text = ">>";
            this.btnlast.UseVisualStyleBackColor = false;
            // 
            // btnnext
            // 
            this.btnnext.BackColor = System.Drawing.Color.Transparent;
            this.btnnext.ForeColor = System.Drawing.Color.Black;
            this.btnnext.Location = new System.Drawing.Point(739, 83);
            this.btnnext.Margin = new System.Windows.Forms.Padding(4);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(52, 37);
            this.btnnext.TabIndex = 72;
            this.btnnext.Text = ">";
            this.btnnext.UseVisualStyleBackColor = false;
            // 
            // btnprev
            // 
            this.btnprev.BackColor = System.Drawing.Color.Transparent;
            this.btnprev.ForeColor = System.Drawing.Color.Black;
            this.btnprev.Location = new System.Drawing.Point(678, 83);
            this.btnprev.Margin = new System.Windows.Forms.Padding(4);
            this.btnprev.Name = "btnprev";
            this.btnprev.Size = new System.Drawing.Size(52, 37);
            this.btnprev.TabIndex = 73;
            this.btnprev.Text = "<";
            this.btnprev.UseVisualStyleBackColor = false;
            // 
            // btnfirst
            // 
            this.btnfirst.BackColor = System.Drawing.Color.Transparent;
            this.btnfirst.ForeColor = System.Drawing.Color.Black;
            this.btnfirst.Location = new System.Drawing.Point(618, 83);
            this.btnfirst.Margin = new System.Windows.Forms.Padding(4);
            this.btnfirst.Name = "btnfirst";
            this.btnfirst.Size = new System.Drawing.Size(52, 37);
            this.btnfirst.TabIndex = 74;
            this.btnfirst.Text = "<<";
            this.btnfirst.UseVisualStyleBackColor = false;
            // 
            // lblmax
            // 
            this.lblmax.AutoSize = true;
            this.lblmax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmax.Location = new System.Drawing.Point(591, 90);
            this.lblmax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblmax.Name = "lblmax";
            this.lblmax.Size = new System.Drawing.Size(19, 20);
            this.lblmax.TabIndex = 76;
            this.lblmax.Text = "1";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(352, 37);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(61, 17);
            this.Label6.TabIndex = 69;
            this.Label6.Text = "Search :";
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(421, 32);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(349, 22);
            this.txtsearch.TabIndex = 68;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // GridViewItem
            // 
            this.GridViewItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewItem.Location = new System.Drawing.Point(11, 127);
            this.GridViewItem.Name = "GridViewItem";
            this.GridViewItem.RowTemplate.Height = 24;
            this.GridViewItem.Size = new System.Drawing.Size(1289, 703);
            this.GridViewItem.TabIndex = 77;
            // 
            // frmItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 836);
            this.Controls.Add(this.GridViewItem);
            this.Controls.Add(this.lblinc);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.btnlast);
            this.Controls.Add(this.btnnext);
            this.Controls.Add(this.btnprev);
            this.Controls.Add(this.btnfirst);
            this.Controls.Add(this.lblmax);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtsearch);
            this.Name = "frmItemList";
            this.Text = "frmItemList";
            this.Load += new System.EventHandler(this.frmItemList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblinc;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Button btnlast;
        internal System.Windows.Forms.Button btnnext;
        internal System.Windows.Forms.Button btnprev;
        internal System.Windows.Forms.Button btnfirst;
        internal System.Windows.Forms.Label lblmax;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.DataGridView GridViewItem;
    }
}