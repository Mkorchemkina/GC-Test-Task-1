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

            Color MyBlack;
            if (this.BackColor != Color.Black)
                MyBlack = Color.Black;
            else
                MyBlack = Color.White;

            SolidBrush BlackBrush = new SolidBrush(MyBlack);
            SolidBrush TextBrush = new SolidBrush(this.ForeColor);
            SolidBrush WhiteBrush = new SolidBrush(this.BackColor);
            SolidBrush ColorBrush = new SolidBrush(Color.Green); //temp
            Pen BlackPen = new Pen(MyBlack, 1);

            //control
            e.Graphics.FillRectangle(WhiteBrush, 0, 0, this.Size.Width, this.Size.Height);
            e.Graphics.DrawRectangle(BlackPen, 0, 0, this.Size.Width, this.Size.Height - 1);

            //buttons
            //up button
            e.Graphics.DrawRectangle(BlackPen, (int)(this.Size.Width * 0.8), 0, (int)(this.Size.Width * 0.2), this.Size.Height / 2);
            PointF[] ArrowUpTriangle = { new PointF(this.Size.Width * 0.85F, this.Size.Height * 0.3F), new PointF(this.Size.Width * 0.9F, this.Size.Height * 0.15F), new PointF(this.Size.Width * 0.95F, this.Size.Height * 0.3F) };
            e.Graphics.FillPolygon(BlackBrush, ArrowUpTriangle);
            //down button
            e.Graphics.DrawRectangle(BlackPen, (int)(this.Size.Width * 0.8), this.Size.Height / 2, (int)(this.Size.Width * 0.2), this.Size.Height / 2 - 1);
            PointF[] ArrowDownTriangle = { new PointF(this.Size.Width * 0.85F, this.Size.Height * 0.7F), new PointF(this.Size.Width * 0.9F, this.Size.Height * 0.85F), new PointF(this.Size.Width * 0.95F, this.Size.Height * 0.7F) };
            e.Graphics.FillPolygon(BlackBrush, ArrowDownTriangle);

            int XLeft = 0;
            int YTop = Math.Abs(this.Height - (int)this.Font.Height) / 2;
            switch (this.TextAlign.ToString())
            {
                case "Left":
                    {
                        XLeft = 2;
                        break;
                    }
                case "Center":
                    {
                        XLeft = (int)(this.Width * 0.4 - Value.ToString().Length * this.Font.Size / 2);
                        break;
                    }
                case "Right":
                    {
                        //this.Width * 0.8 - 2 - right end of the string, Value.ToString().Length * this.Font.Size - width of word (fix it)
                        XLeft = (int)(this.Width * 0.8 - 2 - Value.ToString().Length * this.Font.Size);
                        break;
                    }
            }

            e.Graphics.DrawString(Value.ToString(), this.Font, TextBrush, new PointF(XLeft, YTop));

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }


        public event EventHandler<int> ValueChanged;

        private void ChangeValue()
        {
            this.Value += 0;
            ValueChanged?.Invoke(this, this.Value);
        }
    }
}
