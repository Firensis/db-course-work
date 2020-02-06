namespace DBCourseWork.Forms
{
    partial class TableForm
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
            this.cb_table = new System.Windows.Forms.ComboBox();
            this.dg_tableView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_addItem = new System.Windows.Forms.GroupBox();
            this.gb_changeItem = new System.Windows.Forms.GroupBox();
            this.gb_deleteItem = new System.Windows.Forms.GroupBox();
            this.cb_filter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_filterValue = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.l_rowsCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_tableView)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_table
            // 
            this.cb_table.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_table.FormattingEnabled = true;
            this.cb_table.Location = new System.Drawing.Point(142, 17);
            this.cb_table.Name = "cb_table";
            this.cb_table.Size = new System.Drawing.Size(507, 21);
            this.cb_table.TabIndex = 0;
            this.cb_table.SelectedIndexChanged += new System.EventHandler(this.Cb_table_SelectedIndexChanged);
            // 
            // dg_tableView
            // 
            this.dg_tableView.AllowUserToAddRows = false;
            this.dg_tableView.AllowUserToDeleteRows = false;
            this.dg_tableView.AllowUserToResizeRows = false;
            this.dg_tableView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_tableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_tableView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dg_tableView.Location = new System.Drawing.Point(16, 107);
            this.dg_tableView.Name = "dg_tableView";
            this.dg_tableView.RowHeadersVisible = false;
            this.dg_tableView.Size = new System.Drawing.Size(633, 221);
            this.dg_tableView.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбор представления:";
            // 
            // gb_addItem
            // 
            this.gb_addItem.AutoSize = true;
            this.gb_addItem.Location = new System.Drawing.Point(13, 334);
            this.gb_addItem.Name = "gb_addItem";
            this.gb_addItem.Size = new System.Drawing.Size(171, 87);
            this.gb_addItem.TabIndex = 3;
            this.gb_addItem.TabStop = false;
            this.gb_addItem.Text = "Добавление элемента";
            // 
            // gb_changeItem
            // 
            this.gb_changeItem.AutoSize = true;
            this.gb_changeItem.Location = new System.Drawing.Point(221, 334);
            this.gb_changeItem.Name = "gb_changeItem";
            this.gb_changeItem.Size = new System.Drawing.Size(171, 82);
            this.gb_changeItem.TabIndex = 4;
            this.gb_changeItem.TabStop = false;
            this.gb_changeItem.Text = "Изменение элемента";
            // 
            // gb_deleteItem
            // 
            this.gb_deleteItem.AutoSize = true;
            this.gb_deleteItem.Location = new System.Drawing.Point(478, 334);
            this.gb_deleteItem.Name = "gb_deleteItem";
            this.gb_deleteItem.Size = new System.Drawing.Size(171, 82);
            this.gb_deleteItem.TabIndex = 5;
            this.gb_deleteItem.TabStop = false;
            this.gb_deleteItem.Text = "Удаление элемента";
            // 
            // cb_filter
            // 
            this.cb_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_filter.FormattingEnabled = true;
            this.cb_filter.Location = new System.Drawing.Point(69, 49);
            this.cb_filter.Name = "cb_filter";
            this.cb_filter.Size = new System.Drawing.Size(160, 21);
            this.cb_filter.TabIndex = 6;
            this.cb_filter.SelectedIndexChanged += new System.EventHandler(this.cb_filter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Фильтр:";
            // 
            // tb_filterValue
            // 
            this.tb_filterValue.Location = new System.Drawing.Point(235, 49);
            this.tb_filterValue.Name = "tb_filterValue";
            this.tb_filterValue.Size = new System.Drawing.Size(178, 20);
            this.tb_filterValue.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(419, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Отобразить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(547, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Выход в меню";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // l_rowsCount
            // 
            this.l_rowsCount.AutoSize = true;
            this.l_rowsCount.Location = new System.Drawing.Point(12, 80);
            this.l_rowsCount.Name = "l_rowsCount";
            this.l_rowsCount.Size = new System.Drawing.Size(0, 13);
            this.l_rowsCount.TabIndex = 11;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(670, 430);
            this.Controls.Add(this.l_rowsCount);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_filterValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_filter);
            this.Controls.Add(this.gb_deleteItem);
            this.Controls.Add(this.gb_changeItem);
            this.Controls.Add(this.gb_addItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dg_tableView);
            this.Controls.Add(this.cb_table);
            this.MaximizeBox = false;
            this.Name = "TableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Данные таблиц";
            ((System.ComponentModel.ISupportInitialize)(this.dg_tableView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_table;
        private System.Windows.Forms.DataGridView dg_tableView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_addItem;
        private System.Windows.Forms.GroupBox gb_changeItem;
        private System.Windows.Forms.GroupBox gb_deleteItem;
        private System.Windows.Forms.ComboBox cb_filter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_filterValue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label l_rowsCount;
    }
}