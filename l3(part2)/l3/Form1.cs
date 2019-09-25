using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace l3
{

    public partial class Form1 : Form
    {
        public static Point coordinates;
        Color spaceColor;
        Color borderColor;
        List<Point> border = new List<Point>();
        Point new_coordinates;
        int direction;
        int iter = 0;
        Bitmap input;
        Bitmap output;
        bool check = false;

       void calcSomePoint(int i)
        {
            switch(i)
            {
                case 0:
                    new_coordinates.X++;
                    if (input.GetPixel(new_coordinates.X, new_coordinates.Y).Equals(borderColor) && input.GetPixel(new_coordinates.X, new_coordinates.Y + 1).Equals(spaceColor))
                    {
                        if (!border.Contains(new_coordinates))
                        {

                            border.Add(new_coordinates); output.SetPixel(new_coordinates.X, new_coordinates.Y, Color.Red);
                            direction = 0;
                            check = true;
                            break;
                        }
                    }
                    new_coordinates.X--;
                    break;

                case 1:
                    new_coordinates.X++;
                    new_coordinates.Y--;
                    if (input.GetPixel(new_coordinates.X, new_coordinates.Y).Equals(borderColor) && (input.GetPixel(new_coordinates.X + 1, new_coordinates.Y).Equals(spaceColor) || input.GetPixel(new_coordinates.X, new_coordinates.Y+1).Equals(spaceColor)))
                    {
                        if (!border.Contains(new_coordinates))
                        {

                            border.Add(new_coordinates); output.SetPixel(new_coordinates.X, new_coordinates.Y, Color.Red);
                            direction = 1;
                            check = true;
                            break;
                        }
                    }
                    new_coordinates.X--;
                    new_coordinates.Y++;
                    break;

                case 2:
                    new_coordinates.Y--;
                    if (input.GetPixel(new_coordinates.X, new_coordinates.Y).Equals(borderColor) && input.GetPixel(new_coordinates.X + 1, new_coordinates.Y).Equals(spaceColor))
                    {
                        if (!border.Contains(new_coordinates))
                        {

                            border.Add(new_coordinates); output.SetPixel(new_coordinates.X, new_coordinates.Y, Color.Red);
                            direction = 2;
                            check = true;
                            break;
                        }
                    }
                    new_coordinates.Y++;
                    break;

                case 3:
                    new_coordinates.X--;
                    new_coordinates.Y--;
                    if (input.GetPixel(new_coordinates.X, new_coordinates.Y).Equals(borderColor) && (input.GetPixel(new_coordinates.X + 1, new_coordinates.Y).Equals(spaceColor) || input.GetPixel(new_coordinates.X, new_coordinates.Y - 1).Equals(spaceColor)))
                    {
                        if (!border.Contains(new_coordinates))
                        {

                            border.Add(new_coordinates); output.SetPixel(new_coordinates.X, new_coordinates.Y, Color.Red);
                            direction = 3;
                            check = true;
                            break;
                        }
                    }
                    new_coordinates.X++;
                    new_coordinates.Y++;
                    break;

                case 4:
                    new_coordinates.X--;
                    if (input.GetPixel(new_coordinates.X, new_coordinates.Y).Equals(borderColor) && input.GetPixel(new_coordinates.X, new_coordinates.Y-1).Equals(spaceColor))
                    {
                        if (!border.Contains(new_coordinates))
                        {

                            border.Add(new_coordinates); output.SetPixel(new_coordinates.X, new_coordinates.Y, Color.Red);
                            direction = 4;
                            check = true;
                            break;
                        }
                    }
                    new_coordinates.X++;
                    break;
                case 5:
                    new_coordinates.X--;
                    new_coordinates.Y++;
                    if (input.GetPixel(new_coordinates.X, new_coordinates.Y).Equals(borderColor) && (input.GetPixel(new_coordinates.X - 1, new_coordinates.Y).Equals(spaceColor) || input.GetPixel(new_coordinates.X, new_coordinates.Y - 1).Equals(spaceColor)))
                    {
                        if (!border.Contains(new_coordinates))
                        {

                            border.Add(new_coordinates); output.SetPixel(new_coordinates.X, new_coordinates.Y, Color.Red);
                            direction = 5;
                            check = true;
                            break;
                        }
                    }
                    new_coordinates.X++;
                    new_coordinates.Y--;
                    break;


                case 6:
                    new_coordinates.Y++;
                    if (input.GetPixel(new_coordinates.X, new_coordinates.Y).Equals(borderColor) && input.GetPixel(new_coordinates.X - 1, new_coordinates.Y).Equals(spaceColor))
                    {
                        if (!border.Contains(new_coordinates))
                        {

                            border.Add(new_coordinates); output.SetPixel(new_coordinates.X, new_coordinates.Y, Color.Red);
                            direction = 6;
                            check = true;
                            break;
                        }
                    }
                    new_coordinates.Y--;

                    break;
                case 7:
                    new_coordinates.X++;
                    new_coordinates.Y++;
                    if (input.GetPixel(new_coordinates.X, new_coordinates.Y).Equals(borderColor) && (input.GetPixel(new_coordinates.X - 1, new_coordinates.Y).Equals(spaceColor) || input.GetPixel(new_coordinates.X, new_coordinates.Y + 1).Equals(spaceColor)))
                    {
                        if (!border.Contains(new_coordinates))
                        {

                            border.Add(new_coordinates); output.SetPixel(new_coordinates.X, new_coordinates.Y, Color.Red);
                            direction = 7;
                            check = true;
                            break;
                        }
                    }
                    new_coordinates.X--;
                    new_coordinates.Y--;

                    break;
            }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            // диалог для выбора файла
            OpenFileDialog ofd = new OpenFileDialog();
            // фильтр форматов файлов
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            // если в диалоге была нажата кнопка ОК
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // загружаем изображение
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
                catch // в случае ошибки выводим MessageBox
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                coordinates = me.Location;
                input = new Bitmap(pictureBox1.Image);
                output = new Bitmap(pictureBox1.Image);

                spaceColor = input.GetPixel(coordinates.X, coordinates.Y);
                while (coordinates.Y < input.Height-1)
                {
                    coordinates.Y++;
                    if (!spaceColor.Equals(input.GetPixel(coordinates.X, coordinates.Y)))
                    {
                        borderColor = input.GetPixel(coordinates.X, coordinates.Y);
                        check = true;
                        break;
                    }
                }

                if (check)
                {
                    border.Add(coordinates);
                    output.SetPixel(coordinates.X, coordinates.Y, Color.Red);
                    new_coordinates = coordinates;
                    direction = 0;
                    do
                    {
                        iter++;
                        int i = (direction - 2) % 8;
                        if (direction == 0)
                            i = 6;
                        else if (direction == 1)
                            i = 7;
                        int comp = i;
                        check = false;

                        do
                        {
                            calcSomePoint(i);
                            i = (i + 1) % 8;
                        } while (i != comp);


                    } while (iter < 10000);
                    iter = 0;
                    border = new List<Point>();
                    label2.Text = "Цвет области: " + spaceColor.ToString();
                    label1.Text = "Цвет границы: " + borderColor.ToString();
                    pictureBox2.Image = output;
                }
            }
        }
    }
}
