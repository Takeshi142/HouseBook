namespace HouseKeepBook
{
    partial class ItemForm
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
            this.components = new System.ComponentModel.Container();
            this.monCalendar = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.categoryDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryDataSet = new HouseKeepBook.CategoryDataSet();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCansel = new System.Windows.Forms.Button();
            this.mtxtMoney = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // monCalendar
            // 
            this.monCalendar.Location = new System.Drawing.Point(7, 8);
            this.monCalendar.Name = "monCalendar";
            this.monCalendar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "分類";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "品名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "金額";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "備考";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DataSource = this.categoryDataTableBindingSource;
            this.cmbCategory.DisplayMember = "分類";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(259, 30);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(100, 20);
            this.cmbCategory.TabIndex = 2;
            // 
            // categoryDataTableBindingSource
            // 
            this.categoryDataTableBindingSource.DataMember = "CategoryDataTable";
            this.categoryDataTableBindingSource.DataSource = this.categoryDataSet;
            // 
            // categoryDataSet
            // 
            this.categoryDataSet.DataSetName = "CategoryDataSet";
            this.categoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(262, 65);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(100, 19);
            this.txtItem.TabIndex = 3;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(262, 135);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(100, 19);
            this.txtRemarks.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(55, 182);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "登録";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCansel
            // 
            this.buttonCansel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCansel.Location = new System.Drawing.Point(262, 182);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(75, 23);
            this.buttonCansel.TabIndex = 4;
            this.buttonCansel.Text = "キャンセル";
            this.buttonCansel.UseVisualStyleBackColor = true;
            // 
            // mtxtMoney
            // 
            this.mtxtMoney.Location = new System.Drawing.Point(262, 100);
            this.mtxtMoney.Mask = "999999";
            this.mtxtMoney.Name = "mtxtMoney";
            this.mtxtMoney.Size = new System.Drawing.Size(100, 19);
            this.mtxtMoney.TabIndex = 5;
            this.mtxtMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 222);
            this.Controls.Add(this.mtxtMoney);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monCalendar);
            this.Name = "ItemForm";
            this.Text = "登録";
            this.Load += new System.EventHandler(this.ItemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCansel;
        public System.Windows.Forms.MonthCalendar monCalendar;
        public System.Windows.Forms.ComboBox cmbCategory;
        public System.Windows.Forms.TextBox txtItem;
        public System.Windows.Forms.TextBox txtRemarks;
        public System.Windows.Forms.MaskedTextBox mtxtMoney;
        private CategoryDataSet categoryDataSet;
        private System.Windows.Forms.BindingSource categoryDataTableBindingSource;
    }
}