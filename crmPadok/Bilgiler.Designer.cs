namespace crmPadok
{
    partial class Bilgiler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdslSorgula = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTelefon = new System.Windows.Forms.Button();
            this.tabAdslTelefon = new System.Windows.Forms.TabControl();
            this.tabTelefon = new System.Windows.Forms.TabPage();
            this.dataGridTel = new System.Windows.Forms.DataGridView();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtSonuclar = new System.Windows.Forms.RichTextBox();
            this.txtTelefon = new System.Windows.Forms.RichTextBox();
            this.tabAdsl = new System.Windows.Forms.TabPage();
            this.dataGridAdsl = new System.Windows.Forms.DataGridView();
            this.btnAdslExcel = new System.Windows.Forms.Button();
            this.btnAdslIptal = new System.Windows.Forms.Button();
            this.prgAdsl = new System.Windows.Forms.ProgressBar();
            this.txtAdslSonuc = new System.Windows.Forms.RichTextBox();
            this.txtAdsl = new System.Windows.Forms.RichTextBox();
            this.btnAdslDataTemizle = new System.Windows.Forms.Button();
            this.tabAdslTelefon.SuspendLayout();
            this.tabTelefon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTel)).BeginInit();
            this.tabAdsl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAdsl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdslSorgula
            // 
            this.btnAdslSorgula.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnAdslSorgula.FlatAppearance.BorderSize = 0;
            this.btnAdslSorgula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdslSorgula.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdslSorgula.Location = new System.Drawing.Point(322, 575);
            this.btnAdslSorgula.Name = "btnAdslSorgula";
            this.btnAdslSorgula.Size = new System.Drawing.Size(75, 35);
            this.btnAdslSorgula.TabIndex = 17;
            this.btnAdslSorgula.Text = "Sorgula";
            this.btnAdslSorgula.UseVisualStyleBackColor = false;
            this.btnAdslSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Adsl No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Telefon No :";
            // 
            // btnTelefon
            // 
            this.btnTelefon.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnTelefon.FlatAppearance.BorderSize = 0;
            this.btnTelefon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTelefon.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTelefon.Location = new System.Drawing.Point(316, 574);
            this.btnTelefon.Name = "btnTelefon";
            this.btnTelefon.Size = new System.Drawing.Size(75, 35);
            this.btnTelefon.TabIndex = 20;
            this.btnTelefon.Text = "Sorgula";
            this.btnTelefon.UseVisualStyleBackColor = false;
            this.btnTelefon.Click += new System.EventHandler(this.btnTelefon_Click);
            // 
            // tabAdslTelefon
            // 
            this.tabAdslTelefon.Controls.Add(this.tabTelefon);
            this.tabAdslTelefon.Controls.Add(this.tabAdsl);
            this.tabAdslTelefon.Location = new System.Drawing.Point(0, 1);
            this.tabAdslTelefon.Name = "tabAdslTelefon";
            this.tabAdslTelefon.SelectedIndex = 0;
            this.tabAdslTelefon.Size = new System.Drawing.Size(1200, 673);
            this.tabAdslTelefon.TabIndex = 22;
            // 
            // tabTelefon
            // 
            this.tabTelefon.Controls.Add(this.dataGridTel);
            this.tabTelefon.Controls.Add(this.btnTemizle);
            this.tabTelefon.Controls.Add(this.btnExcel);
            this.tabTelefon.Controls.Add(this.btnIptal);
            this.tabTelefon.Controls.Add(this.progressBar1);
            this.tabTelefon.Controls.Add(this.btnTelefon);
            this.tabTelefon.Controls.Add(this.txtSonuclar);
            this.tabTelefon.Controls.Add(this.txtTelefon);
            this.tabTelefon.Controls.Add(this.label2);
            this.tabTelefon.Location = new System.Drawing.Point(4, 22);
            this.tabTelefon.Name = "tabTelefon";
            this.tabTelefon.Padding = new System.Windows.Forms.Padding(3);
            this.tabTelefon.Size = new System.Drawing.Size(1192, 647);
            this.tabTelefon.TabIndex = 0;
            this.tabTelefon.Text = "Telefon Sorgula";
            this.tabTelefon.UseVisualStyleBackColor = true;
            // 
            // dataGridTel
            // 
            this.dataGridTel.AllowUserToAddRows = false;
            this.dataGridTel.AllowUserToDeleteRows = false;
            this.dataGridTel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTel.Location = new System.Drawing.Point(496, 20);
            this.dataGridTel.Name = "dataGridTel";
            this.dataGridTel.ReadOnly = true;
            this.dataGridTel.Size = new System.Drawing.Size(656, 525);
            this.dataGridTel.TabIndex = 30;
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnTemizle.FlatAppearance.BorderSize = 0;
            this.btnTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemizle.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(915, 576);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(75, 33);
            this.btnTemizle.TabIndex = 29;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExcel.Location = new System.Drawing.Point(996, 576);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 33);
            this.btnExcel.TabIndex = 27;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(1077, 574);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 35);
            this.btnIptal.TabIndex = 25;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(496, 547);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(656, 23);
            this.progressBar1.TabIndex = 24;
            // 
            // txtSonuclar
            // 
            this.txtSonuclar.Location = new System.Drawing.Point(496, 20);
            this.txtSonuclar.Name = "txtSonuclar";
            this.txtSonuclar.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtSonuclar.Size = new System.Drawing.Size(656, 525);
            this.txtSonuclar.TabIndex = 23;
            this.txtSonuclar.Text = "";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(123, 20);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtTelefon.Size = new System.Drawing.Size(268, 525);
            this.txtTelefon.TabIndex = 22;
            this.txtTelefon.Text = "";
            // 
            // tabAdsl
            // 
            this.tabAdsl.Controls.Add(this.btnAdslDataTemizle);
            this.tabAdsl.Controls.Add(this.dataGridAdsl);
            this.tabAdsl.Controls.Add(this.btnAdslExcel);
            this.tabAdsl.Controls.Add(this.btnAdslIptal);
            this.tabAdsl.Controls.Add(this.prgAdsl);
            this.tabAdsl.Controls.Add(this.txtAdslSonuc);
            this.tabAdsl.Controls.Add(this.txtAdsl);
            this.tabAdsl.Controls.Add(this.btnAdslSorgula);
            this.tabAdsl.Controls.Add(this.label1);
            this.tabAdsl.Location = new System.Drawing.Point(4, 22);
            this.tabAdsl.Name = "tabAdsl";
            this.tabAdsl.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdsl.Size = new System.Drawing.Size(1192, 647);
            this.tabAdsl.TabIndex = 1;
            this.tabAdsl.Text = "Adsl Sorgula";
            this.tabAdsl.UseVisualStyleBackColor = true;
            // 
            // dataGridAdsl
            // 
            this.dataGridAdsl.AllowUserToAddRows = false;
            this.dataGridAdsl.AllowUserToDeleteRows = false;
            this.dataGridAdsl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAdsl.Location = new System.Drawing.Point(500, 20);
            this.dataGridAdsl.Name = "dataGridAdsl";
            this.dataGridAdsl.ReadOnly = true;
            this.dataGridAdsl.Size = new System.Drawing.Size(656, 525);
            this.dataGridAdsl.TabIndex = 31;
            // 
            // btnAdslExcel
            // 
            this.btnAdslExcel.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnAdslExcel.FlatAppearance.BorderSize = 0;
            this.btnAdslExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdslExcel.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdslExcel.Location = new System.Drawing.Point(1000, 577);
            this.btnAdslExcel.Name = "btnAdslExcel";
            this.btnAdslExcel.Size = new System.Drawing.Size(75, 33);
            this.btnAdslExcel.TabIndex = 28;
            this.btnAdslExcel.Text = "Excel";
            this.btnAdslExcel.UseVisualStyleBackColor = false;
            this.btnAdslExcel.Click += new System.EventHandler(this.btnAdslExcel_Click);
            // 
            // btnAdslIptal
            // 
            this.btnAdslIptal.Location = new System.Drawing.Point(1081, 577);
            this.btnAdslIptal.Name = "btnAdslIptal";
            this.btnAdslIptal.Size = new System.Drawing.Size(75, 33);
            this.btnAdslIptal.TabIndex = 27;
            this.btnAdslIptal.Text = "İptal";
            this.btnAdslIptal.UseVisualStyleBackColor = true;
            this.btnAdslIptal.Click += new System.EventHandler(this.btnAdslIptal_Click);
            // 
            // prgAdsl
            // 
            this.prgAdsl.Location = new System.Drawing.Point(500, 548);
            this.prgAdsl.Name = "prgAdsl";
            this.prgAdsl.Size = new System.Drawing.Size(656, 23);
            this.prgAdsl.TabIndex = 26;
            // 
            // txtAdslSonuc
            // 
            this.txtAdslSonuc.Location = new System.Drawing.Point(500, 20);
            this.txtAdslSonuc.Name = "txtAdslSonuc";
            this.txtAdslSonuc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtAdslSonuc.Size = new System.Drawing.Size(656, 525);
            this.txtAdslSonuc.TabIndex = 24;
            this.txtAdslSonuc.Text = "";
            // 
            // txtAdsl
            // 
            this.txtAdsl.Location = new System.Drawing.Point(129, 22);
            this.txtAdsl.Name = "txtAdsl";
            this.txtAdsl.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtAdsl.Size = new System.Drawing.Size(268, 525);
            this.txtAdsl.TabIndex = 23;
            this.txtAdsl.Text = "";
            // 
            // btnAdslDataTemizle
            // 
            this.btnAdslDataTemizle.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnAdslDataTemizle.FlatAppearance.BorderSize = 0;
            this.btnAdslDataTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdslDataTemizle.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdslDataTemizle.Location = new System.Drawing.Point(919, 576);
            this.btnAdslDataTemizle.Name = "btnAdslDataTemizle";
            this.btnAdslDataTemizle.Size = new System.Drawing.Size(75, 33);
            this.btnAdslDataTemizle.TabIndex = 32;
            this.btnAdslDataTemizle.Text = "Temizle";
            this.btnAdslDataTemizle.UseVisualStyleBackColor = false;
            this.btnAdslDataTemizle.Click += new System.EventHandler(this.btnAdslDataTemizle_Click);
            // 
            // Bilgiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1201, 670);
            this.Controls.Add(this.tabAdslTelefon);
            this.MaximizeBox = false;
            this.Name = "Bilgiler";
            this.ShowIcon = false;
            this.Text = "Padok";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bilgiler_FormClosing);
            this.tabAdslTelefon.ResumeLayout(false);
            this.tabTelefon.ResumeLayout(false);
            this.tabTelefon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTel)).EndInit();
            this.tabAdsl.ResumeLayout(false);
            this.tabAdsl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAdsl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAdslSorgula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTelefon;
        private System.Windows.Forms.TabControl tabAdslTelefon;
        private System.Windows.Forms.TabPage tabTelefon;
        private System.Windows.Forms.RichTextBox txtSonuclar;
        private System.Windows.Forms.RichTextBox txtTelefon;
        private System.Windows.Forms.TabPage tabAdsl;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Button btnAdslIptal;
        private System.Windows.Forms.ProgressBar prgAdsl;
        private System.Windows.Forms.RichTextBox txtAdsl;
        private System.Windows.Forms.RichTextBox txtAdslSonuc;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnAdslExcel;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.DataGridView dataGridTel;
        private System.Windows.Forms.DataGridView dataGridAdsl;
        private System.Windows.Forms.Button btnAdslDataTemizle;
    }
}