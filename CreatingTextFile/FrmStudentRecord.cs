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
    public partial class FrmStudentRecord : Form
    {
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register regForm = new Register();
            this.Hide();
            regForm.ShowDialog();
            this.Show();
        }
        public FrmStudentRecord()
        {
            InitializeComponent();
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                if (!string.IsNullOrEmpty(path))
                {
                    using (StreamReader streamReader = File.OpenText(path))
                    {
                        string _getText;
                        lvShowText.Items.Clear();

                        while ((_getText = streamReader.ReadLine()) != null)
                        {
                            Console.WriteLine(_getText);
                            lvShowText.Items.Add(_getText);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No file selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmStudentRecord_Load(object sender, EventArgs e)
        {
            lvShowText.View = View.Details;
            lvShowText.Columns.Add("Student No", 100);
            lvShowText.Columns.Add("Last Name", 100);
            lvShowText.Columns.Add("First Name", 100);
            lvShowText.Columns.Add("M.I", 50);
            lvShowText.Columns.Add("Age", 50);
            lvShowText.Columns.Add("Program", 120);
            lvShowText.Columns.Add("Gender", 70);
            lvShowText.Columns.Add("Birthday", 120);
            lvShowText.Columns.Add("Contact", 100);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Uploaded!", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lvShowText.Items.Clear();
        }
        public void AddStudentRecord(string studentNo, string lastName, string firstName,string mi, string age, string program,string gender, string birthday, string contact)
        {
            ListViewItem item = new ListViewItem(studentNo);
            item.SubItems.Add(lastName);
            item.SubItems.Add(firstName);
            item.SubItems.Add(mi);
            item.SubItems.Add(age);
            item.SubItems.Add(program);
            item.SubItems.Add(gender);
            item.SubItems.Add(birthday);
            item.SubItems.Add(contact);

            lvShowText.Items.Add(item);
        }
    }
}
