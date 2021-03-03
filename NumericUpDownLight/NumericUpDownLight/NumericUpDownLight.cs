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
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
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
        private readonly int ButtonWidth = 20;

       

        public NumericUpDownLight()
        {
            InitializeComponent();
            
        }

        void InitializeComponent()
        {
            Size = new Size(70, 30);
            ControlStyles StyleToSet = ControlStyles.FixedHeight;
            StyleToSet |= (ControlStyles.UserPaint | ControlStyles.DoubleBuffer|ControlStyles.AllPaintingInWmPaint);
            SetStyle(StyleToSet, true);
            UpdateStyles();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.  
            base.OnPaint(e);

            Color MyBlack;
            if (BackColor != Color.Black)
                MyBlack = Color.Black;
            else
                MyBlack = Color.White;
           
            SolidBrush BlackBrush = new SolidBrush(MyBlack);
            SolidBrush WhiteBrush = new SolidBrush(BackColor);
            SolidBrush ColorBrush = new SolidBrush(Color.Green); //temp
            Pen BlackPen = new Pen(MyBlack, 1);

            try
            {
                //control
                e.Graphics.FillRectangle(WhiteBrush, 0, 0, Size.Width, Size.Height);
                e.Graphics.DrawRectangle(BlackPen, 0, 0, Size.Width, Size.Height - 1);

                //buttons
                
                //up button
                e.Graphics.FillRectangle(WhiteBrush, Size.Width - ButtonWidth, 0, ButtonWidth - 1, Size.Height / 2);
                e.Graphics.DrawRectangle(BlackPen, Size.Width - ButtonWidth, 0, ButtonWidth - 1, Size.Height / 2);
                PointF[] ArrowUpTriangle = { new PointF(Size.Width - ButtonWidth + 5, Size.Height / 3), new PointF(Size.Width - ButtonWidth / 2, 3), new PointF(Size.Width - 5, Size.Height / 3) };
                e.Graphics.FillPolygon(BlackBrush, ArrowUpTriangle);
                //down button
                e.Graphics.FillRectangle(WhiteBrush, Size.Width - ButtonWidth, Size.Height / 2, ButtonWidth - 1, Size.Height / 2 - 1);
                e.Graphics.DrawRectangle(BlackPen, Size.Width - ButtonWidth, Size.Height / 2, ButtonWidth - 1, Size.Height / 2 - 1);
                PointF[] ArrowDownTriangle = { new PointF(Size.Width - ButtonWidth + 5, 2*Size.Height / 3 - 1), new PointF(Size.Width - 5, 2*Size.Height / 3 - 1), new PointF(Size.Width - ButtonWidth / 2, Size.Height - 4) };
                e.Graphics.FillPolygon(BlackBrush, ArrowDownTriangle);

                TextFormatFlags flags = TextFormatFlags.VerticalCenter;
                switch (TextAlign)
                {
                    case TextAlignType.Left:
                        {
                            flags |= TextFormatFlags.Left;
                            break;
                        }
                    case TextAlignType.Center:
                        {
                            flags |= TextFormatFlags.HorizontalCenter;
                            break;
                        }
                    case TextAlignType.Right:
                        {
                            flags |= TextFormatFlags.Right;
                            break;
                        }
                }
                TextRenderer.DrawText(e.Graphics, Value.ToString(), Font, new Rectangle(0, 0, Size.Width - ButtonWidth, Size.Height), ForeColor, flags);
            }
            finally
            {
                BlackBrush.Dispose();
                WhiteBrush.Dispose();
                ColorBrush.Dispose();
                BlackPen.Dispose();
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        public delegate void _OnClick();
        new public event _OnClick OnClick;
        

        public event EventHandler ValueChanged;

        private void ChangeValue(int add)
        {
            Value += add;
            ValueChanged?.Invoke(new object(), new EventArgs());
        }

        private void ProcessValueChangedEvent(object sender, EventArgs e)
        {
            ChangeValue(1);
        }

    }
}
