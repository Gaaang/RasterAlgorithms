using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace raster_algorithms
{
    public partial class Form1 : Form
    {
        private Graphics g;
        Point lastPoint = Point.Empty;
        bool isMouseDown = false;
        int penThickness = 1;                               //толщина карандаша
        Color borderColor = Color.FromArgb(255, 0, 0, 0);   //цвет карандаша
        Color fillColor = Color.Yellow;                     //цвет заливки по умолчанию
        Pen borderPen;
        Pen fillPen;
        TextureBrush textureBrush;
        HashSet<Point> filledPoints = new HashSet<Point>();  //набор точек для прорисовок линий
        Point mouseCoord;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            update_pens();

            radioPen.Checked = true;//по умолчанию рисуем карандашом
        }

        private void update_pens()
        {
            borderPen = new Pen(borderColor, penThickness);
            fillPen = new Pen(fillColor, 1);
        }

        //мышь на элементе управления,кнопка мыши нажата
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isMouseDown = true;
            mouseCoord = e.Location;
        }

        //при перемещении мыши рисует границе по текущей и предыдущей точке
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && radioPen.Checked && lastPoint != null)
            {
                g.DrawLine(borderPen, lastPoint, e.Location);
                lastPoint = e.Location;
                pictureBox1.Invalidate(); //Делает недействительной всю поверхность элемента управления и вызывает его перерисовку.
            }
        }

        //мышь на элементе управления,кнопка мыши опущена
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            lastPoint = Point.Empty;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (radioFillColor.Checked)
            {
                MouseEventArgs m = (MouseEventArgs)e;
                Point p = m.Location;
                simpleFloodFill(p);
            }
            if (radioFillTexture.Checked)
            {
                MouseEventArgs m = (MouseEventArgs)e;
                Point p = m.Location;
                textureFill(p);
            }
            pictureBox1.Invalidate();
        }

        private void chooseBorderColorBtn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.Color = borderColor;

            if (colorDlg.ShowDialog() == DialogResult.OK) //если цвет выбрали,то меняем на него
            {
                borderColor = colorDlg.Color;
                update_pens();
            }
        }

        private void chooseColorBtn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.Color = fillColor;

            if (colorDlg.ShowDialog() == DialogResult.OK)   //если цвет выбрали,то меняем на него
            {
                fillColor = colorDlg.Color;
                update_pens();
            }
        }

        private void loadFillImage()    //загружаем изображения для заливки
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter =
                "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image img = Image.FromFile(openDialog.FileName);
                    textureBrush = new TextureBrush(img);
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chooseImageBtn_Click(object sender, EventArgs e)
        {
            loadFillImage();
        }

        private Color getColorAt(Point point)   //возвращаем цвет текущей точки, чтобы проверить залили/граница/ещё не залита
        {
            if (pictureBox1.ClientRectangle.Contains(point))
                return ((Bitmap)pictureBox1.Image).GetPixel(point.X, point.Y);
            else
                return Color.Black;
        }

        // заливка цветом
        private void simpleFloodFill(Point p)
        {
            Color curr = getColorAt(p);
            Point leftPoint = p;
            Point rightPoint = p;
            if (curr != borderColor && curr != fillColor && pictureBox1.ClientRectangle.Contains(p))
            {
                while (curr != borderColor && pictureBox1.ClientRectangle.Contains(leftPoint))
                {
                    leftPoint.X -= 1;
                    curr = getColorAt(leftPoint);
                }
                leftPoint.X += 1;

                curr = getColorAt(p);
                while (curr != borderColor && pictureBox1.ClientRectangle.Contains(rightPoint))
                {
                    rightPoint.X += 1;
                    curr = getColorAt(rightPoint);
                }
                rightPoint.X -= 1;

                g.DrawLine(fillPen, leftPoint, rightPoint);

                for (int i = leftPoint.X; i <= rightPoint.X; ++i)
                {
                    Point upPoint = new Point(i, p.Y + 1);
                    Color upC = getColorAt(upPoint);
                    if (upC.ToArgb() != borderColor.ToArgb() && upC.ToArgb() != fillColor.ToArgb() && pictureBox1.ClientRectangle.Contains(upPoint))
                        simpleFloodFill(upPoint);
                }

                for (int i = leftPoint.X; i < rightPoint.X; ++i)
                {
                    Point downPoint = new Point(i, p.Y - 1);
                    Color downC = getColorAt(downPoint);
                    if (downC.ToArgb() != borderColor.ToArgb() && downC.ToArgb() != fillColor.ToArgb() && pictureBox1.ClientRectangle.Contains(downPoint))
                        simpleFloodFill(downPoint);
                }
                return;
            }
        }

        private void DrawHorizontalLineTexture(int x1, int x2, int y)
        {
            g.FillRectangle(textureBrush, x1, y, Math.Abs(x2 - x1) + 1, 1);
            for (int i = x1; i <= x2; ++i)
                filledPoints.Add(new Point(i, y));
        }


        // заливка текстурой
        private void textureFill(Point p)
        {
            if (textureBrush == null)   //если изобращения ещё нет,загружаем
                loadFillImage();
            else
            {
                filledPoints.Clear();
                textureFill2(p);
            }
        }

        private void textureFill2(Point p)
        {
            Color curr = getColorAt(p);
            Point leftPoint = p;
            Point rightPoint = p;
            if (!filledPoints.Contains(p) && pictureBox1.ClientRectangle.Contains(p) && curr != borderColor)
            {
                while (curr != borderColor && pictureBox1.ClientRectangle.Contains(leftPoint))//идем влево пока не встречена граница 
                {                                                                             //или не вышли за пределы picturebox
                    leftPoint.X -= 1;
                    curr = getColorAt(leftPoint);
                }
                leftPoint.X += 1;

                curr = getColorAt(p);
                while (curr != borderColor && pictureBox1.ClientRectangle.Contains(rightPoint))
                {
                    rightPoint.X += 1;
                    curr = getColorAt(rightPoint);
                }
                rightPoint.X -= 1;

                DrawHorizontalLineTexture(leftPoint.X, rightPoint.X, leftPoint.Y);

                for (int i = leftPoint.X; i <= rightPoint.X; ++i)//вызываем функцию от точки выше текущей
                {
                    Point upPoint = new Point(i, p.Y + 1);
                    Color upC = getColorAt(upPoint);
                    if (!filledPoints.Contains(upPoint) && upC.ToArgb() != borderColor.ToArgb() && pictureBox1.ClientRectangle.Contains(upPoint))
                        textureFill2(upPoint);
                }
                for (int i = leftPoint.X; i < rightPoint.X; ++i)
                {
                    Point downPoint = new Point(i, p.Y - 1);
                    Color downC = getColorAt(downPoint);
                    if (!filledPoints.Contains(downPoint) && downC.ToArgb() != borderColor.ToArgb() && pictureBox1.ClientRectangle.Contains(downPoint))
                        textureFill2(downPoint);
                }
                return;
            }
        }

        private void radioSelectBorder_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Default;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Invalidate();
        }

        // выделить границу
        private void selectBorder(Color c)
        {
            List<Point> pixels = new List<Point>();
            Point curr = findStartPoint();
            Point start = curr;
            pixels.Add(start);
            Color borderColor = bmp.GetPixel(curr.X, curr.Y);

            Point next = new Point();
            int currDir = 6;
            int nextDir = -1;
            int moveTo = 0;
            do
            {
                moveTo = (currDir - 2 + 8) % 8;
                int mt = moveTo;
                do
                {
                    next = curr;
                    switch (moveTo)
                    {
                        case 0: next.X++; nextDir = 0; break;
                        case 1: next.X++; next.Y--; nextDir = 1; break;
                        case 2: next.Y--; nextDir = 2; break;
                        case 3: next.X--; next.Y--; nextDir = 3; break;
                        case 4: next.X--; nextDir = 4; break;
                        case 5: next.X--; next.Y++; nextDir = 5; break;
                        case 6: next.Y++; nextDir = 6; break;
                        case 7: next.X++; next.Y++; nextDir = 7; break;
                    }

                    if (next == start)
                        break;

                    if (bmp.GetPixel(next.X, next.Y) == borderColor)
                    {
                        pixels.Add(next);
                        curr = next;
                        currDir = nextDir;
                        break;
                    }
                    moveTo = (moveTo + 1) % 8;
                } while (moveTo != mt);
            } while (next != start);

            foreach (var p in pixels)
                bmp.SetPixel(p.X, p.Y, c);

            pixels.Sort(compareY);
            HashSet<Point> pixset = new HashSet<Point>();

            foreach (var p in pixels)
            {
                pixset.Add(p);
            }


            Console.WriteLine(pixset.Count);
            Console.WriteLine(pixels.Count);
        }

        // найти точку, принадлежащую границе
        private Point findStartPoint()
        {
            int x = mouseCoord.X;
            int y = mouseCoord.Y;

            Color bgColor = bmp.GetPixel(mouseCoord.X, mouseCoord.Y);
            Color currColor = bgColor;
            while (x < bmp.Width - 2 && currColor.ToArgb() == bgColor.ToArgb())
            {
                x++;
                currColor = bmp.GetPixel(x, y);
            }

            return new Point(x, y);
        }

        //для сравнения точек
        private int compareY(Point p1, Point p2)
        {
            if (p1.Y < p2.Y)
                return 1;
            else if (p1.Y == p2.Y)
                return 0;
            return -1;
        }


    }
}
