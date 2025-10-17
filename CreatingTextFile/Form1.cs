using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatingTextFile
{
    public partial class btnRegister : Form
    {
        public btnRegister()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string getInput = txtInput.Text;

            FrmFileName newForm = new FrmFileName();
            newForm.ShowDialog();

            string docPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\SAVED FILES"));
            Directory.CreateDirectory(docPath);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, FrmFileName.SetFileName)))
            {
                outputFile.WriteLine(getInput);
            }

            Console.WriteLine("Saved to: " + Path.Combine(docPath, FrmFileName.SetFileName));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.ShowDialog();
        }
    }
    }