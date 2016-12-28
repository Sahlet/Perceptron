using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    public partial class StudySetViewer : Form {
        public class func {
            public Dictionary<char, List<Bitmap>> study_set;
            public char ch;
            public Bitmap bmp;
            public func(Dictionary<char, List<Bitmap>> study_set, char ch, Bitmap bmp) {
                this.study_set = study_set;
                this.ch = ch;
                this.bmp = bmp;
            }

            public void dell(object sender, EventArgs e) {
                study_set[ch].Remove(bmp);
                if (study_set[ch].Count == 0) study_set.Remove(ch);
            }
        }

        List<func> funks_holder;
        private Dictionary<char, List<Bitmap>> study_set;
        public StudySetViewer(Dictionary<char, List<Bitmap>> study_set) {
            InitializeComponent();
            this.study_set = study_set;
            funks_holder = new List<func>();
        }

        private void StudySetViewer_Load(object sender, EventArgs e) {
            int height = 0;
            foreach (var pare in study_set) {
                foreach (Bitmap bmp in pare.Value) {
                    Panel row = new Panel();
                    row.Margin = new Padding(5, 0, 5, 0);
                    row.Location = new Point(0, height);
                    row.MinimumSize = new Size(50, 50);
                    {
                        Panel left = new Panel();
                        left.Dock = DockStyle.Left;
                        left.Size = new Size(20, 0);
                        left.Margin = new Padding(0, 0, 5, 0); {
                            Label leter = new Label();
                            leter.Text = pare.Key.ToString();
                            leter.Dock = DockStyle.Top;
                            leter.Margin = new Padding(0, 0, 0, 5);
                            Button remove = new Button();
                            remove.Text = "remove";
                            remove.Dock = DockStyle.Top;
                            func deleter = new func(study_set, pare.Key, bmp);
                            funks_holder.Add(deleter);
                            remove.Click += new EventHandler(deleter.dell);
                        }

                        PictureBox image = new PictureBox();
                        image.Image = bmp;
                        image.Size = image.Image.Size;
                        image.Dock = DockStyle.Fill;

                        row.Size = new Size(left.Size.Width + (left.Margin.Left + left.Margin.Right) + image.Image.Width, image.Image.Height);
                        row.Controls.Add(left);
                        row.Controls.Add(image);
                    }
                    height += row.Size.Height + 10;
                    Controls.Add(row);
                }
            }
        }
    }
}
