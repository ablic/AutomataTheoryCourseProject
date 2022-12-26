
namespace ATFLCourseProject
{
    partial class MainForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.literalsListBox = new System.Windows.Forms.ListBox();
            this.identifiersListBox = new System.Windows.Forms.ListBox();
            this.separatorsListBox = new System.Windows.Forms.ListBox();
            this.keywordsListBox = new System.Windows.Forms.ListBox();
            this.lexemClassificationDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.operationsDataGridView = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.openFileButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.lexemClassificationTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lexemClassificationDataGridView)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operationsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeTextBox
            // 
            this.codeTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.codeTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.codeTextBox.Location = new System.Drawing.Point(0, 0);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(325, 586);
            this.codeTextBox.TabIndex = 1;
            this.codeTextBox.Text = "abc";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Files|*.txt";
            // 
            // performButton
            // 
            this.performButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.performButton.Location = new System.Drawing.Point(3, 630);
            this.performButton.Name = "performButton";
            this.performButton.Size = new System.Drawing.Size(319, 79);
            this.performButton.TabIndex = 2;
            this.performButton.Text = "Выполнить";
            this.performButton.UseVisualStyleBackColor = true;
            this.performButton.Click += new System.EventHandler(this.performButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.lexemClassificationTabPage);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(910, 713);
            this.tabControl1.TabIndex = 3;
            // 
            // lexemClassificationTabPage
            // 
            this.lexemClassificationTabPage.Controls.Add(this.label4);
            this.lexemClassificationTabPage.Controls.Add(this.label3);
            this.lexemClassificationTabPage.Controls.Add(this.label2);
            this.lexemClassificationTabPage.Controls.Add(this.label1);
            this.lexemClassificationTabPage.Controls.Add(this.literalsListBox);
            this.lexemClassificationTabPage.Controls.Add(this.identifiersListBox);
            this.lexemClassificationTabPage.Controls.Add(this.separatorsListBox);
            this.lexemClassificationTabPage.Controls.Add(this.keywordsListBox);
            this.lexemClassificationTabPage.Controls.Add(this.lexemClassificationDataGridView);
            this.lexemClassificationTabPage.Location = new System.Drawing.Point(4, 29);
            this.lexemClassificationTabPage.Name = "lexemClassificationTabPage";
            this.lexemClassificationTabPage.Size = new System.Drawing.Size(902, 680);
            this.lexemClassificationTabPage.TabIndex = 1;
            this.lexemClassificationTabPage.Text = "Классификация лексем";
            this.lexemClassificationTabPage.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(767, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Литералы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(641, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Идентиф-ры";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(515, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Разделители";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(389, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ключ. слова";
            // 
            // literalsListBox
            // 
            this.literalsListBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.literalsListBox.FormattingEnabled = true;
            this.literalsListBox.ItemHeight = 28;
            this.literalsListBox.Location = new System.Drawing.Point(767, 29);
            this.literalsListBox.Name = "literalsListBox";
            this.literalsListBox.Size = new System.Drawing.Size(120, 648);
            this.literalsListBox.TabIndex = 4;
            // 
            // identifiersListBox
            // 
            this.identifiersListBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.identifiersListBox.FormattingEnabled = true;
            this.identifiersListBox.ItemHeight = 28;
            this.identifiersListBox.Location = new System.Drawing.Point(641, 29);
            this.identifiersListBox.Name = "identifiersListBox";
            this.identifiersListBox.Size = new System.Drawing.Size(120, 648);
            this.identifiersListBox.TabIndex = 3;
            // 
            // separatorsListBox
            // 
            this.separatorsListBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.separatorsListBox.FormattingEnabled = true;
            this.separatorsListBox.ItemHeight = 28;
            this.separatorsListBox.Location = new System.Drawing.Point(515, 29);
            this.separatorsListBox.Name = "separatorsListBox";
            this.separatorsListBox.Size = new System.Drawing.Size(120, 648);
            this.separatorsListBox.TabIndex = 2;
            // 
            // keywordsListBox
            // 
            this.keywordsListBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.keywordsListBox.FormattingEnabled = true;
            this.keywordsListBox.ItemHeight = 28;
            this.keywordsListBox.Location = new System.Drawing.Point(389, 29);
            this.keywordsListBox.Name = "keywordsListBox";
            this.keywordsListBox.Size = new System.Drawing.Size(120, 648);
            this.keywordsListBox.TabIndex = 1;
            // 
            // lexemClassificationDataGridView
            // 
            this.lexemClassificationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lexemClassificationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.lexemClassificationDataGridView.Location = new System.Drawing.Point(3, 3);
            this.lexemClassificationDataGridView.Name = "lexemClassificationDataGridView";
            this.lexemClassificationDataGridView.RowHeadersWidth = 51;
            this.lexemClassificationDataGridView.RowTemplate.Height = 29;
            this.lexemClassificationDataGridView.Size = new System.Drawing.Size(380, 674);
            this.lexemClassificationDataGridView.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Тип";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Значение";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.operationsDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(902, 680);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Разбор выражения";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // operationsDataGridView
            // 
            this.operationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.operationsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.operationsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.operationsDataGridView.Name = "operationsDataGridView";
            this.operationsDataGridView.RowHeadersWidth = 51;
            this.operationsDataGridView.RowTemplate.Height = 29;
            this.operationsDataGridView.Size = new System.Drawing.Size(896, 674);
            this.operationsDataGridView.TabIndex = 0;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Операция";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Операнд 1";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Операнд 2";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Имя результата";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
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
            this.splitContainer1.Size = new System.Drawing.Size(1239, 713);
            this.splitContainer1.SplitterDistance = 325;
            this.splitContainer1.TabIndex = 4;
            // 
            // openFileButton
            // 
            this.openFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.openFileButton.Location = new System.Drawing.Point(3, 592);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(319, 32);
            this.openFileButton.TabIndex = 3;
            this.openFileButton.Text = "Открыть";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 713);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.lexemClassificationTabPage.ResumeLayout(false);
            this.lexemClassificationTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lexemClassificationDataGridView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.operationsDataGridView)).EndInit();
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
        private System.Windows.Forms.ListBox literalsListBox;
        private System.Windows.Forms.ListBox identifiersListBox;
        private System.Windows.Forms.ListBox separatorsListBox;
        private System.Windows.Forms.ListBox keywordsListBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView operationsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

