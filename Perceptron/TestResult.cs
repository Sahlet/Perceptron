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
    public partial class TestResult : Form {
        StudySetViewer unsolvedSetViewer, errorSetViewer;

        public TestResult(int tests_number, Dictionary<char, List<Bitmap>> unsolved_test_set, Dictionary<char, List<Bitmap>> error_test_set) {
            if (unsolved_test_set == null || error_test_set  == null || tests_number < 1) throw new Exception();

            int unsolved_tests_count = 0;
            foreach (var list in unsolved_test_set.Values) {
                unsolved_tests_count += list.Count;
            }

            int error_tests_count = 0;
            foreach (var list in error_test_set.Values) {
                error_tests_count += list.Count;
            }

            int solved_tests_count = tests_number - (unsolved_tests_count + error_tests_count);

            if (solved_tests_count < 0) throw new Exception();

            InitializeComponent();

            label5.Text = tests_number.ToString();
            label6.Text = unsolved_tests_count.ToString();
            label7.Text = (unsolved_tests_count / (double)(tests_number)).ToString();
            label8.Text = error_tests_count.ToString();
            label9.Text = (error_tests_count / (double)(tests_number)).ToString();

            if (unsolved_tests_count > 0) {
                unsolvedSetViewer = new StudySetViewer(unsolved_test_set);
                unsolvedSetViewer.remove_button_enable = false;
                unsolvedSetViewer.Text = "Unsolved Set";
            } else button1.Visible = false;

            if (error_tests_count > 0) {
                errorSetViewer = new StudySetViewer(error_test_set);
                errorSetViewer.remove_button_enable = false;
                errorSetViewer.Text = "Error Set";
            } else button2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (unsolvedSetViewer != null) unsolvedSetViewer.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) {
            if (errorSetViewer != null) errorSetViewer.ShowDialog();
        }
    }
}
