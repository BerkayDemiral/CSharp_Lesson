using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermFinalCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (txtMidterm.Text.Trim() == "" || txtFinal.Text.Trim() == "" || txtBellCurve.Text.Trim() == "")
            {
                MessageBox.Show("All Fields Must Be Filled Out!", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                double midterm, final, result, bellCurve;
                midterm = Convert.ToDouble(txtMidterm.Text);
                final = Convert.ToDouble(txtFinal.Text);
                bellCurve = Convert.ToDouble(txtBellCurve.Text);

                if (midterm < 0 || midterm > 100 || final < 0 || final > 100 || bellCurve < 0 || bellCurve > 100)
                {
                    MessageBox.Show("Please Enter Values Between 0 and 100.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtResult.Clear();
                    txtResult.BackColor = Color.White;
                    return;
                }

                result = (midterm * 0.4) + (final * 0.6);
                txtResult.Text = Math.Round(result, 2).ToString();

                if (result >= bellCurve)
                {
                    txtResult.BackColor = Color.Green;
                    txtResult.ForeColor = Color.White;
                }
                else
                {
                    txtResult.BackColor = Color.Red;
                    txtResult.ForeColor = Color.White;
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Please Enter Numbers Only!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMidterm.Clear();
            txtFinal.Clear();
            txtResult.Clear();
            txtResult.BackColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtResult.ReadOnly = true;
        }
    }
}
