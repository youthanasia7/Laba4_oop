using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MeinLib
{
    public class Rectangle : Figure
    {
        public Rectangle(PictureBox p, Bitmap b, ComboBox cmbbx) : base(p, b, cmbbx) 
        {
            Name = "Прямоугольник " + ++Counters.rectC;
        }
        public Rectangle(int x, int y, int w, int h, PictureBox pictureBox, Bitmap b, ComboBox cmbbx) : base(x, y, w, h, pictureBox, b, cmbbx) 
        {
            Name = "Прямоугольник " + ++Counters.rectC;
        }
        
        public override void Draw()
        {
            if (!((y < 0) || (y + height > pictureBox.Height) || (x < 0) || (x + width > pictureBox.Width)))
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawRectangle(pen, x, y, width, height);
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
        
        public void ChangeSizeTo(int w, int h)
        {
            if (!((y < 0) || (y + h > pictureBox.Height) || (x < 0) || (x + w > pictureBox.Width)))
            {
                width = w; height = h;
                DeleteF(this, false);
                Draw();
            }
            else throw new Exception("Фигура выходит за границы");
        }
    }
}
