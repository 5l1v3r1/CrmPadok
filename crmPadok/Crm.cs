using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
namespace crmPadok
{
    class Crm
    {
        /// <summary>
        /// Container for first request
        /// </summary>
        CookieContainer _container = new CookieContainer();
        /// <summary>
        /// Container for second request
        /// </summary>
        CookieContainer container = new CookieContainer();

        public bool login(string username, string password)
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
                //post data to server
                using (Stream str = request.GetRequestStream())
                    str.Write(data, 0, data.Length);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream recStream = response.GetResponseStream())
                    {
                        using (StreamReader read = new StreamReader(recStream, Encoding.UTF8))
                        {
                            string strResponse = read.ReadToEnd();
                            read.Close();
                            response.Close();
                            if (!strResponse.Contains("UYARI:Bilgileri eksik girdiniz")&&!strResponse.Contains("UYARI:(P10012)")&&
                                !strResponse.Contains("UYARI:(P00120)")&&!strResponse.Contains("UYARI:(P10006)"))
                                return true;
                            else
                                return false;
                        }
                    }
                }
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
                request.AllowAutoRedirect = true;
                container = request.CookieContainer;
                Stream str = request.GetRequestStream();
                str.Write(data, 0, data.Length);
                str.Close();
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    string responseText = new StreamReader(response.GetResponseStream(),Encoding.UTF8).ReadToEnd();
                    if (responseText.Contains("HESAP İŞLEMLERİ"))
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public Dictionary<string,string> getHesapNo()
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            try
            {
                string url = "https://ipc2.ptt.gov.tr/pttwebapproot/ipcservlet?cmd=kurumtahsilatgiristelefon";
                // string url = "https://ipc2.ptt.gov.tr/pttwebapproot/ipcservlet";
                Encoding encode = Encoding.ASCII;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                request.CookieContainer = container;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml((new StreamReader(response.GetResponseStream())).ReadToEnd());
                    var nodes = doc.DocumentNode.SelectNodes("//table//center//option");
                    list.Add("HesapNo", nodes[0].NextSibling.InnerHtml);
                    list.Add("HesapnoPlText", (nodes[0].OuterHtml.ToString()).Substring(15, 15));
                }

                string cmd = WebUtility.UrlEncode("kurumtahsilatkurumbilgileri");
                string h_PageValidation = WebUtility.UrlEncode("ON");
                string kurumtipi = WebUtility.UrlEncode("TELEFON");
                string b1 = WebUtility.UrlEncode("DEVAM");
                string secilenHesapNumarasi = WebUtility.UrlEncode(list["HesapNoVal"]);
                string field = "cmd="+cmd+ "&h_PageValidation="+ h_PageValidation+ "&kurumtipi="+kurumtipi+"&b1="+b1+"&secilenHesapNumarasi="+secilenHesapNumarasi;
                byte[] data = encode.GetBytes(field);

                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("https://ipc2.ptt.gov.tr/pttwebapproot/ipcservlet");
                request2.CookieContainer = container;
                request2.Method = "POST";
                request2.ContentType = "application/x-www-form-urlencoded";
                request2.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                request2.ContentLength = data.Length;
                Stream str = request2.GetRequestStream();
                str.Write(data, 0, data.Length);
                str.Close();

                using (HttpWebResponse response = (HttpWebResponse)request2.GetResponse())
                {
                    string htmlText = (new StreamReader(response.GetResponseStream()).ReadToEnd());
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(htmlText);
                    var nodes = doc.DocumentNode.SelectNodes("//table//tr/td");
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        if (nodes[i].InnerHtml == "HESAP SAHİBİ")
                        {
                            list.Add("hesapSahibi",(nodes[i + 1].InnerText).Trim().Replace("             ", " "));
                        }
                        if (nodes[i].InnerHtml == "KULLANILABİLİR BAKİYE")
                        {
                            list.Add("kullanilabirBakiye",(nodes[i + 1].InnerText).Trim().Replace("&nbsp;", " "));
                        }
                    }
                    nodes = doc.DocumentNode.SelectNodes("//table//tr//input");
                    foreach (var node in nodes)
                    {
                        if (node.OuterHtml.Contains("bakiye"))
                        {
                            string nodetext = node.OuterHtml.ToString();
                            list.Add("bakiye", ((nodetext.Substring(nodetext.IndexOf("value="))).Replace("value=", "")).Trim('"', '<', '>', ' '));
                        }
                        else if (node.OuterHtml.Contains("hesapTuru"))
                        {
                            string nodetext = node.OuterHtml.ToString();
                            list.Add("hesapTuru", ((nodetext.Substring(nodetext.IndexOf("value="))).Replace("value=", "")).Trim('"', '<', '>', ' '));
                        }
                        else if (node.OuterHtml.Contains("meslekkodu"))
                        {
                            string nodetext = node.OuterHtml.ToString();
                            list.Add("meslekKodu",((nodetext.Substring(nodetext.IndexOf("value="))).Replace("value=", "")).Trim('"', '<', '>', ' '));
                        }
                        else if (node.OuterHtml.Contains("aciklama"))
                        {
                            string nodetext = node.OuterHtml.ToString();
                            list.Add("aciklama", ((nodetext.Substring(nodetext.IndexOf("value="))).Replace("value=", "")).Trim('"', '<', '>', ' '));
                        }
                        else if (node.OuterHtml.Contains("hesapdurumkodu"))
                        {
                            string nodetext = node.OuterHtml.ToString();
                            list.Add("hesapDurumKodu", ((nodetext.Substring(nodetext.IndexOf("value="))).Replace("value=", "")).Trim('"', '<', '>', ' '));
                        }
                    }

                }

                    return list;
            }
            catch
            {
                return null;
            }
        }
        public void telefonFatura(string numara)
        {

        }
    }
}
