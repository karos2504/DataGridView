using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT_DataGridView
{
    public partial class frmEmployee : Form
    {
        public Employee EmployeeData { get; set; }

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            if (EmployeeData != null)
            {
                txtID.Text = EmployeeData.ID;
                txtName.Text = EmployeeData.Name;
                txtSalary.Text = EmployeeData.Salary.ToString();
            }
            else
            {
                txtID.Text = string.Empty;
                txtName.Text = string.Empty;
                txtSalary.Text = string.Empty;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtSalary.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                EmployeeData = new Employee
                {
                    ID = txtID.Text,
                    Name = txtName.Text,
                    Salary = int.Parse(txtSalary.Text)
                };
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
