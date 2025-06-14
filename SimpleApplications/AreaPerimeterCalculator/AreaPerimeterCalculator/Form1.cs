using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaPerimeterCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            int length, width, result;

            if (!int.TryParse(txtLength.Text, out length) || length <= 0)
            {
                lblResult.Text = "Result: ";
                MessageBox.Show("Please enter a valid positive number for length.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLength.Focus();
                return;
            }

            if (!int.TryParse(txtWidth.Text, out width) || width <= 0)
            {
                lblResult.Text = "Result: ";
                MessageBox.Show("Please enter a valid positive number for width.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtWidth.Focus();
                return;
            }

            if (rbArea.Checked)
            {
                result = length * width;
                lblResult.Text = "Result: " + result.ToString();
            }
            else if (rbPerimeter.Checked)
            {
                result = 2 * (length + width);
                lblResult.Text = "Result: " + result.ToString();
            }
            else
            {
                MessageBox.Show("Please select an operation (Area or Perimeter).", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
