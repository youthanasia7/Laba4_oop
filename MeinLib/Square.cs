using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MeinLib
{
    public class Square : Rectangle

    {
        public string name;
        public Square(PictureBox p, Bitmap b, ComboBox cmbbx) : base(p, b, cmbbx) 
        {
            Name = "Квадрат " + ++Counters.squareC;
        }
        public Square(int x, int y, int w, PictureBox pictureBox, Bitmap b, ComboBox cmbbx) : base(x, y, w, w, pictureBox, b, cmbbx) 
        {
            Name = "Квадрат " + ++Counters.squareC;
        }

        public Square(string name, int x, int y, int w, PictureBox pictureBox, Bitmap b, ComboBox cmbbx) : base(x, y, w, w, pictureBox, b, cmbbx)
        {
            this.name = name;
        }

        public override void Draw()
        {
            if (!((y < 0) || (y + height > pictureBox.Height) || (x < 0) || (x + width > pictureBox.Width)))
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawRectangle(pen, x, y, width, width);
                pictureBox.Image = bitmap;
            }
            else throw new Exception("Фигура выходит за границы");
        }

        public override void MoveTo(int x, int y)
        {
            if (!((y < 0) || (y + height > pictureBox.Height) || (x < 0) || (x + width > pictureBox.Width)))
            {
                this.x = x; this.y = y;
                DeleteF(this, false);
                Draw();
            }
            else throw new Exception("Фигура выходит за границы");
        }

        public void ChangeSizeTo(int w)
        {
            if (!((y < 0) || (y + w > pictureBox.Height) || (x < 0) || (x + w > pictureBox.Width)))
            {
                width = w; height = w;
                DeleteF(this, false);
                Draw();
            }
            else throw new Exception("Фигура выходит за границы");
        }
    }
}