using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace PhoneDirectory
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable table;

        public Form1()
        {
            InitializeComponent();

            txtPhone.KeyPress += TxtPhone_KeyPress;
            txtPhone.MaxLength = 10;
            dgvContacts.CellClick += dgvContacts_CellClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadContacts();
            CountContacts();
        }

        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidateFields()
        {
            if (txtName.Text.Trim() == "" || txtLastname.Text.Trim() == "" || txtPhone.Text.Trim() == "")
            {
                MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!long.TryParse(txtPhone.Text, out _) || txtPhone.Text.Length != 10)
            {
                MessageBox.Show("Please enter a valid numeric phone number without country code.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtLastname.Clear();
            txtPhone.Clear();
            txtName.Focus();
        }

        private void LoadContacts()
        {
            using (var conn = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Initial Catalog=dbContact;Integrated Security=True"))
            {
                using (var adapter = new SqlDataAdapter("SELECT * FROM Contacts", conn))
                {
                    table = new DataTable();
                    conn.Open();
                    adapter.Fill(table);
                    dgvContacts.DataSource = table;
                }
            }
        }

        private bool IsPhoneExists(string phone, int? idToExclude = null)
        {
            bool exists = false;
            string query = "SELECT COUNT(*) FROM Contacts WHERE Phone = @Phone";

            if (idToExclude.HasValue)
                query += " AND Id <> @Id";

            using (var conn = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Initial Catalog=dbContact;Integrated Security=True"))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Phone", phone);
                if (idToExclude.HasValue)
                {
                    cmd.Parameters.AddWithValue("@Id", idToExclude.Value);
                }

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                exists = count > 0;
            }

            return exists;
        }


        private void CountContacts()
        {
            lblShow.Text = $"There are {dgvContacts.Rows.Count - 1} contacts in the phone directory";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            if (IsPhoneExists(txtPhone.Text))
            {
                MessageBox.Show("This phone number already exists in the directory.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO Contacts(Name, Lastname, Phone) VALUES (@Name, @Lastname, @Phone)";
            using (conn = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Initial Catalog=dbContact;Integrated Security=True"))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Lastname", txtLastname.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadContacts();
            CountContacts();
            MessageBox.Show($"{txtName.Text} {txtLastname.Text} has been added.", "Contact Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            int currentId = (int)dgvContacts.CurrentRow.Cells[0].Value;

            if (IsPhoneExists(txtPhone.Text, currentId))
            {
                MessageBox.Show("This phone number already exists in the directory.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Contacts SET Name = @Name, Lastname = @Lastname, Phone = @Phone WHERE Id = @Id";
            using (conn = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Initial Catalog=dbContact;Integrated Security=True"))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Lastname", txtLastname.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Id", dgvContacts.CurrentRow.Cells[0].Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadContacts();
            CountContacts();
            MessageBox.Show($"{txtName.Text} {txtLastname.Text} has been updated.", "Contact Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvContacts.CurrentRow == null || dgvContacts.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a contact first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = dgvContacts.CurrentRow.Cells[1].Value.ToString();
            string lastname = dgvContacts.CurrentRow.Cells[2].Value.ToString();

            string query = "DELETE FROM Contacts WHERE Id = @Id";
            using (conn = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Initial Catalog=dbContact;Integrated Security=True"))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", dgvContacts.CurrentRow.Cells[0].Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadContacts();
            CountContacts();
            MessageBox.Show($"{name} {lastname} has been deleted.", "Contact Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dv = table.DefaultView;
                dv.RowFilter = $"Name LIKE '{txtSearch.Text}%'";
                dgvContacts.DataSource = dv;
            }
            catch (Exception)
            {
                MessageBox.Show("Contact not found.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dgvContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtName.Text = dgvContacts.Rows[e.RowIndex].Cells["Name"].Value.ToString().Trim();
                txtLastname.Text = dgvContacts.Rows[e.RowIndex].Cells["Lastname"].Value.ToString().Trim();
                txtPhone.Text = dgvContacts.Rows[e.RowIndex].Cells["Phone"].Value.ToString().Trim();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            int StartCol = 1;
            int StartRow = 1;
            for (int j = 0; j < dgvContacts.ColumnCount; j++)
            {
                Range myRange = (Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = dgvContacts.Columns[j].HeaderText;
            }
            StartRow++;
            for (int i = 0; i < dgvContacts.RowCount; i++)
            {
                for (int j = 0; j < dgvContacts.ColumnCount; j++)
                {
                    Range myRange = (Range)sheet1.Cells[StartRow + i, StartCol + j];
                    myRange.Value2 = dgvContacts.Rows[i].Cells[j].Value;
                    myRange.EntireColumn.AutoFit();
                }
            }
        }
    }
}