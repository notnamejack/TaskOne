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
            textBox1.Text += "Загружен файл: \r\n" + filename + "\r\n";
            ListFile.files.Add(new File(filename, fileText));
            openFileDialog1.FileName = "";



        }

        private void Button2_Click(object sender, EventArgs e)
        {
            foreach(File file in ListFile.files)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(filename, file.fileText);
                saveFileDialog1.FileName = "";
                MessageBox.Show("Файл " + filename + " сохранен");
            }
           
        }

     
        private void Button3_Click(object sender, EventArgs e)
        {
            foreach(File file in ListFile.files)
            {
                int n = file.fileText.Length;

                file.fileText = Regex.Replace(file.fileText, @"[-.?!)(,:;]", "");

                MessageBox.Show("В файле " + file.filename + " удалено " + (n - file.fileText.Length) + " знака припенная");
            }
           
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            foreach(File file in ListFile.files)
            {
                string[] word = file.fileText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int n = int.Parse(textBox2.Text);

                file.fileText = Regex.Replace(file.fileText, @"\b[\w]{0," + n + @"}\b", string.Empty, RegexOptions.Compiled);
                file.fileText = Regex.Replace(file.fileText, @"\s+", " ");

                string[] words = file.fileText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                MessageBox.Show("В файле " + file.filename + " удалено " + (word.Length - words.Length) + " слов, меньше " + n);
            }

            
        }
    }
}
