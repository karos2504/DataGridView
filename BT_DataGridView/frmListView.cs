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
    public partial class frmListView : Form
    {
        List<Employee> employees;
        public frmListView()
        {
            InitializeComponent();
        }

        private void frmListView_Load(object sender, EventArgs e)
        {
            employees = new List<Employee>();
            employees.Add(new Employee() { ID = "NV001", Name = "Nguyễn Thị Thu Hiền", Salary = 8500000 });
            dgvEmployee.DataSource = employees;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEmployee employeeForm = new frmEmployee();
            if (employeeForm.ShowDialog() == DialogResult.OK)
            {
                string newEmployeeID = employeeForm.EmployeeData.ID;
                var existingEmployee = employees.FirstOrDefault(emp => emp.ID == newEmployeeID);

                if (existingEmployee != null)
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    employees.Add(employeeForm.EmployeeData);
                    dgvEmployee.DataSource = null;
                    dgvEmployee.DataSource = employees;
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvEmployee.SelectedRows[0].Index;
                Employee selectedEmployee = employees[selectedIndex];

                frmEmployee employeeForm = new frmEmployee
                {
                    EmployeeData = selectedEmployee
                };

                if (employeeForm.ShowDialog() == DialogResult.OK)
                {
                    string updatedEmployeeID = employeeForm.EmployeeData.ID;
                    var existingEmployee = employees.FirstOrDefault(emp => emp.ID == updatedEmployeeID && emp != selectedEmployee);

                    if (existingEmployee != null)
                    {
                        MessageBox.Show("Mã nhân viên này đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        dgvEmployee.DataSource = null;
                        dgvEmployee.DataSource = employees;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvEmployee.SelectedRows[0].Index;
                employees.RemoveAt(selectedIndex);

                dgvEmployee.DataSource = null;
                dgvEmployee.DataSource = employees;

                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
