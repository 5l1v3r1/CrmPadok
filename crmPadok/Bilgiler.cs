using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crmPadok
{
    public partial class Bilgiler : Form
    {
        string hesapNo, hesapSahibi, bakiye, hesapTuru, meslekKodu, aciklama, hesapDurumKodu;
        public Bilgiler(string hesapNo,string hesapSahibi, string bakiye, string hesapTuru,string  meslekKodu,string  aciklama, string hesapDurumKodu)
        {
            this.hesapNo = hesapNo;
            this.hesapSahibi = hesapSahibi;
            this.bakiye = bakiye;
            this.hesapTuru = hesapTuru;
            this.meslekKodu = meslekKodu;
            this.aciklama = aciklama;
            this.hesapDurumKodu = hesapDurumKodu;
            InitializeComponent();
        }
        private void Bilgiler_Load(object sender, EventArgs e)
        {
            lblHesapNo.Text = hesapNo;
            lblHesapSahibi.Text = hesapSahibi;
            lblBakiye.Text = bakiye;
            lblDurumKodu.Text = hesapDurumKodu;
            lblMeslekKodu.Text = meslekKodu;
            lblAciklama.Text = aciklama;
            lblHesapTuru.Text = hesapTuru;
        }
    }
}
