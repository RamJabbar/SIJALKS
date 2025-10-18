using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIJALKS
{
    public partial class FormMasterStudent : Form
    {
        private DataBaseDataContext db = new DataBaseDataContext();
        int selected_id = -1;

        public FormMasterStudent()
        {
            InitializeComponent();
        }
        void showDatacbo()
        {
            var data = new List<string>();
            data.Add("Male");
            data.Add("Female");

            cboGender.DataSource = data;
        }
        void showData()
        {
            dgvData.Columns.Clear();
            var student = db.Student_Tables.Where(x => x.Name.Contains(tbSearch.Text))
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Class,
                    x.Gender,
                    x.Adress,
                    x.Phone,

                });

            dgvData.DataSource = student;
        }

        private void FormMasterStudent_Load(object sender, EventArgs e)
        {
            showData();
            showDatacbo();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            showData();
        }

        void clearFields()
        {
            tbName.Text = "";
            tbAddress.Text = "";
            tbPhone.Text = "";
            tbClass.Text = "";
            cboGender.Text = "Male";



        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || tbAddress.Text == "" || tbPhone.Text == ""
              || tbClass.Text == "")
            {
                MessageBox.Show("All fields must be filled");
                return;
            }

            var student = new Student_Table();
            student.Name = tbName.Text;
            student.Adress = tbAddress.Text;
            student.Phone = tbPhone.Text;
            student.Class = tbClass.Text;
            student.Gender = cboGender.Text;

            db.Student_Tables.InsertOnSubmit(student);
            db.SubmitChanges();
            clearFields();
            showData();
            MessageBox.Show("Data Successfully Inserted");
            selected_id = -1;
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selected_id = (int)dgvData.Rows[e.RowIndex].Cells["id"].Value;
                tbName.Text = dgvData.Rows[e.RowIndex].Cells["name"].Value.ToString();
                tbAddress.Text = dgvData.Rows[e.RowIndex].Cells["Adress"].Value.ToString();
                tbPhone.Text = dgvData.Rows[e.RowIndex].Cells["phone"].Value.ToString();
                tbClass.Text = dgvData.Rows[e.RowIndex].Cells["class"].Value.ToString();
                cboGender.Text = dgvData.Rows[e.RowIndex].Cells["gender"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selected_id == -1)
            {
                MessageBox.Show("Please select a row to update");
                return;
            }
            if (tbName.Text == "" || tbAddress.Text == "" || tbPhone.Text == ""
               || tbClass.Text == "")
            {
                MessageBox.Show("All fields must be filled");
                return;
            }

            var student = db.Student_Tables.Where(x => x.Id == selected_id).FirstOrDefault();
            student.Name = tbName.Text;
            student.Adress = tbAddress.Text;
            student.Phone = tbPhone.Text;
            student.Class = tbClass.Text;
            student.Gender = cboGender.Text;

            db.SubmitChanges();
            clearFields();
            showData();
            MessageBox.Show("Data successfully updated");
            selected_id = -1;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selected_id == -1)
            {
                MessageBox.Show("Please select a row to Delete");
                return;
            }
            var student = db.Student_Tables.Where(x => x.Id == selected_id).FirstOrDefault();
            db.Student_Tables.DeleteOnSubmit(student);
            db.SubmitChanges();
            clearFields();
            showData();
            MessageBox.Show("Data successfully Deleted");
            selected_id = -1;

        }
    }
}






