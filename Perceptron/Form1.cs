using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    public partial class Form1 : Form
    {
        private Perceptron perceptron;
        private Point startP;
        bool _empty_picture_ = true;
        private bool empty_picture {
            get { return _empty_picture_; }
            set {
                _empty_picture_ = value;
                clean_picture_button.Enabled = !_empty_picture_;
                refresh_add_to_study_set_button_enable();
                identify_picture_button_enable();
            }
        }
        void refresh_add_to_study_set_button_enable() {
            add_to_study_set_button.Enabled = textBox1.Text.Length > 0 && !empty_picture;
        }
        void identify_picture_button_enable() {
            identify_picture_button.Enabled = (perceptron != null && !empty_picture);
        }

        private bool[,] sensor_field;
        Dictionary<char, List<Bitmap>> study_set;

        public Form1() {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Filter =
                "jpg files (*.jpg)|*.jpg|"+
                "png files (*.png)|*.png|"+
                "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;

            saveFileDialog1.Filter =
                "jpg files (*.jpg)|*.jpg|" +
                "png files (*.png)|*.png|" +
                "All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            openFileDialog2.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog2.Filter = "perceptron files (*.pcptrn)|*.pcptrn";
            openFileDialog2.FilterIndex = 1;
            openFileDialog2.RestoreDirectory = true;
            openFileDialog2.Multiselect = false;

            saveFileDialog2.Filter = "perceptron files (*.pcptrn)|*.pcptrn";
            saveFileDialog2.FilterIndex = 1;
            saveFileDialog2.RestoreDirectory = true;

            fontDialog1.Font = new Font("Arial", 40f);

            study_set = new Dictionary<char, List<Bitmap>>();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                Point endP = new Point(e.X, e.Y);
                Bitmap image = (Bitmap)pictureBox1.Image;
                using (Graphics g = Graphics.FromImage(image)) {
                    g.DrawLine(new Pen(Color.BlueViolet), startP, endP);
                }
                pictureBox1.Image = image;
                if (startP != endP) empty_picture = false;
                startP = endP;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            startP = new Point(e.X, e.Y);
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            drawen();
        }

        private void resize_image() {
            if (pictureBox1.Image.Width < pictureBox1.Width || pictureBox1.Image.Height < pictureBox1.Height)
            {
                Bitmap Image = new Bitmap(Math.Max(pictureBox1.Image.Width, pictureBox1.Width), Math.Max(pictureBox1.Image.Height, pictureBox1.Height));

                using (Graphics g = Graphics.FromImage(Image)) {
                    g.DrawImage(pictureBox1.Image, 0, 0);
                }

                pictureBox1.Image = Image;
            }
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e) {
            resize_image();
        }

        private void LoadPictureMenuItem_Click(object sender, EventArgs e) {
            clear();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                resize_image();
                drawen();
            }
        }

        private void SavePictureMenuItem_Click(object sender, EventArgs e) {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                pictureBox1.Image.Save(openFileDialog1.FileName);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            draw_button.Enabled = textBox1.Text.Length > 0;
            refresh_add_to_study_set_button_enable();
        }

        private void draw_Click(object sender, EventArgs e) {
            clear();
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            using (Graphics g = Graphics.FromImage(bmp)) {
                SizeF size = g.MeasureString(textBox1.Text, fontDialog1.Font);
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode =  System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.DrawString(textBox1.Text, fontDialog1.Font, new SolidBrush(Color.Black), Point.Empty);
                empty_picture = false;
            }
            pictureBox1.Image = bmp;
            drawen();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e) {
            fontDialog1.ShowDialog();
        }

        private void clean_picture_button_Click(object sender, EventArgs e) {
            clear();
        }

        private void clear() {
            if (!empty_picture) {
                empty_picture = true;
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            }
        }

        void drawen() {
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            {
                //it would be better to use unsafe code
                Bitmap bmp = (Bitmap)pictureBox1.Image;
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
                int size = bmpData.Stride * bmpData.Height;
                byte[] data = new byte[size];
                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, data, 0, size);
                //System.Runtime.InteropServices.Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
                bmp.UnlockBits(bmpData);
                int min_x = bmp.Width, min_y = bmp.Height, max_x = 0, max_y = 0;
                for (int x = 0; x < bmp.Width; x++) {
                    for (int y = 0; y < bmp.Height; y++) {
                        if (data[(y * bmp.Width + x)*4 + 3] > 0) {
                            min_x = Math.Min(min_x, x);
                            min_y = Math.Min(min_y, y);
                            max_x = Math.Max(max_x, x);
                            max_y = Math.Max(max_y, y);
                        }
                    }
                }

                if (min_x > max_x || min_y > max_y || max_x == 0 || max_y == 0) {
                    empty_picture = true;
                    return;
                } else empty_picture = false;

                if (sensor_field == null) return;

                int space_width = (max_x - min_x) + 1;
                int space_height = (max_y - min_y) + 1;

                float width = space_width / (float)sensor_field.GetLength(0);
                float height = space_height / (float)sensor_field.GetLength(1);

                for (int x = 0; x < sensor_field.GetLength(0); x++) {
                    for (int y = 0; y < sensor_field.GetLength(1); y++) {
                        sensor_field[x, y] = false;
                    }
                }

                for (int x = 0; x < sensor_field.GetLength(0); x++) {
                    int _x_lim = Math.Min(Math.Max((int)((x + 1) * width) + min_x, (int)(x * width) + min_x + 1), max_x + 1);
                    for (int y = 0; y < sensor_field.GetLength(1); y++) {
                        int _y_lim = Math.Min(Math.Max((int)((y + 1)*height) + min_y, (int)(y * height) + min_y + 1), max_y + 1);
                        for (int _x = (int)(x*width) + min_x; _x < _x_lim; _x++) {
                            for (int _y = (int)(y*height) + min_y; _y < _y_lim; _y++) {
                                if (data[(_y * bmp.Width + _x) * 4 + 3] > 0) {
                                    sensor_field[x, y] = true;
                                    break;
                                }
                            }
                            if (sensor_field[x, y]) break;
                        }
                    }
                }

            }
            {
                float width = pictureBox2.Image.Width / (float)sensor_field.GetLength(0);
                float height = pictureBox2.Image.Height / (float)sensor_field.GetLength(1);
                Bitmap bmp = (Bitmap)pictureBox2.Image;
                Brush black_brush = new SolidBrush(Color.Black);
                using (Graphics g = Graphics.FromImage(bmp)) {
                    for (int x = 0; x < sensor_field.GetLength(0); x++) {
                        for (int y = 0; y < sensor_field.GetLength(1); y++) {
                            if (sensor_field[x, y]) g.FillRectangle(black_brush, new RectangleF(width * x, height * y, width, height));
                        }
                    }
                }
                pictureBox2.Image = bmp;
            }
        }

        private void add_to_study_set_button_Click(object sender, EventArgs e) {
            if (empty_picture) return;
            if (!study_set.ContainsKey(textBox1.Text[0])) study_set.Add(textBox1.Text[0], new List<Bitmap>());
            study_set[textBox1.Text[0]].Add(new Bitmap((Bitmap)pictureBox1.Image));
            viewStudySetToolStripMenuItem.Enabled = true;
            clearToolStripMenuItem.Enabled = true;
        }

        private void viewStudySetToolStripMenuItem_Click(object sender, EventArgs e) {
            StudySetViewer form = new StudySetViewer(study_set);
            form.ShowDialog();
            if (study_set.Count == 0) {
                viewStudySetToolStripMenuItem.Enabled = false;
                clearToolStripMenuItem.Enabled = false;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e) {
            study_set.Clear();
            viewStudySetToolStripMenuItem.Enabled = false;
            clearToolStripMenuItem.Enabled = false;
        }

        //private byte GetBytesPerPixel(PixelFormat pixelFormat) {
        //    switch (pixelFormat) {
        //        case PixelFormat.Format8bppIndexed: return 1;
        //        case PixelFormat.Format16bppGrayScale:
        //        case PixelFormat.Format16bppRgb555:
        //        case PixelFormat.Format16bppRgb565:
        //        case PixelFormat.Format16bppArgb1555: return 2;
        //        case PixelFormat.Format24bppRgb: return 3;
        //        case PixelFormat.Format32bppArgb:
        //        case PixelFormat.Format32bppPArgb:
        //        case PixelFormat.Format32bppRgb: return 32;
        //        default: return 0;
        //    }
        //}
    }
}
