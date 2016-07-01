using System;
using System.Windows.Forms;
using System.Threading.Tasks;
namespace crmPadok
{
    public partial class Form1 : Form
    {
        Crm objCrm = new Crm();
        public Form1()
        {
            InitializeComponent();
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (txtMusteriNo.Text.Length != 11 || txtSifre.Text.Length != 8)
            {
                MessageBox.Show("Müsteri no 11,şifre 8 karakter uzunluğunda olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
         
            Task<bool> taskSonuc = Task.Factory.StartNew(() => objCrm.login(txtMusteriNo.Text, txtSifre.Text));
            lblBekle.Text = "Giriş yapılıyor...";
            btnLogin.Enabled = false;
            bool sonuc = await taskSonuc;
            if (sonuc)
            {
                #region gizle göster
                lblBekle.Visible = false;
                lblSifre.Visible = false;
                lblMusteri.Visible = false;
                txtMusteriNo.Visible = false;
                txtSifre.Visible = false;
                btnLogin.Visible = false;
                btnSms.Visible = true;
                txtSms.Visible = true;
                lblSms.Visible = true; 
                #endregion
                timer();
            }
            else
            {
                btnLogin.Enabled = true;
                lblBekle.Text = "Giriş başarısız";
                MessageBox.Show("Giriş yapılırken bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnSms_Click(object sender, EventArgs e)
        {
            if (txtSms.Text == "" || txtSms.Text.Length!=6)
            {
                MessageBox.Show("Hatalı giriş yaptınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Task<bool> taskSonuc = Task.Factory.StartNew(() => objCrm.SmsApproval(txtSms.Text));
            btnSms.Enabled = false;
            lblBekle.Text = "Giriş yapılıyor...";
            bool sonuc = await taskSonuc;
            if (sonuc)
            {
                try
                {
                    tmr.Stop();
                    #region gizle göster
                    txtSms.Text = "";
                    txtSms.Visible = false;
                    btnSms.Visible = false;
                    lblSms.Visible = false;
                    btnLogin.Visible = true;
                    txtSifre.Visible = true;
                    txtMusteriNo.Visible = true;
                    lblMusteri.Visible = true;
                    lblSifre.Visible = true;
                    lblTime.Visible = false;
                    this.Hide(); 
                    #endregion
                    Bilgiler bForm = new Bilgiler(objCrm);
                    bForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bilgiler gönderilirken hata oluştu " + ex.Message);
                }
            }
            else
            {
                btnSms.Enabled = true;
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
                    ((System.Windows.Forms.Timer)sender).Stop();
                    MessageBox.Show("Sms şifresi giriş süreniz doldu lütfen tekrar giriş yapınız","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    #region gizle göster
                    txtMusteriNo.Text = "";
                    txtSifre.Text = "";
                    txtSms.Text = "";
                    txtSms.Visible = false;
                    btnSms.Visible = false;
                    lblSms.Visible = false;
                    btnLogin.Visible = true;
                    txtSifre.Visible = true;
                    txtMusteriNo.Visible = true;
                    lblMusteri.Visible = true;
                    lblSifre.Visible = true;
                    lblTime.Visible = false;
                    btnLogin.Enabled = true;
                    btnSms.Enabled = true;
                    #endregion
                }
                   
            };
        }

    }
}
