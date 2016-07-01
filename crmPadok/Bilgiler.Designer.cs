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
            this.txtAdsl = new System.Windows.Forms.TextBox();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTelefon = new System.Windows.Forms.Button();
            this.tabAdslTelefon = new System.Windows.Forms.TabControl();
            this.tabTelefon = new System.Windows.Forms.TabPage();
            this.tabAdsl = new System.Windows.Forms.TabPage();
            this.txtTelefon = new System.Windows.Forms.RichTextBox();
            this.txtSonuclar = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabAdslTelefon.SuspendLayout();
            this.tabTelefon.SuspendLayout();
            this.tabAdsl.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAdsl
            // 
            this.txtAdsl.Location = new System.Drawing.Point(326, 77);
            this.txtAdsl.Name = "txtAdsl";
            this.txtAdsl.Size = new System.Drawing.Size(158, 20);
            this.txtAdsl.TabIndex = 16;
            // 
            // btnSorgula
            // 
            this.btnSorgula.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnSorgula.FlatAppearance.BorderSize = 0;
            this.btnSorgula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSorgula.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSorgula.Location = new System.Drawing.Point(409, 103);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(75, 35);
            this.btnSorgula.TabIndex = 17;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = false;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(257, 78);
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
            this.btnTelefon.Location = new System.Drawing.Point(406, 169);
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
            this.tabAdslTelefon.Size = new System.Drawing.Size(954, 596);
            this.tabAdslTelefon.TabIndex = 22;
            // 
            // tabTelefon
            // 
            this.tabTelefon.Controls.Add(this.progressBar1);
            this.tabTelefon.Controls.Add(this.btnTelefon);
            this.tabTelefon.Controls.Add(this.txtSonuclar);
            this.tabTelefon.Controls.Add(this.txtTelefon);
            this.tabTelefon.Controls.Add(this.label2);
            this.tabTelefon.Location = new System.Drawing.Point(4, 22);
            this.tabTelefon.Name = "tabTelefon";
            this.tabTelefon.Padding = new System.Windows.Forms.Padding(3);
            this.tabTelefon.Size = new System.Drawing.Size(946, 570);
            this.tabTelefon.TabIndex = 0;
            this.tabTelefon.Text = "Telefon Sorgula";
            this.tabTelefon.UseVisualStyleBackColor = true;
            // 
            // tabAdsl
            // 
            this.tabAdsl.Controls.Add(this.btnSorgula);
            this.tabAdsl.Controls.Add(this.label1);
            this.tabAdsl.Controls.Add(this.txtAdsl);
            this.tabAdsl.Location = new System.Drawing.Point(4, 22);
            this.tabAdsl.Name = "tabAdsl";
            this.tabAdsl.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdsl.Size = new System.Drawing.Size(946, 570);
            this.tabAdsl.TabIndex = 1;
            this.tabAdsl.Text = "Adsl Sorgula";
            this.tabAdsl.UseVisualStyleBackColor = true;
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
            // txtSonuclar
            // 
            this.txtSonuclar.Location = new System.Drawing.Point(496, 20);
            this.txtSonuclar.Name = "txtSonuclar";
            this.txtSonuclar.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtSonuclar.Size = new System.Drawing.Size(319, 525);
            this.txtSonuclar.TabIndex = 23;
            this.txtSonuclar.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(123, 547);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(692, 23);
            this.progressBar1.TabIndex = 24;
            // 
            // Bilgiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(957, 596);
            this.Controls.Add(this.tabAdslTelefon);
            this.MaximizeBox = false;
            this.Name = "Bilgiler";
            this.ShowIcon = false;
            this.Text = "Padok";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bilgiler_FormClosing);
            this.tabAdslTelefon.ResumeLayout(false);
            this.tabTelefon.ResumeLayout(false);
            this.tabTelefon.PerformLayout();
            this.tabAdsl.ResumeLayout(false);
            this.tabAdsl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtAdsl;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTelefon;
        private System.Windows.Forms.TabControl tabAdslTelefon;
        private System.Windows.Forms.TabPage tabTelefon;
        private System.Windows.Forms.RichTextBox txtSonuclar;
        private System.Windows.Forms.RichTextBox txtTelefon;
        private System.Windows.Forms.TabPage tabAdsl;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}