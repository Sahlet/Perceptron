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
using Newtonsoft.Json;

namespace Perceptron
{
    public partial class Form1 : Form
    {
        Perceptron _perceptron_;
        private Perceptron perceptron {
            get { return _perceptron_; }
            set {
                _perceptron_ = value;
                SavePerceptronToolStripMenuItem.Enabled = _perceptron_ != null;
                createToolStripMenuItem.Enabled = study_set.Count > 0 && _perceptron_ == null;
                cleanToolStripMenuItem.Enabled = _perceptron_ != null;
            }
        }
        private Dictionary<char, List<Bitmap>> study_set = new Dictionary<char, List<Bitmap>>();
        private char[] perceptron_studied_leters;
        private Size sensor_field_size;
        private PerceptronParametersSeter parametersSeter;
        private Point startP;
        bool _empty_picture_ = true;
        private bool empty_picture {
            get { return _empty_picture_; }
            set {
                _empty_picture_ = value;
                clean_picture_button.Enabled = !_empty_picture_;
                refresh_add_to_study_set_button_enable();
                identify_picture_button_enable();
                SavePictureMenuItem.Enabled = !_empty_picture_;
            }
        }
        void refresh_add_to_study_set_button_enable() {
            add_to_study_set_button.Enabled = textBox1.Text.Length > 0 && !empty_picture;
        }
        void identify_picture_button_enable() {
            identify_picture_button.Enabled = (perceptron != null && !empty_picture);
        }

        StudySetViewer studySetViewer;

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

            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
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

            saveFileDialog2.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog2.Filter = "perceptron files (*.pcptrn)|*.pcptrn";
            saveFileDialog2.FilterIndex = 1;
            saveFileDialog2.RestoreDirectory = true;

            fontDialog1.Font = new Font("Arial", 40f);

            studySetViewer = new StudySetViewer(study_set);
            parametersSeter = new PerceptronParametersSeter(studySetViewer);
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
        private class PerceptronData {
            public Size sensor_field_size;
            public string perceptron_str;
            public char[] perceptron_studied_leters;
        }

        private void LoadPerceptronMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                PerceptronData data = JsonConvert.DeserializeObject<PerceptronData>(System.IO.File.ReadAllText(openFileDialog2.FileName));
                perceptron = Perceptron.FromString(data.perceptron_str);
                perceptron_studied_leters = data.perceptron_studied_leters;
                sensor_field_size = data.sensor_field_size;
                drawen();
            }
        }

        private void SavePerceptronToolStripMenuItem_Click(object sender, EventArgs e) {
            if (saveFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                PerceptronData data = new PerceptronData();
                data.perceptron_str = perceptron.ToString();
                data.perceptron_studied_leters = perceptron_studied_leters;
                data.sensor_field_size = sensor_field_size;
                System.IO.File.WriteAllText(saveFileDialog2.FileName, JsonConvert.SerializeObject(data));
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

        private static bool[,] get_sensor_field(Bitmap bmp, Size sensor_field_size) {
            bool[,] sensor_field = new bool[sensor_field_size.Width, sensor_field_size.Height];
            //it would be better to use unsafe code
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
            int size = bmpData.Stride * bmpData.Height;
            byte[] data = new byte[size];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, data, 0, size);
            //System.Runtime.InteropServices.Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
            bmp.UnlockBits(bmpData);
            int min_x = bmp.Width, min_y = bmp.Height, max_x = 0, max_y = 0;
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    if (data[(y * bmp.Width + x) * 4 + 3] > 0)
                    {
                        min_x = Math.Min(min_x, x);
                        min_y = Math.Min(min_y, y);
                        max_x = Math.Max(max_x, x);
                        max_y = Math.Max(max_y, y);
                    }
                }
            }

            if (min_x > max_x || min_y > max_y || max_x == 0 || max_y == 0) return null;

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
                    int _y_lim = Math.Min(Math.Max((int)((y + 1) * height) + min_y, (int)(y * height) + min_y + 1), max_y + 1);
                    for (int _x = (int)(x * width) + min_x; _x < _x_lim; _x++) {
                        for (int _y = (int)(y * height) + min_y; _y < _y_lim; _y++) {
                            if (data[(_y * bmp.Width + _x) * 4 + 3] > 0) {
                                sensor_field[x, y] = true;
                                break;
                            }
                        }
                        if (sensor_field[x, y]) break;
                    }
                }
            }
            return sensor_field;
        }

        void drawen() {
            if (perceptron == null) return;
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            bool[,] sensor_field = get_sensor_field((Bitmap)pictureBox1.Image, sensor_field_size);
            if (sensor_field == null) {
                empty_picture = true;
                return;
            }
            empty_picture = false;

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

        private void add_to_study_set_button_Click(object sender, EventArgs e) {
            if (empty_picture) return;
            if (!study_set.ContainsKey(textBox1.Text[0])) study_set.Add(textBox1.Text[0], new List<Bitmap>());
            study_set[textBox1.Text[0]].Add(new Bitmap((Bitmap)pictureBox1.Image));
            viewStudySetToolStripMenuItem.Enabled = true;
            clearToolStripMenuItem.Enabled = true;
            createToolStripMenuItem.Enabled = true;
            createToolStripMenuItem.Enabled = _perceptron_ == null;
        }

        private void viewStudySetToolStripMenuItem_Click(object sender, EventArgs e) {
            studySetViewer.remove_button_enable = true;
            studySetViewer.ShowDialog();
            if (study_set.Count == 0) {
                viewStudySetToolStripMenuItem.Enabled = false;
                clearToolStripMenuItem.Enabled = false;
                createToolStripMenuItem.Enabled = false;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e) {
            study_set.Clear();
            viewStudySetToolStripMenuItem.Enabled = false;
            clearToolStripMenuItem.Enabled = false;
            createToolStripMenuItem.Enabled = false;
        }

        private void createPerceptronToolStripMenuItem_Click(object sender, EventArgs e) {
            parametersSeter.ShowDialog();
            if (parametersSeter.ok_presed) {
                var parameters = parametersSeter.parameters;
                sensor_field_size = new Size(parameters.sinaps_field_width, parameters.sinaps_field_height);
                uint[] Neuron_layers_sizes = new uint[1 + parameters.hidden_layers_count + 1];
                Neuron_layers_sizes[0] = (uint)(parameters.sinaps_field_width * parameters.sinaps_field_height);
                for (int _i = 1; _i <= parameters.hidden_layers_count; _i++) {
                    Neuron_layers_sizes[_i] = (uint)parameters.hidden_layer_size;
                }
                Neuron_layers_sizes[parameters.hidden_layers_count + 1] = (uint)study_set.Count();
                perceptron = new Perceptron(Neuron_layers_sizes);

                perceptron_studied_leters = new char[study_set.Count];
                int paterns_count = 0;
                foreach (var pair in study_set) {
                    paterns_count += pair.Value.Count;
                }
                Perceptron.Patern[] paterns = new Perceptron.Patern[paterns_count];
                int i = 0;
                int leter_number = 0;
                foreach (var pair in study_set) {
                    double[] outputs = new double[study_set.Count];
                    outputs[leter_number] = 1;
                    perceptron_studied_leters[leter_number] = pair.Key;
                    leter_number++;
                    foreach (Bitmap bmp in pair.Value) {
                        bool[,] sensor_field = get_sensor_field(bmp, sensor_field_size);
                        if (sensor_field != null)
                        {
                            Perceptron.Patern patern = new Perceptron.Patern();
                            patern.inputs = new double[Neuron_layers_sizes[0]];
                            int j = 0;
                            foreach (bool obj in sensor_field) {
                                patern.inputs[j++] = obj ? 1 : 0;
                            }
                            patern.outputs = outputs;
                            paterns[i] = patern;
                        }
                        i++;
                    }
                }
                perceptron.study(paterns, parameters.eps);

                cleanToolStripMenuItem.Enabled = true;
                drawen();

                MessageBox.Show("Perceptron created for " + perceptron.Epoch + " Epochs\n\rwith eps = " + parameters.eps);
            }
        }

        private void cleanToolStripMenuItem_Click(object sender, EventArgs e) {
            perceptron = null;
            perceptron_studied_leters = null;
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
        }

        private void identify_picture_button_Click(object sender, EventArgs e) {
            bool[,] sensor_field = get_sensor_field((Bitmap)pictureBox1.Image, sensor_field_size);
            if (sensor_field != null) {
                double[] inputs = new double[sensor_field_size.Width * sensor_field_size.Height];
                int j = 0;
                foreach (bool obj in sensor_field) {
                    inputs[j++] = obj ? 1 : 0;
                }
                perceptron.set_input(inputs);
                var outputs = perceptron.get_output();
                int index_of_max = 0;
                for (j = 0; j < outputs.Length; j++) {
                    if (outputs[index_of_max] < outputs[j]) index_of_max = j;
                }
                MessageBox.Show("It is symbol   " + perceptron_studied_leters[index_of_max]);
            }
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
