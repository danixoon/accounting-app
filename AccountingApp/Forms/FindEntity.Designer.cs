namespace AccountingApp.Forms
{
    partial class FindEntity
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
            this.entityTypeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.componentsBox = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.entityUserNameBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.entityComponentTypeBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.componentsBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // entityTypeBox
            // 
            this.entityTypeBox.FormattingEnabled = true;
            this.entityTypeBox.Location = new System.Drawing.Point(12, 24);
            this.entityTypeBox.Name = "entityTypeBox";
            this.entityTypeBox.Size = new System.Drawing.Size(150, 21);
            this.entityTypeBox.TabIndex = 0;
            this.entityTypeBox.SelectedIndexChanged += new System.EventHandler(this.entityTypeBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тип сущности";
            // 
            // componentsBox
            // 
            this.componentsBox.AllowUserToAddRows = false;
            this.componentsBox.AllowUserToDeleteRows = false;
            this.componentsBox.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.componentsBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.componentsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentsBox.Location = new System.Drawing.Point(3, 16);
            this.componentsBox.Name = "componentsBox";
            this.componentsBox.Size = new System.Drawing.Size(457, 232);
            this.componentsBox.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.componentsBox);
            this.groupBox1.Location = new System.Drawing.Point(11, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 251);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Используемые компоненты";
            // 
            // entityUserNameBox
            // 
            this.entityUserNameBox.FormattingEnabled = true;
            this.entityUserNameBox.Location = new System.Drawing.Point(168, 24);
            this.entityUserNameBox.Name = "entityUserNameBox";
            this.entityUserNameBox.Size = new System.Drawing.Size(150, 21);
            this.entityUserNameBox.TabIndex = 0;
            this.entityUserNameBox.SelectedIndexChanged += new System.EventHandler(this.entityUserNameBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя пользователя";
            // 
            // entityComponentTypeBox
            // 
            this.entityComponentTypeBox.FormattingEnabled = true;
            this.entityComponentTypeBox.Location = new System.Drawing.Point(324, 24);
            this.entityComponentTypeBox.Name = "entityComponentTypeBox";
            this.entityComponentTypeBox.Size = new System.Drawing.Size(150, 21);
            this.entityComponentTypeBox.TabIndex = 0;
            this.entityComponentTypeBox.SelectedIndexChanged += new System.EventHandler(this.entityComponentTypeBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Тип компонента";
            // 
            // FindEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 315);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.entityComponentTypeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.entityUserNameBox);
            this.Controls.Add(this.entityTypeBox);
            this.MinimumSize = new System.Drawing.Size(502, 39);
            this.Name = "FindEntity";
            this.Text = "Поиск сущностей";
            ((System.ComponentModel.ISupportInitialize)(this.componentsBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox entityTypeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView componentsBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox entityUserNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox entityComponentTypeBox;
        private System.Windows.Forms.Label label3;
    }
}