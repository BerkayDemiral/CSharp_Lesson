using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int grade1, grade2, grade3, average, passingGrade;
            grade1 = Convert.ToInt32(txtGrade1.Text);
            grade2 = Convert.ToInt32(txtGrade2.Text);
            grade3 = Convert.ToInt32(txtGrade3.Text);
            passingGrade = Convert.ToInt32(txtPassingGrade.Text);

            average = (grade1+grade2+grade3)/3;

            if (average >= passingGrade)
            {
                txtResult.Text = average.ToString();
                txtResult.BackColor = Color.Green;
                txtResult.ForeColor = Color.White;
                MessageBox.Show("Congratulations! You passed.");
            }
            else
            {
                txtResult.Text = average.ToString();
                txtResult.BackColor = Color.Red;
                txtResult.ForeColor = Color.White;
                MessageBox.Show("Sorry, you failed. Try again.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtGrade1.Clear();
            txtGrade2.Clear();
            txtGrade3.Clear();
            txtResult.Clear();
            txtPassingGrade.Clear();
            txtResult.BackColor = Color.White;
        }
    }
}
