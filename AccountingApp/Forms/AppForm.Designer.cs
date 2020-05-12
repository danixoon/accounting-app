namespace AccountingApp
{
    partial class AppForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.container = new System.Windows.Forms.Panel();
            this.tableSwitchGroup = new System.Windows.Forms.GroupBox();
            this.tableSwitch = new System.Windows.Forms.TableLayoutPanel();
            this.tableSwitchGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.container.Location = new System.Drawing.Point(12, 73);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(718, 416);
            this.container.TabIndex = 0;
            // 
            // tableSwitchGroup
            // 
            this.tableSwitchGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableSwitchGroup.Controls.Add(this.tableSwitch);
            this.tableSwitchGroup.Location = new System.Drawing.Point(12, 6);
            this.tableSwitchGroup.Name = "tableSwitchGroup";
            this.tableSwitchGroup.Size = new System.Drawing.Size(718, 61);
            this.tableSwitchGroup.TabIndex = 3;
            this.tableSwitchGroup.TabStop = false;
            this.tableSwitchGroup.Text = "Таблицы";
            // 
            // tableSwitch
            // 
            this.tableSwitch.ColumnCount = 1;
            this.tableSwitch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableSwitch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableSwitch.Location = new System.Drawing.Point(3, 16);
            this.tableSwitch.Name = "tableSwitch";
            this.tableSwitch.RowCount = 1;
            this.tableSwitch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableSwitch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableSwitch.Size = new System.Drawing.Size(712, 42);
            this.tableSwitch.TabIndex = 3;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 501);
            this.Controls.Add(this.tableSwitchGroup);
            this.Controls.Add(this.container);
            this.Name = "AppForm";
            this.Text = "Учёт";
            this.tableSwitchGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.GroupBox tableSwitchGroup;
        private System.Windows.Forms.TableLayoutPanel tableSwitch;
    }
}

