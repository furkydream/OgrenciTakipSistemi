namespace OgrenciTakipSistemi
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
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            txtNo = new TextBox();
            cmbFakulte = new ComboBox();
            cmbProgram = new ComboBox();
            btnKaydet = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSil = new Button();
            btnGuncelle = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtAd
            // 
            txtAd.Location = new Point(105, 26);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(125, 27);
            txtAd.TabIndex = 0;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(105, 74);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(125, 27);
            txtSoyad.TabIndex = 0;
            // 
            // txtNo
            // 
            txtNo.Location = new Point(105, 123);
            txtNo.Name = "txtNo";
            txtNo.Size = new Size(125, 27);
            txtNo.TabIndex = 0;
            // 
            // cmbFakulte
            // 
            cmbFakulte.FormattingEnabled = true;
            cmbFakulte.Location = new Point(293, 21);
            cmbFakulte.Name = "cmbFakulte";
            cmbFakulte.Size = new Size(295, 28);
            cmbFakulte.TabIndex = 1;
            // 
            // cmbProgram
            // 
            cmbProgram.FormattingEnabled = true;
            cmbProgram.Location = new Point(293, 71);
            cmbProgram.Name = "cmbProgram";
            cmbProgram.Size = new Size(295, 28);
            cmbProgram.TabIndex = 1;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(470, 123);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(118, 27);
            btnKaydet.TabIndex = 2;
            btnKaydet.Text = "KAYDET";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(31, 196);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(825, 212);
            dataGridView1.TabIndex = 3;
            
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 26);
            label1.Name = "label1";
            label1.Size = new Size(31, 20);
            label1.TabIndex = 4;
            label1.Text = "Ad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 123);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 4;
            label2.Text = "Numara:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 74);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 4;
            label3.Text = "Soyad:";
            // 
            // btnSil
            // 
            btnSil.Location = new Point(293, 123);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(102, 27);
            btnSil.TabIndex = 5;
            btnSil.Text = "SİL";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(660, 123);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(94, 27);
            btnGuncelle.TabIndex = 6;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 461);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(btnKaydet);
            Controls.Add(cmbProgram);
            Controls.Add(cmbFakulte);
            Controls.Add(txtNo);
            Controls.Add(txtSoyad);
            Controls.Add(txtAd);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAd;
        private TextBox txtSoyad;
        private TextBox txtNo;
        private ComboBox cmbFakulte;
        private ComboBox cmbProgram;
        private Button btnKaydet;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSil;
        private Button btnGuncelle;
    }
}
