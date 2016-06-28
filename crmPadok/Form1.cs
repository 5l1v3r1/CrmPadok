using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web;
namespace crmPadok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CookieContainer cookieContainer = new CookieContainer();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string url = "https://ipc2.ptt.gov.tr/pttwebapproot/ipcservlet";
            Encoding encode = Encoding.ASCII;
          
            string tcNo = WebUtility.UrlEncode("");
            string cmd = WebUtility.UrlEncode("kontrolparola");
            string h_PageValidation = WebUtility.UrlEncode("ON");
            string secimtipi = WebUtility.UrlEncode("on");
            string sifreK = WebUtility.UrlEncode("");
            string musteriNo = txtMusteriNo.Text;
            musteriNo = WebUtility.UrlEncode(musteriNo);
            string sifre = txtSifre.Text;
            sifre = WebUtility.UrlEncode(sifre);

            string fields = "TcNo=" + tcNo + "&" + "cmd=" + cmd + "&" + "h_PageValidation=" + h_PageValidation + "&" +
                "secimtipi=" + secimtipi + "&" + "sifreK=" + sifreK + "&" + "musteriNo=" + musteriNo + "&" + "sifreM=" + sifre;
            byte[] data = encode.GetBytes(fields);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.CookieContainer = new CookieContainer();
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.Credentials = new System.Net.NetworkCredential(musteriNo, sifre);
            cookieContainer = request.CookieContainer;
            Stream str = request.GetRequestStream();
            str.Write(data, 0, data.Length);
            str.Close();
            HttpWebResponse response =(HttpWebResponse)request.GetResponse();
            Stream recStream = response.GetResponseStream();
            StreamReader read = new StreamReader(recStream, encode);
            string strResponse = read.ReadToEnd();
            string cookieHeader = response.Headers["Set-Cookie"];
            MessageBox.Show(strResponse);
            read.Close();
            response.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Crm objCrm = new Crm("1234", "1234");
            objCrm.getHesapNo();
        }
    }
}
