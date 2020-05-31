namespace AccountingApp.Forms
{
    partial class FieldInput
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.fieldValue = new System.Windows.Forms.TextBox();
            this.fieldName = new System.Windows.Forms.GroupBox();
            this.fieldName.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldValue
            // 
            this.fieldValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldValue.Location = new System.Drawing.Point(6, 19);
            this.fieldValue.Name = "fieldValue";
            this.fieldValue.Size = new System.Drawing.Size(145, 20);
            this.fieldValue.TabIndex = 0;
            // 
            // fieldName
            // 
            this.fieldName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldName.Controls.Add(this.fieldValue);
            this.fieldName.Location = new System.Drawing.Point(3, 3);
            this.fieldName.Name = "fieldName";
            this.fieldName.Size = new System.Drawing.Size(157, 49);
            this.fieldName.TabIndex = 1;
            this.fieldName.TabStop = false;
            this.fieldName.Text = "Имя";
            // 
            // FieldInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fieldName);
            this.Name = "FieldInput";
            this.Size = new System.Drawing.Size(163, 56);
            this.fieldName.ResumeLayout(false);
            this.fieldName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox fieldValue;
        private System.Windows.Forms.GroupBox fieldName;
    }
}
