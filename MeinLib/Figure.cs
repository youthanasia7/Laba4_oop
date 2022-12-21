using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace MeinLib
{
    public struct Counters
    {
        public static int ellipseC { get; set; } = 0;
        public static int rectC { get; set; } = 0;
        public static int circleC { get; set; } = 0;
        public static int squareC { get; set; } = 0;
        public static int polyC { get; set; } = 0;

        public static int triC { get; set; } = 0;
        public static int planeC { get; set; } = 0;
        public static void Reset()
        {
            ellipseC = 0;
            rectC = 0;
            circleC = 0;
            squareC = 0;
            polyC = 0;
            triC = 0;
            planeC = 0;
        }
    }
    public abstract class Figure
    {
        public Figure(PictureBox p, Bitmap b, ComboBox cmbbx)
        {
            x = 0;
            y = 0; 
            width = 0; 
            height = 0;
            pictureBox = p;
            bitmap = b;
            Flist.figures.Add(this);
            
        }
        public Figure(int x, int y, PictureBox p, Bitmap b, ComboBox cmbbx)
        {
            this.x = x;
            this.y = y;
            this.width = 0;
            this.height = 0;
            pictureBox = p;
            bitmap = b;
            Flist.figures.Add(this);
        }
        public Figure(int x, int y, int w, int h, PictureBox p, Bitmap b, ComboBox cmbbx)
        {
            this.x = x; 
            this.y = y;
            this.width = w;
            this.height = h;
            pictureBox = p;
            bitmap = b;
            Flist.figures.Add(this);
        }
        public PictureBox pictureBox;
        public Bitmap bitmap;
        public Pen pen = new Pen(Color.Black, 2);
        
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string Name { get; set; }
        abstract public void Draw();
        abstract public void MoveTo(int x, int y);
        public void DeleteF(Figure figure, bool flag)
        {
            if (flag == true)
            {
                Flist.figures.Remove(figure);
                Clear();
                foreach (Figure f in Flist.figures)
                {
                    f.Draw();
                }
                pictureBox.Image = bitmap;
            }
            else
            {
                Flist.figures.Remove(figure);
                Clear();
                foreach (Figure f in Flist.figures)
                {
                    f.Draw();
                }
                Flist.figures.Add(figure);
                pictureBox.Image = bitmap;
            }
        }
        public void Clear()
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            pictureBox.Image = bitmap;
        }
    }
}


