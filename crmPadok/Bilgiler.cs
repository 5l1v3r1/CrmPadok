using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace crmPadok
{
    public partial class Bilgiler : Form
    {
        Crm objCrm;
        private async void btnTelefon_Click(object sender, EventArgs e)
        {
            List<TelefonFaturalari> liste = new List<TelefonFaturalari>();
            progressBar1.Value = 0;
            string[] numaralar = txtTelefon.Text.Split('\n');
            float progress = (float)100 / (float)numaralar.Length;
            int i = 0;
            foreach (var numara in numaralar)
            {
                i++;
                try
                {
                    Task<string[]> sorguSonuc = Task.Factory.StartNew(() => objCrm.telefonFatura(numara));
                    string[] sonuc = await sorguSonuc;

                    if (sonuc.Length >= 10)
                    {
                        string isim = sonuc[10]; string faturaDonemi = sonuc[2]; string fiyat = sonuc[1];
                        txtSonuclar.Text += "İsim: " + isim + " Borç Dönemi: " + faturaDonemi + " Borç: " + fiyat + "\n";
                        liste.Add(new TelefonFaturalari(numara, isim, faturaDonemi, fiyat));
                    }
                    else
                        txtSonuclar.Text += "--------------\n";

                    progressBar1.Value = Convert.ToInt32(progress * i);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sorgulama sırasında bir hata oluştu " + ex.Message,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
        private void btnSorgula_Click(object sender, EventArgs e)
        {
            if (txtAdsl.Text.Length != 10)
            {
                MessageBox.Show("Hatalı giriş yaptınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] sonuc = objCrm.adslFatura(txtAdsl.Text); 
            if (sonuc.Length >= 10)
                MessageBox.Show("İsim: " + sonuc[10] + " Borç Dönemi: " + sonuc[2] + " Borç: " + sonuc[1]);
            else
                MessageBox.Show("Kayıt bulunamadı");
        }
        public Bilgiler(Crm objCrm)
        {
            InitializeComponent();
            this.objCrm = objCrm;
        }
        private void Bilgiler_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form f = Application.OpenForms["Form1"];
            ((Form1)f).Show();
        }
    }
}
