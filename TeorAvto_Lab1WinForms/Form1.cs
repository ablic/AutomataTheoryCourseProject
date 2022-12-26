using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TeorAvto_Lab
{
    public partial class Form1 : Form
    {
        private LexicalAnalyzer lexicalAnalyzer;
        private SyntacticalAnalyzer syntacticalAnalyzer;
        private string path;

        public Form1()
        {
            InitializeComponent();

            lexicalAnalyzer = new LexicalAnalyzer();
            syntacticalAnalyzer = new SyntacticalAnalyzer();

            codeTextBox.Text = "Dim a as integer\nb = 1\ndo while a < 10\n  b = b + a\nloop";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            keywordsListBox.Items.Clear();
            separatorsListBox.Items.Clear();

            foreach (string keyword in lexicalAnalyzer.Keywords)
                keywordsListBox.Items.Add(keyword);

            foreach (string separator in lexicalAnalyzer.Separators)
                separatorsListBox.Items.Add(separator);
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            path = openFileDialog1.FileName;
            codeTextBox.Text = "";

            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    while (!streamReader.EndOfStream)
                        codeTextBox.Text += streamReader.ReadLine() + "\n";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения файла.");
            }
        }

        private void performButton_Click(object sender, EventArgs e)
        {
            List<LexemeToken> lexemes;

            lexemClassificationDataGridView.Rows.Clear();
            identifiersListBox.Items.Clear();
            literalsListBox.Items.Clear();
            operationsDataGridView.Rows.Clear();

            // Лексический анализ
            try
            {
                using (StringReader stringReader = new StringReader(codeTextBox.Text))
                {
                    string line;

                    while ((line = stringReader.ReadLine()) != null)
                        lexicalAnalyzer.AnalyzeLine(line);
                }

                lexemes = lexicalAnalyzer.GetLexemes();
            }
            catch (Exception exeption)
            {
                MessageBox.Show("Лексическая ошибка.\n" + exeption.Message);
                return;
            }


            foreach (LexemeToken lexeme in lexemes)
                lexemClassificationDataGridView.Rows.Add(lexeme.Type, lexeme.Value);

            foreach (string identifier in lexicalAnalyzer.Identifiers)
                identifiersListBox.Items.Add(identifier);

            foreach (string literal in lexicalAnalyzer.Literals)
                literalsListBox.Items.Add(literal);

            // Синтаксический анализ
            try
            {
                syntacticalAnalyzer.Analyze(lexemes);
                MessageBox.Show("Синтаксические ошибки не обнаружены");
            }
            catch (SyntaxException exeption)
            {
                MessageBox.Show("Синтаксическая ошибка.\n" + exeption.Message);
                return;
            }

            foreach (var info in syntacticalAnalyzer.operations)
                operationsDataGridView.Rows.Add(info.Operation.Value, info.Operand1.Value, info.Operand2.Value, info.Result.Value);
        }
    }
}
