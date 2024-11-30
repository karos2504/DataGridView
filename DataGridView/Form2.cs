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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public delegate void delPassData(TextBox text);
        private void btnSend_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            delPassData del = new delPassData(frm.funData);
            del(this.txtName);
            frm.Show();
        }
    }
}
