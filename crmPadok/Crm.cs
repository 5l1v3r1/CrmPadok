using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Runtime.InteropServices;

namespace crmPadok
{
   public class Crm
    {

        CookieContainer _container = new CookieContainer();

        Dictionary<string, string> list = new Dictionary<string, string>();

        public CookieContainer Container
        {
            get
            {
                return _container;
            }

            set
            {
                _container = value;
            }
        }

        public Dictionary<string, string> List
        {
            get
            {
                return list;
            }

            set
            {
                list = value;
            }
        }

        private void getFirstCookie()
        {
            CookieCollection cookies = new CookieCollection();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ipc2.ptt.gov.tr/pttwebapproot/ipcservlet");
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(cookies);
            //Get the response from the server and save the cookies from the first request..
            try
            {

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                cookies = response.Cookies;
                response.Close();
                _container.Add(cookies);
               
            }
            catch (Exception)
            {

            }
        }
        public bool login(string username, string password)
        {
           
            if (_container.Count != 0)
                deleteCookies();
            getFirstCookie();
            try
            {
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

                string fields = "TcNo="+ tcNo 
                    + "&cmd=" + cmd 
                    + "&h_PageValidation=" + h_PageValidation 
                    + "&secimtipi=" + secimtipi 
                    + "&sifreK=" + sifreK 
                    + "&musteriNo=" + musteriNo 
                    + "&sifreM=" + sifre;

                byte[] data = encode.GetBytes(fields);
                HttpWebRequest request = getRequest(data);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream recStream = response.GetResponseStream())
                    {
                        using (StreamReader read = new StreamReader(recStream, Encoding.UTF8))
                        {
                            string strResponse = read.ReadToEnd();
                            if (!strResponse.Contains("UYARI:Bilgileri eksik girdiniz")&&
                                !strResponse.Contains("UYARI:(P10012)")&&
                                !strResponse.Contains("UYARI:(P00120)")&&
                                !strResponse.Contains("UYARI:(P10006)")&&
                                !strResponse.Contains("UYARI:(P10005)")&&
                                !strResponse.Contains("UYARI:(P00031)"))
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
        public void deleteCookies()
        {
            CookieContainer container = new CookieContainer();
            _container = container;
        }
        private HttpWebRequest getRequest(byte[] data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ipc2.ptt.gov.tr/pttwebapproot/ipcservlet");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            request.CookieContainer = _container;
           // request.CookieContainer.Add(cookies);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.AllowWriteStreamBuffering = true;
            request.ProtocolVersion = HttpVersion.Version11;
            request.AllowAutoRedirect = true;
            
            //post data to server
            Stream str = request.GetRequestStream();
            str.Write(data, 0, data.Length);
            str.Close();
            return request;
        }
        public bool SmsApproval(string sms)
        {
            try
            {
                Encoding encode = Encoding.ASCII;
                string cmd = WebUtility.UrlEncode("kontrolotp");
                string h_PageValidation = WebUtility.UrlEncode("OFF");
                string smsOTPSifre = WebUtility.UrlEncode(sms);
                string fields = "cmd=" + cmd + "&h_PageValidation=" + h_PageValidation + "&smsOTPSifre=" + smsOTPSifre;
                byte[] data = encode.GetBytes(fields);
                HttpWebRequest request = getRequest(data);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    string responseText = new StreamReader(response.GetResponseStream(),Encoding.Default).ReadToEnd();
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
            list.Add("cmd", WebUtility.UrlEncode("kurumtahsilatkurumsecildi"));
            list.Add("h_PageValidation", WebUtility.UrlEncode("ON"));
            try
            {
                string url = "https://ipc2.ptt.gov.tr/pttwebapproot/ipcservlet?cmd=kurumtahsilatgiristelefon";
                Encoding encode = Encoding.ASCII;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                request.CookieContainer = _container;
                string hesapnoPlText = "";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                  HtmlAgilityPack. HtmlDocument doc1 = new HtmlAgilityPack. HtmlDocument();
                    doc1.LoadHtml((new StreamReader(response.GetResponseStream(), Encoding.Default)).ReadToEnd());
                    var node = doc1.DocumentNode.SelectNodes("//table//center//option");
                    if (node != null)
                    {
                        list.Add("hesapno", node[0].NextSibling.InnerHtml);
                        hesapnoPlText = (node[0].OuterHtml.ToString()).Substring(15, 15);
                    }
                }
                string cmd = WebUtility.UrlEncode("kurumtahsilatkurumbilgileri");
                string h_PageValidation = WebUtility.UrlEncode("ON");
                string kurumtipi = WebUtility.UrlEncode("TELEFON");
                string secilenHesapNumarasi = WebUtility.UrlEncode(hesapnoPlText);
                string field = "cmd="+cmd+ "&h_PageValidation="+ h_PageValidation+ "&kurumtipi="+kurumtipi+"&secilenHesapNumarasi="+secilenHesapNumarasi;
                byte[] data = encode.GetBytes(field);

                HttpWebRequest request2 = getRequest(data);
                string htmlText = "";
                using (HttpWebResponse response = (HttpWebResponse)request2.GetResponse())
                {
                    htmlText = (new StreamReader(response.GetResponseStream(),Encoding.Default).ReadToEnd());
                }
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlText);
                var nodes = doc.DocumentNode.SelectNodes("//table//tr/td");
                if (nodes != null)
                {
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        if (nodes[i].InnerHtml == "HESAP SAHİBİ")
                        {
                            list.Add("hesapSahibi", WebUtility.UrlEncode(nodes[i + 1].InnerText));
                        }
                        if (nodes[i].InnerHtml == "KULLANILABİLİR BAKİYE")
                        {
                            list.Add("kullanilabirbakiye", (nodes[i + 1].InnerText).Trim().Replace("nbsp", ""));
                        }
                    }
                }
                nodes = doc.DocumentNode.SelectNodes("//table//tr//input");
                if (nodes != null)
                {
                    foreach (var node in nodes)
                    {
                        if (node.OuterHtml.Contains("bakiye") && !node.OuterHtml.Contains("kullanilabilirbakiye"))
                        {
                            string nodetext = node.OuterHtml.ToString();
                            list.Add("bakiye", ((nodetext.Substring(nodetext.IndexOf("value="))).Replace("value=", "")).Trim('"', '<', '>', ' ').Replace("'", "").Replace("nbsp", " "));
                        }
                        else if (node.OuterHtml.Contains("hesapTuru"))
                        {
                            string nodetext = node.OuterHtml.ToString();
                            list.Add("hesapTuru", ((nodetext.Substring(nodetext.IndexOf("value="))).Replace("value=", "")).Trim('"', '<', '>', ' ').Replace("'", "").Replace("&nbsp;", " "));
                        }
                        else if (node.OuterHtml.Contains("meslekkodu"))
                        {
                            string nodetext = node.OuterHtml.ToString();
                            list.Add("meslekkodu", ((nodetext.Substring(nodetext.IndexOf("value="))).Replace("value=", "")).Trim('"', '<', '>', ' ').Replace("'", "").Replace("&nbsp;", " "));
                        }
                        else if (node.OuterHtml.Contains("aciklama"))
                        {
                            string nodetext = node.OuterHtml.ToString();
                            list.Add("aciklama", ((nodetext.Substring(nodetext.IndexOf("value="))).Replace("value=", "")).Trim('"', '<', '>', ' ').Replace("'", "").Replace("&nbsp;", " "));
                        }
                        else if (node.OuterHtml.Contains("hesapdurumkodu"))
                        {
                            string nodetext = node.OuterHtml.ToString();
                            list.Add("hesapdurumkodu", ((nodetext.Substring(nodetext.IndexOf("value="))).Replace("value=", "")).Trim('"', '<', '>', ' ').Replace("'", "").Replace("&nbsp;", " "));
                        }
                        else if (node.OuterHtml.Contains("kullanilabilirkmh"))
                        {
                            string nodetext = node.OuterHtml.ToString();
                            list.Add("kullanilabilirkmh", ((nodetext.Substring(nodetext.IndexOf("value="))).Replace("value=", "")).Trim('"', '<', '>', ' ').Replace("'", "").Replace("&nbsp;", " "));
                        }
                        else if (node.OuterHtml.Contains("kmhdurum"))
                        {
                            string nodetext = node.OuterHtml.ToString();
                            list.Add("kmhdurum", ((nodetext.Substring(nodetext.IndexOf("value="))).Replace("value=", "")).Trim('"', '<', '>', ' ').Replace("'", "").Replace("&nbsp;", " "));
                        }
                        else if (node.OuterHtml.Contains("vergino"))
                        {
                            string nodetext = node.OuterHtml.ToString();
                            list.Add("vergino", ((nodetext.Substring(nodetext.IndexOf("value="))).Replace("value=", "")).Trim('"', '<', '>', ' ').Replace("'", "").Replace("&nbsp;", " "));
                        }
                        else if (node.OuterHtml.Contains("kimlikno"))
                        {
                            string nodetext = node.OuterHtml.ToString();
                            list.Add("kimlikno", ((nodetext.Substring(nodetext.IndexOf("value="))).Replace("value=", "")).Trim('"', '<', '>', ' ').Replace("'", "").Replace("&nbsp;", " "));
                        }
                    }
                }
                list.Add("kurumId", WebUtility.UrlEncode("60"));
                list.Add("kurumKod", WebUtility.UrlEncode("5"));
                list.Add("kurumAd", WebUtility.UrlEncode("TURKTELEKOM"));
                list.Add("kurumParaCinsiId", WebUtility.UrlEncode("3"));
                list.Add("kurumParaCinsiText", WebUtility.UrlEncode("Yeni Türk Lirasý"));
                list.Add("kurumJspAdi", WebUtility.UrlEncode("ipc/IPCTurkTelekomTahsilatGiris.jsp"));
                list.Add("kurumTahsilatTipi", WebUtility.UrlEncode("TELEFON"));
                list.Add("kurumMesajTipi", WebUtility.UrlEncode("510"));
                list.Add("kurumIslemTuru", WebUtility.UrlEncode( "TELEFON"));
                list.Add("kurumAciklama", WebUtility.UrlEncode( "TÜRK TELEKOM ÝNTERNET (TTNET)"));
                list.Add("kurumGirisTipi", WebUtility.UrlEncode("1"));
                list.Add("kurumOnlineDurum", WebUtility.UrlEncode("0"));
                list.Add("kurumParaCinsiKod", WebUtility.UrlEncode("TL"));
                File.WriteAllText("C:\\users\\galatasaray\\desktop\\cookiefile.txt", _container.GetCookieHeader(new Uri("https://ipc2.ptt.gov.tr/pttwebapproot/ipcservlet")).ToString());
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public string[] adslFatura(string numara)
        //{
        //    try
        //    {
        //        Encoding encode = Encoding.ASCII;

        //        string fields = "";

        //        foreach (var key in List)
        //        {
        //            fields += key.Key + "=" + key.Value + "&";
        //        }
        //        fields = fields.Remove(fields.Length - 1, 1);
        //        byte[] data = encode.GetBytes(fields);

        //        HttpWebRequest request = getRequest(data);
        //        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //        {
        //            string responseText = (new StreamReader(response.GetResponseStream(), Encoding.Default)).ReadToEnd();
        //        }

        //        string post = "kurumId=60&kurumKod=5&kurumAd=TURKTELEKOM&" +
        //            "kurumParaCinsiId=3&kurumParaCinsiText=Yeni+T%FCrk+Liras%FD&kurumJspAdi=ipc%2FIPCTurkTelekomTahsilatGiris.jsp&" +
        //            "kurumTahsilatTipi=TELEFON&kurumMesajTipi=510&kurumIslemTuru=TELEFON&kurumAciklama=T%DCRK+TELEKOM+%DDNTERNET+%28TTNET%29&kurumParaCinsiKod=TL&" +
        //            "kurumOnlineDurum=0&selectedKayitID=&hesapno=" + List["hesapno"] + "&hesapSahibi=+" + List["hesapSahibi"] + "&bakiye=" + List["bakiye"] + "&hesapTuru=" + List["hesapTuru"] +
        //            "&meslekkodu=" + List["meslekkodu"] + "&aciklama=" + List["aciklama"] + "&hesapdurumkodu=" + List["hesapdurumkodu"] + "&erisimTipi=1&erisimNo=" + numara + "&cmd=telefontahsilatfaturasorgula&h_PageValidation=ON";
        //        byte[] postData = encode.GetBytes(post);

        //        HttpWebRequest request2 = getRequest(postData);
        //        string responseHtml = "";
        //        //########################################//
        //        using (HttpWebResponse response = (HttpWebResponse)request2.GetResponse())
        //        {
        //            responseHtml = (new StreamReader(response.GetResponseStream(), Encoding.Default).ReadToEnd());
        //        }
        //        //########################################//
        //        HtmlDocument doc = new HtmlDocument();
        //        doc.LoadHtml(responseHtml);
        //        var node = doc.GetElementbyId("Table3");
        //        string text2 = "";
        //        var nodes = doc.DocumentNode.SelectNodes("//input");
        //        if (nodes != null)
        //        {
        //            foreach (var item in nodes)
        //            {
        //                if (item.OuterHtml.Contains("checkbox"))
        //                {
        //                    text2 = item.OuterHtml.ToString();
        //                }
        //            }
        //        }
        //        string[] text = text2.Split('@');
        //        return text;
        //    }
        //    catch (Exception)
        //    {

        //        return new string[] { };
        //    }

        //}
        //public string[] telefonFatura(string numara)
        //{
        //    try
        //    {
        //        if (list.Count == 0)
        //            this.list = getHesapNo();
                
        //        Encoding encode = Encoding.ASCII;
        //        string fields = "";
        //        foreach (var key in List)
        //            fields += key.Key + "=" + key.Value + "&";

        //        fields = fields.Remove(fields.Length - 1, 1);
        //        byte[] data = encode.GetBytes(fields);
        //        HttpWebRequest request = getRequest(data);
        //        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //        {
        //            string responseText = (new StreamReader(response.GetResponseStream(), Encoding.Default)).ReadToEnd();
        //        }

        //        string post = "kurumId=63&kurumKod=2&kurumAd=TURKTELEKOM&" +
        //           "kurumParaCinsiId=3&kurumParaCinsiText=Yeni+T%FCrk+Liras%FD&kurumJspAdi=ipc%2FIPCTurkTelekomTahsilatGiris.jsp&" +
        //           "kurumTahsilatTipi=TELEFON&kurumMesajTipi=500&kurumIslemTuru=TELEFON&kurumAciklama=TÜRK TELEKOM EV ÝÞ TELEFONU&kurumParaCinsiKod=TL&" +
        //           "kurumOnlineDurum=0&selectedKayitID=&hesapno=" + List["hesapno"] + "&hesapSahibi=+" + List["hesapSahibi"] + "&bakiye=" + List["bakiye"] + "&hesapTuru=" + List["hesapTuru"] +
        //           "&meslekkodu=" + List["meslekkodu"] + "&aciklama=" + List["aciklama"] + "&hesapdurumkodu=" + List["hesapdurumkodu"] + "&erisimTipi=1&erisimNo=" + numara + "&cmd=telefontahsilatfaturasorgula&h_PageValidation=ON";
        //        byte[] postData = encode.GetBytes(post);
        //        HttpWebRequest request2 = getRequest(postData);
        //        string responseHtml = "";
        //        using (HttpWebResponse response = (HttpWebResponse)request2.GetResponse())
        //        {
        //            responseHtml = (new StreamReader(response.GetResponseStream(), Encoding.Default).ReadToEnd());
        //        }
        //        HtmlDocument doc = new HtmlDocument();
        //        doc.LoadHtml(responseHtml);
        //        var node = doc.GetElementbyId("Table3");
        //        string text2 = "";
        //        var nodes = doc.DocumentNode.SelectNodes("//input");
        //        if (nodes != null)
        //        {
        //            foreach (var item in nodes)
        //            {
        //                if (item.OuterHtml.Contains("checkbox"))
        //                {
        //                    text2 = item.OuterHtml.ToString();
        //                }
        //            }
        //        }
        //        string[] text = text2.Split('@');
        //        return text;
        //    }
        //    catch (Exception)
        //    {

        //        return new string[] { };
        //    }
        //}
    }
}
