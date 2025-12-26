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
    public partial class EditVisitor : Form
    {
        private Visitor _currentVisitor = null;

        public EditVisitor()
        {
            InitializeComponent();
        }

        private void EditVisitor_Load(object sender, EventArgs e)
        {
            cmbSelectVisitor.SelectedIndexChanged -= cmbSelectVisitor_SelectedIndexChanged;

            var displayList = GlobalData.AllVisitors.Select(v => new
            {
                DisplayText = $"{v.Names} (ID: {v.Barcode})",
                Value = v
            }).ToList();

            cmbSelectVisitor.DataSource = displayList;
            cmbSelectVisitor.DisplayMember = "DisplayText";
            cmbSelectVisitor.ValueMember = "Value";
            cmbSelectVisitor.SelectedIndex = -1;

            cmbSelectVisitor.SelectedIndexChanged += cmbSelectVisitor_SelectedIndexChanged;

            txtBarcode.ReadOnly = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_currentVisitor == null)
            {
                MessageBox.Show("Please select a visitor first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEGN.Text))
            {
                MessageBox.Show("Name and EGN cannot be empty.");
                return;
            }

            if (txtEGN.Text.Length != 10 || !long.TryParse(txtEGN.Text, out _))
            {
                MessageBox.Show("EGN must be valid (10 digits).");
                return;
            }

            try
            {
                _currentVisitor.Names = txtName.Text;
                _currentVisitor.EGN = txtEGN.Text;

                DatabaseHelper.UpdateVisitorInDb(_currentVisitor);

                MessageBox.Show("Visitor updated successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating visitor: " + ex.Message);
            }
        }

        private void cmbSelectVisitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectVisitor.SelectedIndex == -1) return;

            _currentVisitor = (Visitor)cmbSelectVisitor.SelectedValue;

            if (_currentVisitor != null)
            {
                txtBarcode.Text = _currentVisitor.Barcode;
                txtName.Text = _currentVisitor.Names;
                txtEGN.Text = _currentVisitor.EGN;
            }
        }
    }
}
