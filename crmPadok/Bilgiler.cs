using System;
using System.Windows.Forms;

namespace crmPadok
{
    public partial class Bilgiler : Form
    {
        Crm objCrm;
        private void btnTelefon_Click(object sender, EventArgs e)
        {
           string[] sonuc= objCrm.telefonFatura(txtTelefon.Text);
            if(sonuc.Length>=10)
            MessageBox.Show("İsim: "+sonuc[10]+" Borç Dönemi: "+sonuc[2]+" Borç: "+sonuc[1]);
            else
                MessageBox.Show("Kayıt bulunamadı");
        }
        private void btnSorgula_Click(object sender, EventArgs e)
        {
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
