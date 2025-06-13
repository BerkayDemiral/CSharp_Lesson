using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxMinFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            int number1, number2, number3, highest, lowest;
            number1 = Convert.ToInt32(txtNumber1.Text);
            number2 = Convert.ToInt32(txtNumber2.Text);
            number3 = Convert.ToInt32(txtNumber3.Text);

            // Find the highest number
            if (number1 > number2 && number1 > number3)
            {
                highest = number1;
            }
            else if (number2 > number1 && number2 > number3)
            {
                highest = number2;
            }
            else
            {
                highest = number3;
            }

            // Find the lowest number
            if (number1 < number2 && number1 < number3)
            {
                lowest = number1;
            }
            else if (number2 < number1 && number2 < number3)
            {
                lowest = number2;
            }
            else
            {
                lowest = number3;
            }

            // Display the results
            txtHighestNumber.Text = highest.ToString();
            txtLowestNumber.Text = lowest.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNumber1.Clear();
            txtNumber2.Clear();
            txtNumber3.Clear();
            txtHighestNumber.Clear();
            txtLowestNumber.Clear();
        }
    }
}
