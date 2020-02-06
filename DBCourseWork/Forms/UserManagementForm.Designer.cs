namespace DBCourseWork.Forms
{
    partial class UserManagementForm
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
            this.gb_userCreate = new System.Windows.Forms.GroupBox();
            this.cb_roleSelect = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.b_addUser = new System.Windows.Forms.Button();
            this.tb_userPassword = new System.Windows.Forms.TextBox();
            this.tb_userId = new System.Windows.Forms.TextBox();
            this.p_addToWorker = new System.Windows.Forms.Panel();
            this.cb_addToWorker = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_userDelete = new System.Windows.Forms.GroupBox();
            this.b_deleteUser = new System.Windows.Forms.Button();
            this.cb_userNames = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gb_userCreate.SuspendLayout();
            this.gb_userDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_userCreate
            // 
            this.gb_userCreate.AutoSize = true;
            this.gb_userCreate.Controls.Add(this.cb_roleSelect);
            this.gb_userCreate.Controls.Add(this.label3);
            this.gb_userCreate.Controls.Add(this.b_addUser);
            this.gb_userCreate.Controls.Add(this.tb_userPassword);
            this.gb_userCreate.Controls.Add(this.tb_userId);
            this.gb_userCreate.Controls.Add(this.p_addToWorker);
            this.gb_userCreate.Controls.Add(this.cb_addToWorker);
            this.gb_userCreate.Controls.Add(this.label2);
            this.gb_userCreate.Controls.Add(this.label1);
            this.gb_userCreate.Location = new System.Drawing.Point(27, 12);
            this.gb_userCreate.Name = "gb_userCreate";
            this.gb_userCreate.Size = new System.Drawing.Size(233, 302);
            this.gb_userCreate.TabIndex = 0;
            this.gb_userCreate.TabStop = false;
            this.gb_userCreate.Text = "Добавление пользователей";
            // 
            // cb_roleSelect
            // 
            this.cb_roleSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_roleSelect.FormattingEnabled = true;
            this.cb_roleSelect.Location = new System.Drawing.Point(102, 72);
            this.cb_roleSelect.Name = "cb_roleSelect";
            this.cb_roleSelect.Size = new System.Drawing.Size(115, 21);
            this.cb_roleSelect.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Роль:";
            // 
            // b_addUser
            // 
            this.b_addUser.Location = new System.Drawing.Point(77, 260);
            this.b_addUser.Name = "b_addUser";
            this.b_addUser.Size = new System.Drawing.Size(75, 23);
            this.b_addUser.TabIndex = 6;
            this.b_addUser.Text = "Добавить";
            this.b_addUser.UseVisualStyleBackColor = true;
            this.b_addUser.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tb_userPassword
            // 
            this.tb_userPassword.Location = new System.Drawing.Point(102, 48);
            this.tb_userPassword.Name = "tb_userPassword";
            this.tb_userPassword.Size = new System.Drawing.Size(115, 20);
            this.tb_userPassword.TabIndex = 5;
            // 
            // tb_userId
            // 
            this.tb_userId.Location = new System.Drawing.Point(102, 22);
            this.tb_userId.Name = "tb_userId";
            this.tb_userId.Size = new System.Drawing.Size(115, 20);
            this.tb_userId.TabIndex = 4;
            this.tb_userId.TextChanged += new System.EventHandler(this.tb_userId_TextChanged);
            // 
            // p_addToWorker
            // 
            this.p_addToWorker.AutoSize = true;
            this.p_addToWorker.Enabled = false;
            this.p_addToWorker.Location = new System.Drawing.Point(9, 136);
            this.p_addToWorker.Name = "p_addToWorker";
            this.p_addToWorker.Size = new System.Drawing.Size(208, 118);
            this.p_addToWorker.TabIndex = 3;
            // 
            // cb_addToWorker
            // 
            this.cb_addToWorker.AutoSize = true;
            this.cb_addToWorker.Location = new System.Drawing.Point(9, 113);
            this.cb_addToWorker.Name = "cb_addToWorker";
            this.cb_addToWorker.Size = new System.Drawing.Size(191, 17);
            this.cb_addToWorker.TabIndex = 2;
            this.cb_addToWorker.Text = "добавить в таблицу \"Сотрудник\"";
            this.cb_addToWorker.UseVisualStyleBackColor = true;
            this.cb_addToWorker.CheckedChanged += new System.EventHandler(this.Cb_addToWorker_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Идентификатор:";
            // 
            // gb_userDelete
            // 
            this.gb_userDelete.Controls.Add(this.b_deleteUser);
            this.gb_userDelete.Controls.Add(this.cb_userNames);
            this.gb_userDelete.Controls.Add(this.label7);
            this.gb_userDelete.Location = new System.Drawing.Point(266, 12);
            this.gb_userDelete.Name = "gb_userDelete";
            this.gb_userDelete.Size = new System.Drawing.Size(233, 85);
            this.gb_userDelete.TabIndex = 1;
            this.gb_userDelete.TabStop = false;
            this.gb_userDelete.Text = "Удаление пользователей";
            // 
            // b_deleteUser
            // 
            this.b_deleteUser.Location = new System.Drawing.Point(77, 56);
            this.b_deleteUser.Name = "b_deleteUser";
            this.b_deleteUser.Size = new System.Drawing.Size(75, 23);
            this.b_deleteUser.TabIndex = 2;
            this.b_deleteUser.Text = "Удалить";
            this.b_deleteUser.UseVisualStyleBackColor = true;
            this.b_deleteUser.Click += new System.EventHandler(this.Button2_Click);
            // 
            // cb_userNames
            // 
            this.cb_userNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_userNames.FormattingEnabled = true;
            this.cb_userNames.Location = new System.Drawing.Point(102, 24);
            this.cb_userNames.Name = "cb_userNames";
            this.cb_userNames.Size = new System.Drawing.Size(115, 21);
            this.cb_userNames.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Идентификатор:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Вернуться в меню";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(509, 425);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gb_userDelete);
            this.Controls.Add(this.gb_userCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователи";
            this.gb_userCreate.ResumeLayout(false);
            this.gb_userCreate.PerformLayout();
            this.gb_userDelete.ResumeLayout(false);
            this.gb_userDelete.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_userCreate;
        private System.Windows.Forms.Button b_addUser;
        private System.Windows.Forms.TextBox tb_userPassword;
        private System.Windows.Forms.TextBox tb_userId;
        private System.Windows.Forms.Panel p_addToWorker;
        private System.Windows.Forms.CheckBox cb_addToWorker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_userDelete;
        private System.Windows.Forms.Button b_deleteUser;
        private System.Windows.Forms.ComboBox cb_userNames;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_roleSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}