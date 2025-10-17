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
            try
            {
                string studentNo = txtStudentNo.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string firstName = txtFirstName.Text.Trim();
                string mi = txtMI.Text.Trim();
                string program = cmbProgram.Text.Trim();
                string gender = cmbGender.Text.Trim();
                string age = txtAge.Text.Trim();
                string birthday = dtpBirthday.Value.ToString("yyyy-MM-dd");
                string contact = txtContactNo.Text.Trim();

                string folderPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\SAVED FILES"));
                Directory.CreateDirectory(folderPath);
                string filePath = Path.Combine(folderPath, studentNo + ".txt");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"Student No.: {studentNo}");
                    writer.WriteLine($"Full Name: {lastName}, {firstName}, {mi}");
                    writer.WriteLine($"Program: {program}");
                    writer.WriteLine($"Gender: {gender}");
                    writer.WriteLine($"Age: {age}");
                    writer.WriteLine($"Birthday: {birthday}");
                    writer.WriteLine($"Contact No.: {contact}");
                }

                MessageBox.Show("Registration saved successfully!\n\nSaved to:\n" + filePath,
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving registration:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
    }
