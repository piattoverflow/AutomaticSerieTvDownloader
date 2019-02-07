using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.Net;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Ionic.Zip;
using CloudFlareUtilities;
using System.Net.Http;

namespace AutomaticSerieTvDownloader
{
    public partial class Form1 : Form
    {
        public string NomeSerie;
        List<Record> lsRecord = new List<Record>();
        List<Subspedia> ElencoSerieSubbate = new List<Subspedia>();
        List<Sottotitoli> ElencoSottotitoli = new List<Sottotitoli>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmB_qualita.SelectedIndex = 0;
            cmB_sort.SelectedIndex = 0;
        }

        private void btn_cerca_Click(object sender, EventArgs e)
        {
            Cerca();
        }

        private string Format_S_E(int stagione, int episodio)
        {
            string stag = (stagione < 10) ? "0" + stagione.ToString() : stagione.ToString();
            string epi = (episodio < 10) ? "0" + episodio.ToString() : episodio.ToString();

            return "S" + stag + "E" + epi;
        }

        public void Cerca()
        {
            lsRecord.Clear();

            int n_stagione, n_episodio;
            bool serie_finita = false;
            bool episodi_finiti = false;

            n_stagione = (int)nUpDwn_Serie.Value;
            n_episodio = (int)nUpDwn_Episodio.Value;
            string stag_epi = Format_S_E(n_stagione, n_episodio);

            //Ottiene liste di tutte le serie tv e sottotitoli di una serie
            GetFullSeries(ref ElencoSerieSubbate);
            GetAllSubtitleOfSerie(GetIdOfShow(txtbx_SerieTv.Text.Trim()), ref ElencoSottotitoli);
            
            //while (!serie_finita)
            //{
            while (!episodi_finiti)
            {
                stag_epi = Format_S_E(n_stagione, n_episodio);
                NomeSerie = Costanti.sortSearch + txtbx_SerieTv.Text.Trim().Replace(' ', '+') + "+" + stag_epi /*+ Filtra_ordinamento() + "1/"*/;

                try
                {
                    HtmlAgilityPack.HtmlDocument doc = Send_Request(NomeSerie);////body//div[@class='container--fluid']//div[@class='row']//div[@class='col']
                    HtmlNodeCollection nodo = doc.DocumentNode.SelectNodes("//div[@id='main']//tbody//tr");
                    Record record = new Record();

                    //cerca la serie
                    foreach (HtmlNode node in nodo)
                    {
                        if ((cmB_qualita.SelectedIndex == 1 && node.SelectSingleNode("//td//div[@class='torrents_table__torrent_name']//div[@class='text--left']//a//b").InnerText.Contains("720p"))
                            || (cmB_qualita.SelectedIndex == 2 && node.SelectSingleNode("//td//div[@class='torrents_table__torrent_name']//div[@class='text--left']//a//b").InnerText.Contains("1080p"))
                            || (cmB_qualita.SelectedIndex == 0))
                        {
                            record.Name = node.SelectSingleNode("//td//div[@class='torrents_table__torrent_name']//div[@class='text--left']//a//b").InnerText;
                            record.Url = node.SelectSingleNode("//td//div[@class='torrents_table__torrent_name']//div[@class='text--left']//a").Attributes["href"].Value;
                            record.Seeds = node.SelectSingleNode("//td[@class='text--nowrap text--center text--success']").InnerText;
                            //record.Date = node.SelectSingleNode("//td[@class='coll-date']").InnerText;
                            record.Magnet = node.SelectSingleNode("//td//div[@class='torrents_table__torrent_name']//div[@class='torrents_table__actions']//a[@class='button button--small']").Attributes["href"].Value;

                            lsRecord.Add(record);
                            break;
                        }
                        node.Remove();
                    }
                    //cerca il magnet
                    //doc = Send_Request(record.Url);
                    //record.Magnet = doc.DocumentNode.SelectSingleNode("//td//div[@class='torrents_table__torrent_name']//div[@class='torrents_table__actions']//a[@class='button button--small']").Attributes["href"].Value;
                    //Cerca i subs
                    try
                    {
                        record.Sub = GetSubtitle(n_stagione, n_episodio);
                    }
                    catch (Exception ess)
                    {

                    }
                }
                catch (Exception ess)
                {
                    episodi_finiti = true;

                    if (n_episodio == 1)
                        serie_finita = true;
                }
                n_episodio++;
            }
            //    n_episodio = 1;
            //    episodi_finiti = false;
            //    n_stagione++;
            //}

            PopolaDataGrid();
        }

        public void PopolaDataGrid()
        {
            var bindingList = new BindingList<Record>(lsRecord);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        public async Task<HtmlAgilityPack.HtmlDocument> Send_RequestAsync(string url)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();

            try
            {
                // Create the clearance handler.
                var handler = new ClearanceHandler
                {
                    MaxRetries = 2 // Optionally specify the number of retries, if clearance fails (default is 3).
                };

                // Create a HttpClient that uses the handler to bypass CloudFlare's JavaScript challange.
                var client = new HttpClient(handler);

                // Use the HttpClient as usual. Any JS challenge will be solved automatically for you.
                var content = await client.GetStringAsync(url);
                doc.Load(content);
            }
            catch (AggregateException ex) when (ex.InnerException is CloudFlareClearanceException)
            {
                // After all retries, clearance still failed.
            }
            catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
            {
                // Looks like we ran into a timeout. Too many clearance attempts?
                // Maybe you should increase client.Timeout as each attempt will take about five seconds.
            }

            return doc;
        }


        public HtmlAgilityPack.HtmlDocument Send_Request(string url)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:64.0) Gecko/20100101 Firefox/64.0";
            Stream dataStream = request.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            doc.LoadHtml(responseFromServer);

            return doc;
        }


        public string Filtra_ordinamento()
        {
            string ordinamento = "/" + cmB_sort.Text;
            bool crescente = chckBx_sortType.Checked;
            //desc decrescente asc crescente
            ordinamento += (!crescente) ? "/desc/" : "/asc/";

            return ordinamento.ToLower();
        }

        public void Scarica()
        {
            foreach (Record elm in lsRecord)
            {
                Process.Start(elm.Magnet);

                //scarica sub
                if (elm.Sub != "" && elm.Sub != null)
                {
                    using (WebClient wc = new WebClient())
                    {
                        byte[] fileBytes = wc.DownloadData(elm.Sub);

                        string tipo = wc.ResponseHeaders.Get(2);
                        string nomeSub = textBox1.Text + elm.Name + tipo.Substring(tipo.LastIndexOf('.'));

                        File.WriteAllBytes(nomeSub, fileBytes);
                        AnalizeSub(nomeSub);
                    }
                }
            }
        }

        public void AnalizeSub(string dirZip)
        {//se è uno zip estrare il file
            if (dirZip.Substring(dirZip.LastIndexOf('.') + 1) == "zip")
            {
                using (ZipFile zip = ZipFile.Read(dirZip))
                {
                    ZipEntry bckp = new ZipEntry(); 
                    foreach (ZipEntry e in zip)
                    {
                        bckp = e;//creo una copia della entry così se non trova la qualità estrae il primo
                        if ((cmB_qualita.SelectedIndex == 0 && !e.FileName.Contains("720p") && !e.FileName.Contains("1080p")) || (cmB_qualita.SelectedIndex == 1 && e.FileName.Contains("720p")) || (cmB_qualita.SelectedIndex == 2 && e.FileName.Contains("1080p")))
                            break;
                    }

                    string name = dirZip.Substring(0, dirZip.LastIndexOf('.')) + ".srt";
                    bckp.Extract(textBox1.Text);
                    File.Move(textBox1.Text + bckp.FileName, name);
                }
                File.Delete(dirZip);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Scarica();
        }

        public void GetFullSeries(ref List<Subspedia> series)
        {
            string jsonElenco;

            using (WebClient wc = new WebClient())
            {
                jsonElenco = wc.DownloadString("https://www.subspedia.tv/API/elenco_serie");
            }

            ElencoSerieSubbate = Subspedia.FromJson(jsonElenco);
        }

        public int GetIdOfShow(string nome)
        {
            Subspedia elemento = ElencoSerieSubbate.Find(show => show.NomeSerie.ToLower() == nome.ToLower());

            return (elemento != null) ? (int)elemento.IdSerie : -1;
        }

        public void GetAllSubtitleOfSerie(int id, ref List<Sottotitoli> ElencoSottotitoli)
        {
            string jsonElenco;

            using (WebClient wc = new WebClient())
            {
                jsonElenco = wc.DownloadString("https://www.subspedia.tv/API/sottotitoli_serie?serie=" + id);

            }

            ElencoSottotitoli = Sottotitoli.FromJson(jsonElenco);
        }

        public string GetSubtitle(int stagione, int episodio)
        {
            Sottotitoli elemento = ElencoSottotitoli.Find(sub => sub.NumStagione == stagione && sub.NumEpisodio == episodio);

            return (elemento != null) ? elemento.LinkFile : "";
        }
    }
    public class Record
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Seeds { get; set; }
        public string Date { get; set; }

        public string Magnet { get; set; }
        public string Sub { get; set; }
    }
}
