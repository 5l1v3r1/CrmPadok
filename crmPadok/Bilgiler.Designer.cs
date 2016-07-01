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
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtAdsl
            // 
            this.txtAdsl.Location = new System.Drawing.Point(133, 35);
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
            this.btnSorgula.Location = new System.Drawing.Point(216, 61);
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
            this.label1.Location = new System.Drawing.Point(64, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Adsl No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(44, 116);
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
            this.btnTelefon.Location = new System.Drawing.Point(216, 140);
            this.btnTelefon.Name = "btnTelefon";
            this.btnTelefon.Size = new System.Drawing.Size(75, 35);
            this.btnTelefon.TabIndex = 20;
            this.btnTelefon.Text = "Sorgula";
            this.btnTelefon.UseVisualStyleBackColor = false;
            this.btnTelefon.Click += new System.EventHandler(this.btnTelefon_Click);
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(133, 114);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(158, 20);
            this.txtTelefon.TabIndex = 19;
            // 
            // Bilgiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(349, 205);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTelefon);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSorgula);
            this.Controls.Add(this.txtAdsl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Bilgiler";
            this.ShowIcon = false;
            this.Text = "Padok";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bilgiler_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtAdsl;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTelefon;
        private System.Windows.Forms.TextBox txtTelefon;
    }
}