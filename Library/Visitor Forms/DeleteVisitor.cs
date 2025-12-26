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
    public partial class DeleteVisitor : Form
    {
        private Visitor _currentVisitor = null;

        public DeleteVisitor()
        {
            InitializeComponent();
        }

        private void DeleteVisitor_Load(object sender, EventArgs e)
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
            txtName.ReadOnly = true;
            txtEGN.ReadOnly = true;

            txtBarcode.Clear();
            txtName.Clear();
            txtEGN.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_currentVisitor == null)
            {
                MessageBox.Show("Please select a visitor first.");
                return;
            }

            bool hasActiveLoans = GlobalData.AllLoans.Any(loan => loan.VisitorBarcode == _currentVisitor.Barcode);

            if (hasActiveLoans)
            {
                MessageBox.Show(
                    $"Cannot delete visitor '{_currentVisitor.Names}'.\n\nThey currently have books borrowed! You must return their books before deleting their profile.",
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete visitor '{_currentVisitor.Names}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.DeleteVisitorFromDb(_currentVisitor.Barcode);
                    GlobalData.AllVisitors.Remove(_currentVisitor);

                    cmbSelectVisitor.SelectedIndex = -1;

                    MessageBox.Show("Visitor deleted successfully.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting visitor: " + ex.Message);
                }
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
