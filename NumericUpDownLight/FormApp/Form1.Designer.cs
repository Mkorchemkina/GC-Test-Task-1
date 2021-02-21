
namespace FormApp
{
    partial class DemoForm
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
            this.numericUpDownLight1.Location = new System.Drawing.Point(13, 13);
            this.numericUpDownLight1.Name = "numericUpDownLight1";
            this.numericUpDownLight1.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownLight1.TabIndex = 0;
            this.numericUpDownLight1.Text = null;
            this.numericUpDownLight1.TextAlign = NumericUpDownLight.NumericUpDownLight.TextAlignType.Left;
            this.numericUpDownLight1.Value = 0;
            this.numericUpDownLight1.ValueChanged += new System.EventHandler<int>(this.numericUpDownLight1_ValueChanged);
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 67);
            this.Controls.Add(this.numericUpDownLight1);
            this.Name = "DemoForm";
            this.Text = "Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private NumericUpDownLight.NumericUpDownLight numericUpDownLight1;
    }
}

