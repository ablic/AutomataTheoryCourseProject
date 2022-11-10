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
            LexemClassifier lexemClassifier = new LexemClassifier();

            keywordsDataGridView.Rows.Clear();

            int rowsCount = Max(
                lexemClassifier.Keywords.Count, 
                lexemClassifier.Separators.Count, 
                lexemClassifier.Identifiers.Count, 
                lexemClassifier.Literals.Count);

            for (int i = 0; i < rowsCount; i++)
            {
                keywordsDataGridView.Rows.Add();
            }

            for (int i = 0; i < lexemClassifier.Keywords.Count; i++)
            {
                keywordsDataGridView.Rows[i].Cells[0].Value = lexemClassifier.Keywords[i];
            }

            for (int i = 0; i < lexemClassifier.Separators.Count; i++)
            {
                keywordsDataGridView.Rows[i].Cells[1].Value = lexemClassifier.Separators[i];
            }


            try
            {
                var lexemes = lexicalAnalyzer.Analyze(codeTextBox.Text);
                var classification = lexemClassifier.Classify1(lexemes);

                lexicalAnalysisDataGridView.DataSource = lexemes;

                lexemClassificationDataGridView.DataSource = classification;

                for (int i = 0; i < lexemClassifier.Identifiers.Count; i++)
                {
                    keywordsDataGridView.Rows[i].Cells[2].Value = lexemClassifier.Identifiers[i];
                }

                for (int i = 0; i < lexemClassifier.Literals.Count; i++)
                {
                    keywordsDataGridView.Rows[i].Cells[3].Value = lexemClassifier.Literals[i];
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
