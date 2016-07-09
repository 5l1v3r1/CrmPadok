namespace crmPadok
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtMusteriNo = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.lblMusteri = new System.Windows.Forms.Label();
            this.lblSifre = new System.Windows.Forms.Label();
            this.txtSms = new System.Windows.Forms.TextBox();
            this.btnSms = new System.Windows.Forms.Button();
            this.lblSms = new System.Windows.Forms.Label();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.lblBekle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogin.Location = new System.Drawing.Point(209, 105);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 35);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Giriş";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtMusteriNo
            // 
            this.txtMusteriNo.Location = new System.Drawing.Point(130, 32);
            this.txtMusteriNo.Name = "txtMusteriNo";
            this.txtMusteriNo.Size = new System.Drawing.Size(154, 20);
            this.txtMusteriNo.TabIndex = 1;
            this.txtMusteriNo.Text = "01846250031";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(130, 59);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(154, 20);
            this.txtSifre.TabIndex = 2;
            this.txtSifre.Text = "35077811";
            this.txtSifre.UseSystemPasswordChar = true;
            // 
            // lblMusteri
            // 
            this.lblMusteri.AutoSize = true;
            this.lblMusteri.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMusteri.Location = new System.Drawing.Point(46, 34);
            this.lblMusteri.Name = "lblMusteri";
            this.lblMusteri.Size = new System.Drawing.Size(78, 15);
            this.lblMusteri.TabIndex = 4;
            this.lblMusteri.Text = "Müşteri No :";
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSifre.Location = new System.Drawing.Point(80, 60);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(41, 15);
            this.lblSifre.TabIndex = 5;
            this.lblSifre.Text = "Şifre :";
            // 
            // txtSms
            // 
            this.txtSms.Location = new System.Drawing.Point(130, 32);
            this.txtSms.Name = "txtSms";
            this.txtSms.Size = new System.Drawing.Size(154, 20);
            this.txtSms.TabIndex = 6;
            this.txtSms.Visible = false;
            // 
            // btnSms
            // 
            this.btnSms.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnSms.FlatAppearance.BorderSize = 0;
            this.btnSms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSms.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSms.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSms.Location = new System.Drawing.Point(209, 59);
            this.btnSms.Name = "btnSms";
            this.btnSms.Size = new System.Drawing.Size(75, 35);
            this.btnSms.TabIndex = 7;
            this.btnSms.Text = "Gönder";
            this.btnSms.UseVisualStyleBackColor = false;
            this.btnSms.Visible = false;
            this.btnSms.Click += new System.EventHandler(this.btnSms_Click);
            // 
            // lblSms
            // 
            this.lblSms.AutoSize = true;
            this.lblSms.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSms.Location = new System.Drawing.Point(46, 34);
            this.lblSms.Name = "lblSms";
            this.lblSms.Size = new System.Drawing.Size(75, 15);
            this.lblSms.TabIndex = 8;
            this.lblSms.Text = "Sms şifresi :";
            this.lblSms.Visible = false;
            // 
            // tmr
            // 
            this.tmr.Interval = 1000;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(130, 62);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 13);
            this.lblTime.TabIndex = 9;
            this.lblTime.Visible = false;
            // 
            // lblBekle
            // 
            this.lblBekle.AutoSize = true;
            this.lblBekle.Location = new System.Drawing.Point(46, 127);
            this.lblBekle.Name = "lblBekle";
            this.lblBekle.Size = new System.Drawing.Size(0, 13);
            this.lblBekle.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(340, 177);
            this.Controls.Add(this.lblBekle);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblSms);
            this.Controls.Add(this.btnSms);
            this.Controls.Add(this.txtSms);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.lblMusteri);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtMusteriNo);
            this.Controls.Add(this.btnLogin);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Padok";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtMusteriNo;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label lblMusteri;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.TextBox txtSms;
        private System.Windows.Forms.Button btnSms;
        private System.Windows.Forms.Label lblSms;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblBekle;
    }
}

