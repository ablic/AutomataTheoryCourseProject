
namespace TeorAvto_Lab
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.codeTextBox = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.performButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lexemClassificationTabPage = new System.Windows.Forms.TabPage();
            this.keywordsDataGridView = new System.Windows.Forms.DataGridView();
            this.Keywords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Separators = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identifiers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Literals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lexemClassificationDataGridView = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.openFileButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.lexemClassificationTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keywordsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lexemClassificationDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeTextBox
            // 
            this.codeTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.codeTextBox.Location = new System.Drawing.Point(0, 0);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(351, 467);
            this.codeTextBox.TabIndex = 1;
            this.codeTextBox.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Files|*.txt";
            // 
            // performButton
            // 
            this.performButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.performButton.Location = new System.Drawing.Point(178, 473);
            this.performButton.Name = "performButton";
            this.performButton.Size = new System.Drawing.Size(170, 52);
            this.performButton.TabIndex = 2;
            this.performButton.Text = "Выполнить";
            this.performButton.UseVisualStyleBackColor = true;
            this.performButton.Click += new System.EventHandler(this.performButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.lexemClassificationTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(843, 529);
            this.tabControl1.TabIndex = 3;
            // 
            // lexemClassificationTabPage
            // 
            this.lexemClassificationTabPage.Controls.Add(this.keywordsDataGridView);
            this.lexemClassificationTabPage.Controls.Add(this.lexemClassificationDataGridView);
            this.lexemClassificationTabPage.Location = new System.Drawing.Point(4, 29);
            this.lexemClassificationTabPage.Name = "lexemClassificationTabPage";
            this.lexemClassificationTabPage.Size = new System.Drawing.Size(835, 496);
            this.lexemClassificationTabPage.TabIndex = 1;
            this.lexemClassificationTabPage.Text = "Классификация лексем";
            this.lexemClassificationTabPage.UseVisualStyleBackColor = true;
            // 
            // keywordsDataGridView
            // 
            this.keywordsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.keywordsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Keywords,
            this.Separators,
            this.Identifiers,
            this.Literals});
            this.keywordsDataGridView.Location = new System.Drawing.Point(412, 0);
            this.keywordsDataGridView.Name = "keywordsDataGridView";
            this.keywordsDataGridView.RowHeadersWidth = 51;
            this.keywordsDataGridView.RowTemplate.Height = 29;
            this.keywordsDataGridView.Size = new System.Drawing.Size(496, 496);
            this.keywordsDataGridView.TabIndex = 1;
            // 
            // Keywords
            // 
            this.Keywords.HeaderText = "Ключ. слова";
            this.Keywords.MinimumWidth = 6;
            this.Keywords.Name = "Keywords";
            this.Keywords.Width = 125;
            // 
            // Separators
            // 
            this.Separators.HeaderText = "Разделители";
            this.Separators.MinimumWidth = 6;
            this.Separators.Name = "Separators";
            this.Separators.Width = 125;
            // 
            // Identifiers
            // 
            this.Identifiers.HeaderText = "Идентификаторы";
            this.Identifiers.MinimumWidth = 6;
            this.Identifiers.Name = "Identifiers";
            this.Identifiers.Width = 125;
            // 
            // Literals
            // 
            this.Literals.HeaderText = "Литералы";
            this.Literals.MinimumWidth = 6;
            this.Literals.Name = "Literals";
            this.Literals.Width = 125;
            // 
            // lexemClassificationDataGridView
            // 
            this.lexemClassificationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lexemClassificationDataGridView.Location = new System.Drawing.Point(0, 0);
            this.lexemClassificationDataGridView.Name = "lexemClassificationDataGridView";
            this.lexemClassificationDataGridView.RowHeadersWidth = 51;
            this.lexemClassificationDataGridView.RowTemplate.Height = 29;
            this.lexemClassificationDataGridView.Size = new System.Drawing.Size(406, 496);
            this.lexemClassificationDataGridView.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.openFileButton);
            this.splitContainer1.Panel1.Controls.Add(this.performButton);
            this.splitContainer1.Panel1.Controls.Add(this.codeTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1198, 529);
            this.splitContainer1.SplitterDistance = 351;
            this.splitContainer1.TabIndex = 4;
            // 
            // openFileButton
            // 
            this.openFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.openFileButton.Location = new System.Drawing.Point(3, 473);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(170, 52);
            this.openFileButton.TabIndex = 3;
            this.openFileButton.Text = "Открыть";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 529);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.lexemClassificationTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.keywordsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lexemClassificationDataGridView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox codeTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button performButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.TabPage lexemClassificationTabPage;
        private System.Windows.Forms.DataGridView lexemClassificationDataGridView;
        private System.Windows.Forms.DataGridView keywordsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keywords;
        private System.Windows.Forms.DataGridViewTextBoxColumn Separators;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identifiers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Literals;
    }
}

