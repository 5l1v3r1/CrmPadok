using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace crmPadok
{
    public partial class Bilgiler : Form
    {
        Crm objCrm;
        public static CancellationTokenSource source;
        public static CancellationToken token;
        public Bilgiler(Crm objCrm)
        {
            InitializeComponent();
            this.objCrm = objCrm;
        }
        private async Task<List<TelefonFaturalari>> getTelFatura()
        {
            source = new CancellationTokenSource();
            token = new CancellationToken();
            token = source.Token;
            List<TelefonFaturalari> liste = new List<TelefonFaturalari>();
            List<Task> taskList = new List<Task>();
            string[] numaralar = txtTelefon.Text.Split('\n');
            float progress = (float)100 / (float)numaralar.Length;
            Dictionary<string, string> keyList = objCrm.getHesapNo();
            int i = 0;
            foreach (var numara in numaralar)
            {
                if (numara == "")
                    continue;
                Sorgula telefonFatura = new Sorgula();
                telefonFatura.Container = objCrm.Container;
                telefonFatura.List = keyList;
                var sonTask= Task.Factory.StartNew(() => telefonFatura.telefonFatura(numara),token, TaskCreationOptions.AttachedToParent,TaskScheduler.Current).ContinueWith(async (t) =>
                {
                    string telNo = numara;
                    
                    await t;
                    i++;
                    progressBar1.Value = Convert.ToInt32(progress * i);
                    if (t.IsFaulted)
                        txtSonuclar.Text += telNo + "=>faulted " + t.Exception.Message;
                    else
                    {
                        string[] sonuc = t.Result;
                        if (sonuc.Length >= 10)
                        {
                            string isim = sonuc[10]; string faturaDonemi = sonuc[2]; string fiyat = sonuc[1];
                            txtSonuclar.Text += telNo + "= İsim: " + isim + " Borç Dönemi: " + faturaDonemi + " Borç: " + fiyat + "\n";
                            liste.Add(new TelefonFaturalari(telNo, isim, faturaDonemi, fiyat));
                        }
                        else
                            txtSonuclar.Text += "--------------\n";
                    }
                    
                },
                 TaskScheduler.FromCurrentSynchronizationContext());

                taskList.Add(sonTask);
                if (taskList.Count % 100 == 0)
                   await Task.WhenAll(taskList);
            }
            return liste;
        }
        private async void btnTelefon_Click(object sender, EventArgs e)
        {
            List<TelefonFaturalari> telList = await getTelFatura();
        



            //    List<Task<string[]>> taskList = deneme();
            //    foreach (var item in taskList)
            //    {
            //        string[] sonuc = item.Result;

            //    }
            //List<TelefonFaturalari> liste = new List<TelefonFaturalari>();
            //progressBar1.Value = 0;
            //string[] numaralar = txtTelefon.Text.Split('\n');
            //float progress = (float)100 / (float)numaralar.Length;
            //int i = 0;
            //foreach (var numara in numaralar)
            //{
            //    i++;
            //    try
            //    {
            //        // Task<string[]> sorguSonuc = Task.Factory.StartNew(() => objCrm.telefonFatura(numara));
            //        //   string[] sonuc = await sorguSonuc;
            //        string[] sonuc = objCrm.telefonFatura(numara);
            //        if (sonuc.Length >= 10)
            //        {
            //            string isim = sonuc[10]; string faturaDonemi = sonuc[2]; string fiyat = sonuc[1];
            //            txtSonuclar.Text += "İsim: " + isim + " Borç Dönemi: " + faturaDonemi + " Borç: " + fiyat + "\n";
            //            liste.Add(new TelefonFaturalari(numara, isim, faturaDonemi, fiyat));
            //        }
            //        else
            //            txtSonuclar.Text += "--------------\n";

            //        progressBar1.Value = Convert.ToInt32(progress * i);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Sorgulama sırasında bir hata oluştu " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
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
      
        private void Bilgiler_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form f = Application.OpenForms["Form1"];
            ((Form1)f).Show();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            if (token.CanBeCanceled && !token.IsCancellationRequested)
            {
                DialogResult result = MessageBox.Show("İptal etmek istediğinize emin misiniz?", "iptal işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Bilgiler.source.Cancel();
                    MessageBox.Show("İptal edildi.", "Padok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Devam eden bir sorgulama işlemi yok", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
