using System;
using System.IO;
using System.Windows.Forms;

namespace TeorAvto_Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            codeTextBox.Text = File.ReadAllText(Path.Combine(Application.StartupPath, "code.txt"));
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                codeTextBox.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void performButton_Click(object sender, EventArgs e)
        {
            LexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzer();

            keywordsDataGridView.Rows.Clear();

            int rowsCount = Max(
                lexicalAnalyzer.Keywords.Count,
                lexicalAnalyzer.Separators.Count,
                lexicalAnalyzer.Identifiers.Count,
                lexicalAnalyzer.Literals.Count);

            for (int i = 0; i < rowsCount; i++)
            {
                keywordsDataGridView.Rows.Add();
            }

            for (int i = 0; i < lexicalAnalyzer.Keywords.Count; i++)
            {
                keywordsDataGridView.Rows[i].Cells[0].Value = lexicalAnalyzer.Keywords[i];
            }

            for (int i = 0; i < lexicalAnalyzer.Separators.Count; i++)
            {
                keywordsDataGridView.Rows[i].Cells[1].Value = lexicalAnalyzer.Separators[i];
            }


            try
            {
                lexemClassificationDataGridView.DataSource = lexicalAnalyzer.Analyze(codeTextBox.Text);

                for (int i = 0; i < lexicalAnalyzer.Identifiers.Count; i++)
                {
                    keywordsDataGridView.Rows[i].Cells[2].Value = lexicalAnalyzer.Identifiers[i];
                }

                for (int i = 0; i < lexicalAnalyzer.Literals.Count; i++)
                {
                    keywordsDataGridView.Rows[i].Cells[3].Value = lexicalAnalyzer.Literals[i];
                }
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message);
            }
        }

        private int Max(params int[] values)
        {
            int max = int.MinValue;

            foreach (var value in values)
            {
                if (value > max)
                {
                    max = value;
                }
            }

            return max;
        }
    }
}
