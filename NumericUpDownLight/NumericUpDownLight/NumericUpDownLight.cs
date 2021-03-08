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
        private int StoreValue;
        public int Value
        {
            get
            {
                return StoreValue;
            }
            set
            {
                if (StoreValue != value)
                {
                    StoreValue = value;
                    Invalidate();
                    ValueChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        private ContentAlignment StoreTextAlign;
        public ContentAlignment TextAlign
        {
            get
            {
                return StoreTextAlign;
            }
            set
            {
                if (StoreTextAlign != value)
                {
                    StoreTextAlign = value;
                    Invalidate();
                }
            }
        }


        [
           Browsable(false)
        ]
        public override string Text { get; set; }


        private const int DefaultHeight = 30;
        private const int DefaultWidth = 70;
        private const int ButtonWidth = 20;
        Rectangle FieldRect
        {
            get
            {
                return new Rectangle(0, 0, Size.Width, Size.Height - 1);
            }

        }
        Rectangle UpButtonRect
        {
            get
            {
                return new Rectangle(Size.Width - ButtonWidth, 0, ButtonWidth - 1, Size.Height / 2);
            }
        }
        Rectangle DownButtonRect
        {
            get
            {
                return new Rectangle(Size.Width - ButtonWidth, Size.Height / 2, ButtonWidth - 1, Size.Height / 2 - 1);
            }
        }
        Rectangle TextRect
        {
            get
            {
                return new Rectangle(0, 0, Size.Width - ButtonWidth, Size.Height);
            }
        }

        public Color ButtonLightColor { get; set; }
        private Color UpBColor;
        private Color DownBColor;

        public NumericUpDownLight()
        {
            InitializeComponent();

        }

        void InitializeComponent()
        {
            Size = new Size(DefaultWidth, DefaultHeight);
            MinimumSize = new Size(DefaultWidth / 2, DefaultHeight);

            StoreTextAlign = ContentAlignment.TopLeft;
            StoreValue = 0;

            UpBColor = BackColor;
            DownBColor = BackColor;

            ControlStyles StyleToSet = ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint;
            SetStyle(StyleToSet, true);
            UpdateStyles();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color MyBlack;
            if (BackColor != Color.Black)
                MyBlack = Color.Black;
            else
                MyBlack = Color.White;

            using (SolidBrush ArrowBrush = new SolidBrush(MyBlack))
            using (SolidBrush BackBrush = new SolidBrush(BackColor))
            using (SolidBrush UpBBrush = new SolidBrush(UpBColor))
            using (SolidBrush DownBBrush = new SolidBrush(DownBColor))
            using (Pen BlackPen = new Pen(MyBlack, 1))
            {

                //control
                e.Graphics.FillRectangle(BackBrush, FieldRect);
                e.Graphics.DrawRectangle(BlackPen, FieldRect);

                //buttons

                //up button
                e.Graphics.FillRectangle(UpBBrush, UpButtonRect);
                e.Graphics.DrawRectangle(BlackPen, UpButtonRect);
                PointF[] ArrowUpTriangle = { new PointF(Size.Width - ButtonWidth + 5, Size.Height / 3), new PointF(Size.Width - ButtonWidth / 2, 3), new PointF(Size.Width - 5, Size.Height / 3) };
                e.Graphics.FillPolygon(ArrowBrush, ArrowUpTriangle);
                //down button
                e.Graphics.FillRectangle(DownBBrush, DownButtonRect);
                e.Graphics.DrawRectangle(BlackPen, DownButtonRect);
                PointF[] ArrowDownTriangle = { new PointF(Size.Width - ButtonWidth + 5, 2 * Size.Height / 3 - 1), new PointF(Size.Width - 5, 2 * Size.Height / 3 - 1), new PointF(Size.Width - ButtonWidth / 2, Size.Height - 4) };
                e.Graphics.FillPolygon(ArrowBrush, ArrowDownTriangle);

                TextFormatFlags flags = TextFormatFlags.Default;
                switch (TextAlign)
                {
                    case ContentAlignment.TopLeft:
                        {
                            flags |= TextFormatFlags.Left | TextFormatFlags.Top;
                            break;
                        }
                    case ContentAlignment.TopCenter:
                        {
                            flags |= TextFormatFlags.HorizontalCenter | TextFormatFlags.Top;
                            break;
                        }
                    case ContentAlignment.TopRight:
                        {
                            flags |= TextFormatFlags.Right | TextFormatFlags.Top;
                            break;
                        }
                    case ContentAlignment.MiddleLeft:
                        {
                            flags |= TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
                            break;
                        }
                    case ContentAlignment.MiddleCenter:
                        {
                            flags |= TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                            break;
                        }
                    case ContentAlignment.MiddleRight:
                        {
                            flags |= TextFormatFlags.Right | TextFormatFlags.VerticalCenter;
                            break;
                        }
                    case ContentAlignment.BottomLeft:
                        {
                            flags |= TextFormatFlags.Left | TextFormatFlags.Bottom;
                            break;
                        }
                    case ContentAlignment.BottomCenter:
                        {
                            flags |= TextFormatFlags.HorizontalCenter | TextFormatFlags.Bottom;
                            break;
                        }
                    case ContentAlignment.BottomRight:
                        {
                            flags |= TextFormatFlags.Right | TextFormatFlags.Bottom;
                            break;
                        }
                }
                TextRenderer.DrawText(e.Graphics, Value.ToString(), Font, TextRect, ForeColor, flags);
            }
        }

        private bool CheckButColorChange(Rectangle ButtonRect, Point MousePos, ref Color ButColor)
        {
            bool ColorChangedFlag = false;
            if (ButtonRect.Contains(MousePos))
            {
                if (ButColor == BackColor)
                {
                    ButColor = ButtonLightColor;
                    ColorChangedFlag = true;
                }
            }
            else if (ButColor != BackColor)
            {
                ButColor = BackColor;
                ColorChangedFlag = true;
            }
            return ColorChangedFlag;

        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            Point MousePoint = e.Location;
            bool UpBColorChanged = CheckButColorChange(UpButtonRect, MousePoint, ref UpBColor);
            bool DownBColorChanged = CheckButColorChange(DownButtonRect, MousePoint, ref DownBColor);

            if (UpBColorChanged || DownBColorChanged)
                Invalidate();
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (UpBColor != BackColor || DownBColor != BackColor)
                Invalidate();
            UpBColor = BackColor;
            DownBColor = BackColor;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Point ClickPoint = e.Location;

            if (UpButtonRect.Contains(ClickPoint))
            {
                Value++;
            }
            if (DownButtonRect.Contains(ClickPoint))
            {
                Value--;
            }
            base.OnMouseDown(e);
        }


        public event EventHandler ValueChanged;

    }
}
