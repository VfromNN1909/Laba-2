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
            // создаем объект BranchingForm
            var branchingForm = new BranchingForm();
            // показываем форму
            branchingForm.Show();
            // прячем эту
            Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // создаем объект LoopsForm
            var loopsForm = new LoopsForm();
            // показываем форму
            loopsForm.Show();
            Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // создаем объект ArraysForm
            var arraysForm = new ArraysForm();
            // показываем форму
            arraysForm.Show();
            Hide();
        }
    }
}
