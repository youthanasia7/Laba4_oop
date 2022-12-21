using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MeinLib
{
    public class Polygon : Figure
    {
        Point[] points;
        public Polygon(PictureBox p, Bitmap b, ComboBox cmbbx) : base(p, b, cmbbx) 
        {
            Name = "Многоугольник " + ++Counters.polyC;
        }
        public Polygon(Point[] points, PictureBox pictureBox, Bitmap b, ComboBox cmbbx) : base(points[0].X, points[0].Y, pictureBox, b, cmbbx)
        {
            Name = "Многоугольник " + ++Counters.polyC;
            this.points = points;
        }
        public override void Draw()
        {
            if (Coords_check(0, 0))
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawPolygon(pen, points);
                pictureBox.Image = bitmap;
            }
            else MessageBox.Show("Фигура выходит за границы");
        }
        public override void MoveTo(int x, int y)
        {
            Console.WriteLine(this.x.ToString());
            Console.WriteLine(this.y.ToString());
            Console.WriteLine(x.ToString());
            Console.WriteLine(y.ToString());
            int shift_x = x - this.x;
            int shift_y = y - this.y;
            if (Coords_check(shift_x, shift_y))
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].X += shift_x;
                    points[i].Y += shift_y;
                }
                this.x = points[0].X;
                this.y = points[0].Y;
                this.DeleteF(this, false);
                this.Draw();
            }
            else MessageBox.Show("Фигура выходит за границы");
        }
        public bool Coords_check(int x, int y)
        {
            for (int i = 0; i < points.Length; i++)
            {
                if ((points[i].X + x < 0) || (points[i].Y + y < 0) || (points[i].X + x > pictureBox.Width) ||
                    (points[i].Y + y > pictureBox.Height))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
