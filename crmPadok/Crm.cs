using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace crmPadok
{
    class Crm
    {
        CookieContainer _container = new CookieContainer();
        CookieContainer container = new CookieContainer();

        string username, password;

        public Crm(string username,string password)
        {
            this.username = username;
            this.password = password;
        }
        public bool login()
        {
            try
            {
                string url = "https://ipc2.ptt.gov.tr/pttwebapproot/ipcservlet";
                Encoding encode = Encoding.ASCII;

                string tcNo = WebUtility.UrlEncode("");
                string cmd = WebUtility.UrlEncode("kontrolparola");
                string h_PageValidation = WebUtility.UrlEncode("ON");
                string secimtipi = WebUtility.UrlEncode("on");
                string sifreK = WebUtility.UrlEncode("");
                string musteriNo = username;
                musteriNo = WebUtility.UrlEncode(musteriNo);
                string sifre = password;
                sifre = WebUtility.UrlEncode(sifre);

                string fields = "TcNo=" + tcNo + "&" + "cmd=" + cmd + "&" + "h_PageValidation=" + h_PageValidation + "&" +
                    "secimtipi=" + secimtipi + "&" + "sifreK=" + sifreK + "&" + "musteriNo=" + musteriNo + "&" + "sifreM=" + sifre;
                byte[] data = encode.GetBytes(fields);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                request.CookieContainer = new CookieContainer();
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.Credentials = new System.Net.NetworkCredential(musteriNo, sifre);
                _container = request.CookieContainer;
                Stream str = request.GetRequestStream();
                str.Write(data, 0, data.Length);
                str.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                CookieCollection cookie = response.Cookies;
                Stream recStream = response.GetResponseStream();

                StreamReader read = new StreamReader(recStream, encode);
                string strResponse = read.ReadToEnd();
                string cookieHeader = response.Headers["Set-Cookie"];
                read.Close();
                response.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SmsApproval(string sms)
        {
            try
            {
                string url = "https://ipc2.ptt.gov.tr/pttwebapproot/ipcservlet";
                Encoding encode = Encoding.ASCII;
                string cmd = WebUtility.UrlEncode("kontrolparola");
                string h_PageValidation = WebUtility.UrlEncode("ON");
                string smsOTPSifre = WebUtility.UrlEncode(sms);

                string fields = "cmd=" + cmd + "&h_PageValidation=" + h_PageValidation + "&smsOTPSifre=" + smsOTPSifre;
                byte[] data = encode.GetBytes(fields);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                request.CookieContainer = _container;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                request.ContentLength = data.Length;
                container = request.CookieContainer;
                Stream str = request.GetRequestStream();
                str.Write(data, 0, data.Length);
                str.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public void getHesapNo()
        {
            string url = "https://ipc2.ptt.gov.tr/pttwebapproot/ipcservlet?cmd=kurumtahsilatgiristelefon";
            Encoding encode = Encoding.ASCII;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = container;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            HtmlDocument doc=GetHtmlDocument((new StreamReader(response.GetResponseStream())).ReadToEnd());
            
        }
        public System.Windows.Forms.HtmlDocument GetHtmlDocument(string html)
        {
            WebBrowser browser = new WebBrowser();
            browser.ScriptErrorsSuppressed = true;
            browser.DocumentText = html;
            browser.Document.OpenNew(true);
            browser.Document.Write(html);
            browser.Refresh();
            return browser.Document;
        }
    }
}
