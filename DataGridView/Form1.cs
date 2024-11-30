using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridView
{
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        List<Student> students;
        private void frmStudent_Load(object sender, EventArgs e)
        {
            students = new List<Student>();
            students.Add(new Student() { Id = 1, Name = "A", Age = 10 });
            students.Add(new Student() { Id = 2, Name = "B", Age = 11 });
            students.Add(new Student() { Id = 3, Name = "C", Age = 12 });
            dgvStudents.DataSource = students;
        }

        int vt;
        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            vt = e.RowIndex;
            DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
            txtID.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtAge.Text = row.Cells[2].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student() { Id = int.Parse(txtID.Text), Name = txtName.Text, Age = int.Parse(txtAge.Text) };
            students.Add(student);
            dgvStudents.DataSource = new BindingList<Student>(students);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (vt == -1)
            { return; }
            students[vt] = new Student()
            {
                Id = int.Parse(txtID.Text),
                Name = txtName.Text,
                Age = int.Parse(txtAge.Text)
            };
            dgvStudents.DataSource = new BindingList<Student>(students);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (vt == -1) { return; }
            students.RemoveAt(vt);
            dgvStudents.DataSource = new BindingList<Student>(students);
        }
    }
}
