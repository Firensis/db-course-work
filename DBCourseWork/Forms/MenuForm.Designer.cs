namespace DBCourseWork.Forms
{
    partial class MenuForm
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
            this.b_tables = new System.Windows.Forms.Button();
            this.b_userManagement = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.b_createReport = new System.Windows.Forms.Button();
            this.sfd_saveReport = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // b_tables
            // 
            this.b_tables.Location = new System.Drawing.Point(29, 12);
            this.b_tables.Name = "b_tables";
            this.b_tables.Size = new System.Drawing.Size(200, 23);
            this.b_tables.TabIndex = 0;
            this.b_tables.Text = "Выборки данных";
            this.b_tables.UseVisualStyleBackColor = true;
            this.b_tables.Click += new System.EventHandler(this.B_tables_Click);
            // 
            // b_userManagement
            // 
            this.b_userManagement.Location = new System.Drawing.Point(29, 100);
            this.b_userManagement.Name = "b_userManagement";
            this.b_userManagement.Size = new System.Drawing.Size(200, 23);
            this.b_userManagement.TabIndex = 2;
            this.b_userManagement.Text = "Создание/удаление пользователей";
            this.b_userManagement.UseVisualStyleBackColor = true;
            this.b_userManagement.Click += new System.EventHandler(this.B_createUser_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(29, 174);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Выход";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Выдача справки о неисправностях";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // b_createReport
            // 
            this.b_createReport.Location = new System.Drawing.Point(29, 71);
            this.b_createReport.Name = "b_createReport";
            this.b_createReport.Size = new System.Drawing.Size(200, 23);
            this.b_createReport.TabIndex = 5;
            this.b_createReport.Text = "Создать отчёт о работе станции";
            this.b_createReport.UseVisualStyleBackColor = true;
            this.b_createReport.Click += new System.EventHandler(this.B_createReport_Click);
            // 
            // sfd_saveReport
            // 
            this.sfd_saveReport.DefaultExt = "docx";
            this.sfd_saveReport.Filter = "Документы|*.docx|Все файлы|*.*";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 209);
            this.Controls.Add(this.b_createReport);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.b_userManagement);
            this.Controls.Add(this.b_tables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_tables;
        private System.Windows.Forms.Button b_userManagement;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button b_createReport;
        private System.Windows.Forms.SaveFileDialog sfd_saveReport;
    }
}