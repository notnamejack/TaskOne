using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskOne
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
            openFileDialog1.FileName = "";



        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, textBox1.Text);
            saveFileDialog1.FileName = "";
            MessageBox.Show("Файл сохранен");
        }

     
        private void Button3_Click(object sender, EventArgs e)
        {
            int n = textBox1.Text.Length;
            textBox1.Text = Regex.Replace(textBox1.Text, @"[-.?!)(,:;]", "");
            MessageBox.Show("Удалено " + (n - textBox1.Text.Length) + " знака припенная");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string[] word = textBox1.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(textBox2.Text);
            textBox1.Text = Regex.Replace(textBox1.Text, @"\b[\w]{0,"+n+@"}\b", string.Empty, RegexOptions.Compiled);
            textBox1.Text = Regex.Replace(textBox1.Text, @"\s+", " ");

            string[] words = textBox1.Text.Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries);

            MessageBox.Show("Удалено " +(word.Length - words.Length)+ " слов, меньше " + n);
        }
    }
}
