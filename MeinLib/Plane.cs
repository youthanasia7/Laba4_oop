using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MeinLib
{
    public class Plane : Figure
    {
        public List<Figure> figures = null;
        public ComboBox cmbbx;
        public Rectangle re;
        public Rectangle re1;
        
        public Triangle tg;
        public Triangle tg2;
        public Triangle tg3;
        public Triangle tg4;
        public Plane(PictureBox p, Bitmap b, ComboBox cmbbx) : base(p, b, cmbbx) 
        {
            Name = "Самолет " + ++Counters.planeC;
        }
        public Plane(int x, int y, PictureBox pictureBox, Bitmap b, ComboBox cmbbx) : base(x, y, 320, 160, pictureBox, b, cmbbx)
        {
            
            figures = new List<Figure>();
            this.cmbbx = cmbbx;
            re = new Rectangle(x+40, y+50, 120, 30, pictureBox, b, cmbbx);
            re1 = new Rectangle(x+160, y+50, 30, 30, pictureBox, b, cmbbx);
            Point p1 = new Point(x + 130, y );
            Point p2 = new Point(x + 130, y + 50);
            Point p3 = new Point(x + 160, y + 50);
            Point[] point1 = { p1, p2, p3 };
            Point p4 = new Point(x + 20, y + 15);
            Point p5 = new Point(x + 30, y + 50);
            Point p6 = new Point(x + 60, y + 50);
            Point[] point2 = { p4, p5, p6 };
            tg = new Triangle(point1, pictureBox, b, cmbbx);
            tg2 = new Triangle(point2, pictureBox, b, cmbbx);

            Point p7 = new Point(x + 190, y + 50);
            Point p8 = new Point(x + 190, y + 80);
            Point p9 = new Point(x + 240, y + 80);
            Point[] point3 = { p7, p8, p9 };
            tg3 = new Triangle(point3, pictureBox, b, cmbbx);

            Point p10 = new Point(x , y + 130);
            Point p11 = new Point(x + 40, y + 80);
            Point p12 = new Point(x + 160, y + 80);
            Point[] point4 = { p10, p11, p12 };
            tg4 = new Triangle(point4, pictureBox, b, cmbbx);

            Figure[] f_list = { re, re1, tg, tg2, tg3, tg4 };
            figures.AddRange(f_list);
            Flist.figures.Remove(re);
            Flist.figures.Remove(re1);
            Flist.figures.Remove(tg);
            Flist.figures.Remove(tg2);
            Flist.figures.Remove(tg3);
            Flist.figures.Remove(tg4);
            Counters.triC--;
    
            Counters.rectC--;
           
            Name = "Самолет " + ++Counters.planeC;
        }
        public override void Draw()
        {
            if (!((y < 0) || (y + height > pictureBox.Height) || (x < 0) || (x + width > pictureBox.Width)))
            {
                foreach (Figure f in figures)
                {
                    f.Draw();
                }
            }
            else MessageBox.Show("Фигура выходит за границы");
        }
        public override void MoveTo(int x, int y)
        {
            if (!((y < 0) || (y + height > pictureBox.Height) || (x < 0) || (x + width > pictureBox.Width)))
            {
                re.MoveTo(x+40, y+50);
                re1.MoveTo(x+160, y+50);
                tg.MoveTo(x+130, y);
                tg2.MoveTo(x+20, y+15);
                tg3.MoveTo(x+190, y+50);
                tg4.MoveTo(x, y+130);
                DeleteF(this, false);
                Draw();           
            }
            else MessageBox.Show("Фигура выходит за границы");
        }
       
        
    }
}
