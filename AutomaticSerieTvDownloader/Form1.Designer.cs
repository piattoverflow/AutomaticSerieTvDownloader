namespace AutomaticSerieTvDownloader
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_cerca = new System.Windows.Forms.Button();
            this.txtbx_SerieTv = new System.Windows.Forms.TextBox();
            this.nUpDwn_Serie = new System.Windows.Forms.NumericUpDown();
            this.nUpDwn_Episodio = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmB_qualita = new System.Windows.Forms.ComboBox();
            this.cmB_sort = new System.Windows.Forms.ComboBox();
            this.chckBx_sortType = new System.Windows.Forms.CheckBox();
            this.grpBx_Sort = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDwn_Serie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDwn_Episodio)).BeginInit();
            this.grpBx_Sort.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-9, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1283, 515);
            this.dataGridView1.TabIndex = 1;
            // 
            // btn_cerca
            // 
            this.btn_cerca.Location = new System.Drawing.Point(414, 12);
            this.btn_cerca.Name = "btn_cerca";
            this.btn_cerca.Size = new System.Drawing.Size(75, 23);
            this.btn_cerca.TabIndex = 2;
            this.btn_cerca.Text = "Cerca";
            this.btn_cerca.UseVisualStyleBackColor = true;
            this.btn_cerca.Click += new System.EventHandler(this.btn_cerca_Click);
            // 
            // txtbx_SerieTv
            // 
            this.txtbx_SerieTv.Location = new System.Drawing.Point(12, 14);
            this.txtbx_SerieTv.Name = "txtbx_SerieTv";
            this.txtbx_SerieTv.Size = new System.Drawing.Size(239, 20);
            this.txtbx_SerieTv.TabIndex = 3;
            this.txtbx_SerieTv.Text = "The good doctor";
            // 
            // nUpDwn_Serie
            // 
            this.nUpDwn_Serie.Location = new System.Drawing.Point(288, 15);
            this.nUpDwn_Serie.Name = "nUpDwn_Serie";
            this.nUpDwn_Serie.Size = new System.Drawing.Size(42, 20);
            this.nUpDwn_Serie.TabIndex = 4;
            this.nUpDwn_Serie.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nUpDwn_Episodio
            // 
            this.nUpDwn_Episodio.Location = new System.Drawing.Point(362, 15);
            this.nUpDwn_Episodio.Name = "nUpDwn_Episodio";
            this.nUpDwn_Episodio.Size = new System.Drawing.Size(37, 20);
            this.nUpDwn_Episodio.TabIndex = 5;
            this.nUpDwn_Episodio.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "S:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "E:";
            // 
            // cmB_qualita
            // 
            this.cmB_qualita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_qualita.FormattingEnabled = true;
            this.cmB_qualita.Items.AddRange(new object[] {
            "standard",
            "720p",
            "1080p"});
            this.cmB_qualita.Location = new System.Drawing.Point(505, 13);
            this.cmB_qualita.Name = "cmB_qualita";
            this.cmB_qualita.Size = new System.Drawing.Size(121, 21);
            this.cmB_qualita.TabIndex = 8;
            // 
            // cmB_sort
            // 
            this.cmB_sort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_sort.FormattingEnabled = true;
            this.cmB_sort.Items.AddRange(new object[] {
            "Seeders",
            "Leechers",
            "Time",
            "Size"});
            this.cmB_sort.Location = new System.Drawing.Point(6, 15);
            this.cmB_sort.Name = "cmB_sort";
            this.cmB_sort.Size = new System.Drawing.Size(121, 21);
            this.cmB_sort.TabIndex = 9;
            // 
            // chckBx_sortType
            // 
            this.chckBx_sortType.AutoSize = true;
            this.chckBx_sortType.Location = new System.Drawing.Point(133, 18);
            this.chckBx_sortType.Name = "chckBx_sortType";
            this.chckBx_sortType.Size = new System.Drawing.Size(73, 17);
            this.chckBx_sortType.TabIndex = 10;
            this.chckBx_sortType.Text = "crescente";
            this.chckBx_sortType.UseVisualStyleBackColor = true;
            // 
            // grpBx_Sort
            // 
            this.grpBx_Sort.Controls.Add(this.cmB_sort);
            this.grpBx_Sort.Controls.Add(this.chckBx_sortType);
            this.grpBx_Sort.Location = new System.Drawing.Point(632, -2);
            this.grpBx_Sort.Name = "grpBx_Sort";
            this.grpBx_Sort.Size = new System.Drawing.Size(209, 43);
            this.grpBx_Sort.TabIndex = 11;
            this.grpBx_Sort.TabStop = false;
            this.grpBx_Sort.Text = "Ordina per";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(860, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Scarica";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(941, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "D:\\Varie\\film\\";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(941, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Dir subs";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1172, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "All season?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 555);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grpBx_Sort);
            this.Controls.Add(this.cmB_qualita);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nUpDwn_Episodio);
            this.Controls.Add(this.nUpDwn_Serie);
            this.Controls.Add(this.txtbx_SerieTv);
            this.Controls.Add(this.btn_cerca);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Automatic film sub renamer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDwn_Serie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDwn_Episodio)).EndInit();
            this.grpBx_Sort.ResumeLayout(false);
            this.grpBx_Sort.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_cerca;
        private System.Windows.Forms.TextBox txtbx_SerieTv;
        private System.Windows.Forms.NumericUpDown nUpDwn_Serie;
        private System.Windows.Forms.NumericUpDown nUpDwn_Episodio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmB_qualita;
        private System.Windows.Forms.ComboBox cmB_sort;
        private System.Windows.Forms.CheckBox chckBx_sortType;
        private System.Windows.Forms.GroupBox grpBx_Sort;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

