namespace IMS.App
{
    partial class GRNPopUP
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
            this.dataGridViewGrn = new System.Windows.Forms.DataGridView();
            this.textBoxGINSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrn)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewGrn
            // 
            this.dataGridViewGrn.AllowDrop = true;
            this.dataGridViewGrn.AllowUserToOrderColumns = true;
            this.dataGridViewGrn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewGrn.Location = new System.Drawing.Point(12, 41);
            this.dataGridViewGrn.Name = "dataGridViewGrn";
            this.dataGridViewGrn.ReadOnly = true;
            this.dataGridViewGrn.RowTemplate.Height = 24;
            this.dataGridViewGrn.Size = new System.Drawing.Size(715, 452);
            this.dataGridViewGrn.TabIndex = 0;
            // 
            // textBoxGINSearch
            // 
            this.textBoxGINSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGINSearch.Location = new System.Drawing.Point(195, 5);
            this.textBoxGINSearch.Name = "textBoxGINSearch";
            this.textBoxGINSearch.Size = new System.Drawing.Size(203, 34);
            this.textBoxGINSearch.TabIndex = 1;
            this.textBoxGINSearch.TextChanged += new System.EventHandler(this.textBoxGINSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search";
            // 
            // GRNPopUP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(747, 505);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxGINSearch);
            this.Controls.Add(this.dataGridViewGrn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GRNPopUP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GRNPopUP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGrn;
        private System.Windows.Forms.TextBox textBoxGINSearch;
        private System.Windows.Forms.Label label1;
    }
}