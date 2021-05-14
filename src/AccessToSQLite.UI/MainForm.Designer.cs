namespace AccessToSQLite.UI
{
    partial class MainForm
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
            this.grpImport = new System.Windows.Forms.GroupBox();
            this.txtAccessPassword = new System.Windows.Forms.TextBox();
            this.btnAccessSelect = new System.Windows.Forms.Button();
            this.txtAccessFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.rtxLogs = new System.Windows.Forms.RichTextBox();
            this.grpExport = new System.Windows.Forms.GroupBox();
            this.txtSQLiteFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSQLiteSelect = new System.Windows.Forms.Button();
            this.grpImport.SuspendLayout();
            this.grpExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpImport
            // 
            this.grpImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImport.Controls.Add(this.txtAccessPassword);
            this.grpImport.Controls.Add(this.btnAccessSelect);
            this.grpImport.Controls.Add(this.txtAccessFileName);
            this.grpImport.Controls.Add(this.label2);
            this.grpImport.Controls.Add(this.label1);
            this.grpImport.Location = new System.Drawing.Point(13, 13);
            this.grpImport.Name = "grpImport";
            this.grpImport.Size = new System.Drawing.Size(375, 85);
            this.grpImport.TabIndex = 0;
            this.grpImport.TabStop = false;
            this.grpImport.Text = "Access Import";
            // 
            // txtAccessPassword
            // 
            this.txtAccessPassword.Location = new System.Drawing.Point(67, 51);
            this.txtAccessPassword.Name = "txtAccessPassword";
            this.txtAccessPassword.PasswordChar = '*';
            this.txtAccessPassword.Size = new System.Drawing.Size(176, 22);
            this.txtAccessPassword.TabIndex = 3;
            this.txtAccessPassword.TextChanged += new System.EventHandler(this.TxtAccessPassword_TextChanged);
            // 
            // btnAccessSelect
            // 
            this.btnAccessSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccessSelect.Location = new System.Drawing.Point(341, 21);
            this.btnAccessSelect.Name = "btnAccessSelect";
            this.btnAccessSelect.Size = new System.Drawing.Size(28, 23);
            this.btnAccessSelect.TabIndex = 2;
            this.btnAccessSelect.Text = "...";
            this.btnAccessSelect.UseVisualStyleBackColor = true;
            this.btnAccessSelect.Click += new System.EventHandler(this.BtnAccessSelect_Click);
            // 
            // txtAccessFileName
            // 
            this.txtAccessFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccessFileName.Location = new System.Drawing.Point(67, 23);
            this.txtAccessFileName.Name = "txtAccessFileName";
            this.txtAccessFileName.ReadOnly = true;
            this.txtAccessFileName.Size = new System.Drawing.Size(268, 22);
            this.txtAccessFileName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FileName";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(331, 162);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(57, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // rtxLogs
            // 
            this.rtxLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxLogs.BackColor = System.Drawing.SystemColors.Info;
            this.rtxLogs.Location = new System.Drawing.Point(13, 191);
            this.rtxLogs.Name = "rtxLogs";
            this.rtxLogs.ReadOnly = true;
            this.rtxLogs.Size = new System.Drawing.Size(375, 205);
            this.rtxLogs.TabIndex = 3;
            this.rtxLogs.Text = "";
            // 
            // grpExport
            // 
            this.grpExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpExport.Controls.Add(this.txtSQLiteFileName);
            this.grpExport.Controls.Add(this.label3);
            this.grpExport.Controls.Add(this.btnSQLiteSelect);
            this.grpExport.Location = new System.Drawing.Point(13, 105);
            this.grpExport.Name = "grpExport";
            this.grpExport.Size = new System.Drawing.Size(375, 51);
            this.grpExport.TabIndex = 1;
            this.grpExport.TabStop = false;
            this.grpExport.Text = "SQLite Export";
            // 
            // txtSQLiteFileName
            // 
            this.txtSQLiteFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSQLiteFileName.Location = new System.Drawing.Point(67, 21);
            this.txtSQLiteFileName.Name = "txtSQLiteFileName";
            this.txtSQLiteFileName.ReadOnly = true;
            this.txtSQLiteFileName.Size = new System.Drawing.Size(268, 22);
            this.txtSQLiteFileName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "FileName";
            // 
            // btnSQLiteSelect
            // 
            this.btnSQLiteSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSQLiteSelect.Location = new System.Drawing.Point(341, 19);
            this.btnSQLiteSelect.Name = "btnSQLiteSelect";
            this.btnSQLiteSelect.Size = new System.Drawing.Size(28, 23);
            this.btnSQLiteSelect.TabIndex = 2;
            this.btnSQLiteSelect.Text = "...";
            this.btnSQLiteSelect.UseVisualStyleBackColor = true;
            this.btnSQLiteSelect.Click += new System.EventHandler(this.BtnSQLiteSelect_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 408);
            this.Controls.Add(this.grpExport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.rtxLogs);
            this.Controls.Add(this.grpImport);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccessToSQLite";
            this.grpImport.ResumeLayout(false);
            this.grpImport.PerformLayout();
            this.grpExport.ResumeLayout(false);
            this.grpExport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpImport;
        private System.Windows.Forms.Button btnAccessSelect;
        private System.Windows.Forms.TextBox txtAccessFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.RichTextBox rtxLogs;
        private System.Windows.Forms.TextBox txtAccessPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpExport;
        private System.Windows.Forms.TextBox txtSQLiteFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSQLiteSelect;
    }
}

