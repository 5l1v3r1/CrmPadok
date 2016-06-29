using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
namespace crmPadok
{
    public partial class Form1 : Form
    {
        Crm objCrm = new Crm();
        public Form1()
        {
            InitializeComponent();
        }
        CookieContainer cookieContainer = new CookieContainer();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtMusteriNo.Text.Length != 11 || txtSifre.Text.Length != 8)
            {
                MessageBox.Show("Müsteri no 11,şifre 8 karakter uzunluğunda olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(objCrm.login(txtMusteriNo.Text, txtSifre.Text))
            {
                lblSifre.Visible = false;
                lblMusteri.Visible = false;
                txtMusteriNo.Visible = false;
                txtSifre.Visible = false;
                btnLogin.Visible = false;
                btnSms.Visible = true;
                txtSms.Visible = true;
                lblSms.Visible = true;
                timer();
            }
           else
            {
                MessageBox.Show("Giriş yapılırken bir hata oluştu","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnSms_Click(object sender, EventArgs e)
        {
            if (txtSms.Text == "")
            {
                MessageBox.Show("Sms şifrenizi giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(objCrm.SmsApproval(txtSms.Text))
            {
                MessageBox.Show("Giriş Başarılı");
            }
            else
            {
                MessageBox.Show("Giriş Başarısız");
            }
        }
        private void timer()
        {
            tmr.Start();
            DateTime dt = DateTime.Now.AddHours(0).AddMinutes(3).AddSeconds(0);
            lblTime.Visible = true;
            tmr.Interval = 1000;
            tmr.Tick += (sender, e) =>
            {
                TimeSpan diff = dt.Subtract(DateTime.Now);
                lblTime.Text = string.Format("{0:00}:{1:00}:{2:00}", diff.Hours, diff.Minutes, diff.Seconds);
                if (dt < DateTime.Now)
                {
                    ((Timer)sender).Stop();
                    MessageBox.Show("Sms şifresi giriş süreniz doldu lütfen tekrar giriş yapınız","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtSms.Visible = false;
                    btnSms.Visible = false;
                    lblSms.Visible = false;
                    btnLogin.Visible = true;
                    txtSifre.Visible = true;
                    txtMusteriNo.Visible = true;
                    lblMusteri.Visible = true;
                    lblSifre.Visible = true;
                    lblTime.Visible = false;
                }
                   
            };
        }
    }
}
