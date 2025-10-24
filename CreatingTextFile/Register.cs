using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CreatingTextFile
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentNo = txtStudentNo.Text;
            string lastName = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string mi = txtMI.Text;
            string age = txtAge.Text;
            string program = cmbProgram.Text;
            string gender = cmbGender.Text;
            string birthday = dtpBirthday.Text;
            string contact = txtContact.Text;

            FrmStudentRecord recordForm = new FrmStudentRecord();
            recordForm.AddStudentRecord(studentNo, lastName, firstName, mi, age, program, gender, birthday, contact);
            this.Hide();
            recordForm.ShowDialog();
            this.Show();

            txtStudentNo.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMI.Clear();
            txtAge.Clear();
            cmbProgram.SelectedIndex = -1;
            cmbGender.SelectedIndex = -1;
            dtpBirthday.Value = DateTime.Now;
            txtContact.Clear();

        }

        private void Register_Load(object sender, EventArgs e)
        {
            cmbProgram.Items.Add("BS Information Technology");
            cmbProgram.Items.Add("BS Computer Science");
            cmbProgram.Items.Add("BS Computer Engineering");

            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");
            cmbGender.Items.Add("Prefer not to say");

            cmbProgram.SelectedIndex = 0; 
            cmbGender.SelectedIndex = 0;
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            FrmStudentRecord recordForm = new FrmStudentRecord();
            this.Hide();
            recordForm.ShowDialog();
            this.Show();
        }
    }
    }
