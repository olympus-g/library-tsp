using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Visitor_Forms
{
    public partial class AddVisitor : Form
    {
        public AddVisitor()
        {
            InitializeComponent();
        }

        private void AddVisitor_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text) ||
                            string.IsNullOrWhiteSpace(txtName.Text) ||
                            string.IsNullOrWhiteSpace(txtEGN.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (!long.TryParse(txtBarcode.Text, out _))
            {
                MessageBox.Show("Barcode must be a number.");
                return;
            }

            if (txtEGN.Text.Length != 10 || !long.TryParse(txtEGN.Text, out _))
            {
                MessageBox.Show("EGN must be exactly 10 digits.");
                return;
            }

            bool exists = GlobalData.AllVisitors.Any(v => v.Barcode == txtBarcode.Text);
            if (exists)
            {
                MessageBox.Show("A visitor with this Barcode already exists!");
                return;
            }

            try
            {
                Visitor newVisitor = new Visitor();
                newVisitor.Barcode = txtBarcode.Text; 
                newVisitor.Names = txtName.Text;
                newVisitor.EGN = txtEGN.Text;

                DatabaseHelper.AddVisitorToDb(newVisitor);

                GlobalData.AllVisitors.Add(newVisitor);

                MessageBox.Show("Visitor added successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving visitor: " + ex.Message);
            }
        }
    }
}
