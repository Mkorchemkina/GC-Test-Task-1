
namespace FormApp
{
    partial class Form1
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
            this.numericUpDownLight1 = new NumericUpDownLight.NumericUpDownLight();
            this.SuspendLayout();
            // 
            // numericUpDownLight1
            // 
            this.numericUpDownLight1.Location = new System.Drawing.Point(349, 65);
            this.numericUpDownLight1.Name = "numericUpDownLight1";
            this.numericUpDownLight1.Size = new System.Drawing.Size(75, 23);
            this.numericUpDownLight1.TabIndex = 0;
            this.numericUpDownLight1.Text = "numericUpDownLight1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numericUpDownLight1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private NumericUpDownLight.NumericUpDownLight numericUpDownLight1;
    }
}

