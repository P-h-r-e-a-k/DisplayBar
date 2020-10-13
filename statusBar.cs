using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Design;

namespace DisplayBar
{
    public partial class statusBar: UserControl
    {

        private uint max = 100;
        private uint min = 0;
        private uint val = 50;
        private Color colourFull = Color.PaleVioletRed;
        private Color colourEmpty = System.Drawing.Color.LightGray;
        private Color colourFont = Color.Black;
        private bool displayValue = true;
        private bool vertical = !false;
        private Size size = new Size();
        public uint Val
        {
            get => val;
            set
            {
                val = value;
                this.Refresh();
            }
        }
        public uint Max { get => max; set => max = value; }
        public uint Min { get => min; set => min = value; }
        public Color ColourFull { get => colourFull; set => colourFull = value; }
        public Color ColourEmpty { get => colourEmpty; set => colourEmpty = value; }
        public Color ColourFont { get => colourFont; set => colourFont = value; }
        public bool DisplayValue { get => displayValue; set => displayValue = value; }
        public bool Vertical { get => vertical; set => vertical = value; }
        public statusBar()
        {
            InitializeComponent();
        }
        /**
                 * 
                 *  
                protected override void OnPaint(PaintEventArgs e)
                {
                    string val = this.Val.ToString();
                    uint width;
                    uint height;
                    base.OnPaint(e);

                    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(ColourEmpty);
                    System.Drawing.Graphics formGraphics;
                    formGraphics = this.CreateGraphics();
                    //formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, this.Width, this.Height));

                    myBrush.Color = ColourFull;
                    if (!vertical)
                        formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, (int)(((float)this.Width / (float)Max) * this.Val), this.Height));
                    else
                    {
                        height = (uint)(((float)this.Height / (float)Max) * this.Val);
                        formGraphics.FillRectangle(myBrush, new Rectangle(0, this.Height * (int)(this.Val/max), this.Width, (int)(((float)this.Height / (float)Max) * this.Val)));
                    }
                    myBrush.Dispose();
                    formGraphics.Dispose();
                    if (DisplayValue)
                    {
                        Size textSize = TextRenderer.MeasureText(val, this.Font);
                        int textWidth = textSize.Width;
                        int textHeight = textSize.Height;
                        TextRenderer.DrawText(e.Graphics, val, this.Font, new Point((this.Width / 2) - (textWidth / 2), (this.Height - textHeight) / 2), ColourFont);
                    }
                }

                */
        protected override void OnPaint(PaintEventArgs e)
        {
            string val = this.Val.ToString();
            base.OnPaint(e);

            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(ColourEmpty);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, this.Width, this.Height));

            myBrush.Color = ColourFull;
            formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, (int)(((float)this.Width/(float)Max) * this.Val), this.Height));
            myBrush.Dispose();
            formGraphics.Dispose();
            if (DisplayValue)
            {
                Size textSize = TextRenderer.MeasureText(val, this.Font);
                int textWidth = textSize.Width;
                int textHeight = textSize.Height;
                TextRenderer.DrawText(e.Graphics, val, this.Font, new Point((this.Width / 2) - (textWidth / 2), (this.Height - textHeight) / 2), ColourFont);
            }
        }

        private void statusBar_Load(object sender, EventArgs e)
        {
           /* if(vertical)
            {
                size.Height = this.Width;
                size.Width = this.Height;
                this.Size = size;
            }
            else
            {
                size = this.Size;
            }*/
        }
    }
}
