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
        private Dictionary<char, List<Bitmap>> study_set;
        public StudySetViewer(Dictionary<char, List<Bitmap>> study_set) {
            InitializeComponent();
            this.study_set = study_set;
        }

        private void StudySetViewer_Load(object sender, EventArgs e) {
            foreach (var obj in study_set) {
                foreach (var list in obj.Value) {
                    //button remove
                }
            }
        }
    }
}
