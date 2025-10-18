using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIJALKS
{
    public partial class FormMasterTeacher : Form
    {
        DataBaseDataContext db = new DataBaseDataContext();
        int selected_id = -1;
        public FormMasterTeacher()
        {
            InitializeComponent();
        }

        void showDataCbo()
        {
            var data = new List<string>();
            data.Add("Male");
            data.Add("Female");

            cboGender.DataSource = data;
        }

        void showData()
        {
            dgvData.Columns.Clear();
            var teacher = db.Teacher_Tables.Where(x => x.Name.StartsWith(tbSearch.Text))
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Gender,
                    x.Adress,
                    x.Phone,
                    x.Subject,
                    x.Password
                });

            dgvData.DataSource = teacher;

        }

        private void FormMasterTeacher_Load(object sender, EventArgs e)
        {
            showData();
            showDataCbo();
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
            tbSubject.Text = "";
            tbPassword.Text = "";
            cboGender.Text = "Male";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || tbAddress.Text == "" || tbPhone.Text == ""
                || tbSubject.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("All fields must be filled");
                return;
            }
            var teacher = new Teacher_Table();
            teacher.Name = tbName.Text;
            teacher.Adress = tbAddress.Text;
            teacher.Phone = tbPhone.Text;
            teacher.Subject = tbSubject.Text;
            teacher.Password = tbPassword.Text;
            teacher.Gender = cboGender.Text;

            db.Teacher_Tables.InsertOnSubmit(teacher);
            db.SubmitChanges();
            clearFields();
            showData();
            MessageBox.Show("Data successfully Inserted");
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
                tbSubject.Text = dgvData.Rows[e.RowIndex].Cells["subject"].Value.ToString();
                tbPassword.Text = dgvData.Rows[e.RowIndex].Cells["password"].Value.ToString();
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
                || tbSubject.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("All fields must be filled");
                return;
            }

            var teacher = db.Teacher_Tables.Where(x => x.Id == selected_id).FirstOrDefault();
            teacher.Name = tbName.Text;
            teacher.Adress = tbAddress.Text;
            teacher.Phone = tbPhone.Text;
            teacher.Subject = tbSubject.Text;
            teacher.Password = tbPassword.Text;
            teacher.Gender = cboGender.Text;

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
                MessageBox.Show("Please select a row to delete");
                return;
            }

            var teacher = db.Teacher_Tables.Where(x => x.Id == selected_id).FirstOrDefault();
            db.Teacher_Tables.DeleteOnSubmit(teacher);
            db.SubmitChanges();
            clearFields();
            showData();
            MessageBox.Show("Data successfully deleted");
            selected_id = -1;
        }
    }
}

            