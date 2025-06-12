using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductListWithDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductsDal products = new ProductsDal();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            DataArea.DataSource = products.Print();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            products.add(new Products
            {
                Name = txtProduct.Text,
                Stock = Convert.ToInt32(txtStock.Text),
                Price = Convert.ToInt32(txtPrice.Text),
            });
            DataArea.DataSource = products.Print();
            MessageBox.Show("Product Added!");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataArea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductUpdate.Text = DataArea.CurrentRow.Cells[1].Value.ToString();
            txtStockUpdate.Text = DataArea.CurrentRow.Cells[2].Value.ToString();
            txtPriceUpdate.Text = DataArea.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Products product = new Products()
            {
                Id = Convert.ToInt32(DataArea.CurrentRow.Cells[0].Value),
                Name = txtProductUpdate.Text,
                Stock = Convert.ToInt32(txtStockUpdate.Text),
                Price = Convert.ToInt32(txtPriceUpdate.Text)
            };
            products.update(product);
            DataArea.DataSource = products.Print();
            MessageBox.Show("Product Updated!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Products product = new Products()
            {
                Id = Convert.ToInt32(DataArea.CurrentRow.Cells[0].Value)
            };
            products.delete(product);
            DataArea.DataSource = products.Print();
            MessageBox.Show("Product Deleted!");
        }
    }
}
