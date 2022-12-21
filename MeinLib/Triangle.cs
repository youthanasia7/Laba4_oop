using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace MeinLib
{
    public class Triangle : Polygon
    {
        public Triangle(PictureBox p, Bitmap b, ComboBox cmbbx) : base(p, b, cmbbx) 
        {
            Name = "Треугольник " + ++Counters.triC;

        }
        public Triangle(Point[] points, PictureBox pictureBox, Bitmap b, ComboBox cmbbx) : base(points, pictureBox, b, cmbbx) 
        {
            Name = "Треугольник " + ++Counters.triC;
        }
    }
}
