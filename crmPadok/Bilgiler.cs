using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace crmPadok
{
    public enum TelTaskStatus
    {
        Waiting,
        Running,
        Cancelled,
        Completed,
    };
    public enum AdslTaskStatus
    {
        Waiting,
        Running,
        Cancelled,
        Completed,
    };
    public partial class Bilgiler : Form
    {
        
        public TelTaskStatus telStatus=TelTaskStatus.Waiting;

        public AdslTaskStatus adslStatus=AdslTaskStatus.Waiting;

        Crm objCrm;

        public CancellationTokenSource sourceTel;

        public CancellationToken tokenTel;

        public CancellationTokenSource sourceAdsl;

        public CancellationToken tokenAdsl;

        public Bilgiler(Crm objCrm)
        {
            InitializeComponent();
            this.objCrm = objCrm;
        }
        private async Task<List<Faturalar>> getTelFatura()
        {
            object state = new object();

          
            List<Faturalar> liste = new List<Faturalar>();
            List<Task> taskList = new List<Task>();
            sourceTel = new CancellationTokenSource();
            tokenTel = new CancellationToken();
            tokenTel = sourceTel.Token;
            string[] numaralar = txtTelefon.Text.Split('\n');

            if(txtTelefon.Text.Length>9)
              telStatus = TelTaskStatus.Running;

            float progress = (float)100 / (float)numaralar.Length;
            Dictionary<string, string> keyList = objCrm.getHesapNo();
            int i = 0;
            foreach (var numara in numaralar)
            {
                if (numara == "")
                    continue;
                Sorgula objSorgula = new Sorgula();
                objSorgula.Container = objCrm.Container;
                objSorgula.List = keyList;
                var sonTask = Task.Run(() => objSorgula.telefonFatura(numara,tokenTel), tokenTel).ContinueWith(async (t) =>
                  {
                      string telNo = numara;
                      await t;
                      i++;
                      progressBar1.Value = Convert.ToInt32(progress * i);
                      if (t.IsFaulted)
                          txtSonuclar.Text += telNo + "=>faulted " + t.Exception.Message;
                      else
                      {
                          lock(state)
                          {
                              Faturalar telFatura = t.Result;
                              if (telFatura != null)
                              {
                                  Task.Factory.StartNew(() => printToScreen(telFatura.ToString() + "\n"), tokenTel, TaskCreationOptions.AttachedToParent, TaskScheduler.FromCurrentSynchronizationContext());
                                  liste.Add(telFatura);
                              }
                              else if (t.IsCompleted)
                                   Task.Factory.StartNew(() => printToScreen(telNo+" => --------------\n"), tokenTel, TaskCreationOptions.AttachedToParent, TaskScheduler.FromCurrentSynchronizationContext());
                              else if (t.IsCanceled)
                                   Task.Factory.StartNew(() => printToScreen("Cancelled"));
                          }
                      }
                  },
                 TaskScheduler.FromCurrentSynchronizationContext());
                
                
                taskList.Add(sonTask);

                if (taskList.Count % 100 == 0)
                    await Task.WhenAll(taskList);
            }
            if (progressBar1.Value == 100)
            {
                MessageBox.Show("Sorgulama tamamlandı", "Padok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                telStatus = TelTaskStatus.Completed;
            }
            else if(tokenTel.IsCancellationRequested)
            {
                telStatus = TelTaskStatus.Cancelled;
                MessageBox.Show("İptal edildi.", "Padok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar1.Value = 0;
            }
            else
            {
                telStatus = TelTaskStatus.Waiting;
            }
            return liste;
        }
        private async Task<List<Faturalar>> getAdslFatura()
        {
            object state = new object();
            adslStatus = AdslTaskStatus.Running;
            List<Faturalar> liste = new List<Faturalar>();
            List<Task> taskList = new List<Task>();
            sourceAdsl = new CancellationTokenSource();
            tokenAdsl = new CancellationToken();
            tokenAdsl = sourceAdsl.Token;
            string[] numaralar = txtAdsl.Text.Split('\n');
            float progress = (float)100 / (float)numaralar.Length;
            Dictionary<string, string> keyList = objCrm.getHesapNo();
            int i = 0;
            foreach (var numara in numaralar)
            {
                if (numara == "")
                    continue;
                Sorgula objSorgula = new Sorgula();
                objSorgula.Container = objCrm.Container;
                objSorgula.List = keyList;
                var sonTask = Task.Run(() => objSorgula.adslFatura(numara,tokenAdsl), tokenAdsl).ContinueWith(async (t) =>
                {
                    string adslNo = numara;

                    await t;
                    
                    if (t.IsFaulted)
                        txtAdslSonuc.Text += adslNo + "=>faulted " + t.Exception.Message;
                    else
                    {
                        lock (state)
                        {
                            i++;
                            prgAdsl.Value = Convert.ToInt32(progress * i);
                            Faturalar adslFatura = t.Result;
                            if (adslFatura != null)
                            {
                                Task.Factory.StartNew(() => printToScreenAdsl(adslFatura.ToString() + "\n"), tokenTel, TaskCreationOptions.AttachedToParent, TaskScheduler.FromCurrentSynchronizationContext());
                                liste.Add(adslFatura);
                            }
                            else
                                Task.Factory.StartNew(() => printToScreenAdsl("--------------\n"), tokenTel, TaskCreationOptions.AttachedToParent, TaskScheduler.FromCurrentSynchronizationContext());
                        }
                    }
                },
                 TaskScheduler.FromCurrentSynchronizationContext());

                taskList.Add(sonTask);
                if (taskList.Count % 100 == 0)
                    await Task.WhenAll(taskList);
            }
            //sorgulama bitti yada iptal edildi
            if (prgAdsl.Value == 100)
            {
                MessageBox.Show("Sorgulama tamamlandı", "Padok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                adslStatus = AdslTaskStatus.Completed;
            }
            else if (tokenAdsl.IsCancellationRequested)
            {
                adslStatus = AdslTaskStatus.Cancelled;
                MessageBox.Show("İptal edildi.", "Padok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                prgAdsl.Value = 0;
            }
            else
            {
                adslStatus = AdslTaskStatus.Waiting;
            }
            return liste;
        }
        private void printToScreen(string text)
        {
            if(tokenTel.IsCancellationRequested)
               tokenTel.ThrowIfCancellationRequested();
            txtSonuclar.Text += text;
        }
        private void printToScreenAdsl(string text)
        {
            txtAdslSonuc.Text += text;
        }
        private async void btnTelefon_Click(object sender, EventArgs e)
        {
            if (telStatus == TelTaskStatus.Running)
            {
                MessageBox.Show("Zaten çalışan bir sorgulama işlemi var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<Faturalar> telList;
            
                telList = await getTelFatura();
            //List<Task<string[]>> taskList = deneme();
            //foreach (var item in taskList)
            //{
            //    string[] sonuc = item.Result;

            //}
            //List<Faturalar> liste = new List<Faturalar>();
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
            //            liste.Add(new Faturalar(numara, isim, faturaDonemi, fiyat));
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
        private async void btnSorgula_Click(object sender, EventArgs e)
        {
            if (adslStatus == AdslTaskStatus.Running)
            {
                MessageBox.Show("Zaten çalışan bir sorgulama işlemi var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<Faturalar> telList = await getAdslFatura();

            //if (txtAdsl.Text.Length != 10)
            //{
            //    MessageBox.Show("Hatalı giriş yaptınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //string[] sonuc = objCrm.adslFatura(txtAdsl.Text); 
            //if (sonuc.Length >= 10)
            //    MessageBox.Show("İsim: " + sonuc[10] + " Borç Dönemi: " + sonuc[2] + " Borç: " + sonuc[1]);
            //else
            //    MessageBox.Show("Kayıt bulunamadı");
        }
      
        private void Bilgiler_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form f = Application.OpenForms["Form1"];
            ((AnaForm)f).Show();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            if (tokenTel.CanBeCanceled && !tokenTel.IsCancellationRequested && progressBar1.Value != 0 && progressBar1.Value != 100)
            {
                DialogResult result = MessageBox.Show("İptal etmek istediğinize emin misiniz?", "iptal işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    sourceTel.Cancel(true);
                }
            }
            else
            {
                MessageBox.Show("Devam eden bir sorgulama işlemi yok", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdslIptal_Click(object sender, EventArgs e)
        {
            if (tokenAdsl.CanBeCanceled && !tokenAdsl.IsCancellationRequested && prgAdsl.Value != 0 && prgAdsl.Value != 100)
            {
                DialogResult result = MessageBox.Show("İptal etmek istediğinize emin misiniz?", "iptal işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    sourceAdsl.Cancel(true);
                    MessageBox.Show("İptal edildi.", "Padok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    prgAdsl.Value = 0;
                }
            }
            else
            {
                MessageBox.Show("Devam eden bir sorgulama işlemi yok", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
