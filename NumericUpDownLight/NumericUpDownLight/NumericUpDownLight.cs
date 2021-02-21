using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace NumericUpDownLight
{
    public class NumericUpDownLight : System.Windows.Forms.Control
    {
        //Add a new field  - Value
        public int Value { get; set; }
        //Add a new field  - TextAlign
        public enum TextAlignType { Left, Center, Right };
        public TextAlignType TextAlign { get; set; }
        
        //Hide the "Text" field 
        [
           Browsable(false)
        ]
        public override string Text { get; set; }

        public NumericUpDownLight()
        {
            InitializeComponent();
        }

        void InitializeComponent()
        {
            this.Size = new Size(60, 20);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.  
            base.OnPaint(e);

            SolidBrush myBrush = new SolidBrush(Color.Black);
            e.Graphics.DrawString(Value.ToString(), this.Font, myBrush, new PointF(0, 0));
            
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected virtual void OnValueChanged(EventArgs e)
        {

        }

    }
}
