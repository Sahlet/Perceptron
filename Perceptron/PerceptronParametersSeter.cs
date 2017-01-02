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
    public partial class PerceptronParametersSeter : Form {
        public class Parameters {
            public int sinaps_field_width = 16;
            public int sinaps_field_height = 16;
            public int hidden_layers_count = 1;
            public int hidden_layer_size = 10;
            public double eps = 0.005;

            public bool Equal(Parameters parameters) {
                if (parameters == null) return false;
                return
                parameters.sinaps_field_width == sinaps_field_width &&
                parameters.sinaps_field_height == sinaps_field_height &&
                parameters.hidden_layers_count == hidden_layers_count &&
                parameters.hidden_layer_size == hidden_layer_size &&
                parameters.eps == eps;
            }

            public Parameters get_copy() {
                Parameters parameters = new Parameters();
                parameters.sinaps_field_width = sinaps_field_width;
                parameters.sinaps_field_height = sinaps_field_height;
                parameters.hidden_layers_count = hidden_layers_count;
                parameters.hidden_layer_size = hidden_layer_size;
                parameters.eps = eps;
                return parameters;
            }
        }
        public Parameters parameters;
        public bool ok_presed = false;
        public PerceptronParametersSeter(StudySetViewer studySetViewer) {
            InitializeComponent();
            parameters = new Parameters();
            this.studySetViewer = studySetViewer;
        }

        private StudySetViewer studySetViewer;

        private void button1_Click(object sender, EventArgs e) {
            parameters.sinaps_field_width = Convert.ToInt32(sinaps_field_width.Value);
            parameters.sinaps_field_height = Convert.ToInt32(sinaps_field_height.Value);
            parameters.hidden_layers_count = Convert.ToInt32(hidden_layers_count.Value);
            parameters.hidden_layer_size = Convert.ToInt32(hidden_layer_size.Value);
            parameters.eps = (double)epsUpDown.Value;
            ok_presed = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            studySetViewer.remove_button_enable = false;
            studySetViewer.ShowDialog();
        }

        private void PerceptronParametersSeter_Load(object sender, EventArgs e) {
            ok_presed = false;
        }
    }
}
