using Laba2.Arrays;
using Laba2.Loops;
using System;
using System.Windows.Forms;

namespace Laba2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var branchingForm = new BranchingForm();
            branchingForm.Show();
            Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var loopsForm = new LoopsForm();
            loopsForm.Show();
            Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var arraysForm = new ArraysForm();
            arraysForm.Show();
            Hide();
        }
    }
}
