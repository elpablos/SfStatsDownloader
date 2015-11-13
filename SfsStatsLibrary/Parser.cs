using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SfsStatsLibrary
{
    public class Parser
    {
        public static readonly string IDColumnName = "ID";

        public static readonly string DataColumnName = "Date";

        public static readonly string SportColumnName = "Sport";

        public static readonly string ScoreWithoutColumnName = "Score without OT";

        public static readonly string HomeWithoutColumnName = "Home without OT";

        public static readonly string AwayWithoutColumnName = "Away without OT";

        public static readonly string ScoreRawColumnName = "Score raw";

        private string[] SplitterConst = new string[] { "<br>" };

        private const int SleepConst = 250;

        public DataTable Parse(DataTable dataTable, string html)
        {
            bool isNew = false;
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var content = doc.DocumentNode.Descendants("div").FirstOrDefault(d => d.Attributes.Contains("id") && d.Attributes["id"].Value == "content");
            var header = content.Descendants("h1").FirstOrDefault();

            var table = content.Descendants("table").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "meccstabla");
            var trs = table.Descendants("tr");

            if (dataTable == null)
            {
                // nové
                isNew = true;
                dataTable = new DataTable();

                dataTable.Columns.Add(IDColumnName);
                dataTable.Columns.Add(DataColumnName);
                dataTable.Columns.Add(SportColumnName);
            }

            DataRow row = null;

            // datum
            string dateString = null;

            foreach (var tr in trs)
            {
                var trClass = tr.Attributes.Contains("class") ? tr.Attributes["class"].Value : string.Empty;

                if (trClass == "tablaheader")
                {
                    // pokud neni novy, tak preskoc
                    if (isNew)
                    {
                        var tds = tr.Descendants("td");
                        foreach (var td in tds)
                        {
                            var column = td.InnerText.Trim();
                            if (column == "Score")
                            {
                                dataTable.Columns.Add("Home " + column);
                                dataTable.Columns.Add(column);
                                dataTable.Columns.Add("Away " + column);
                            }
                            else
                            {
                                dataTable.Columns.Add(column);
                            }
                        }
                    }
                }
                else
                {
                    // radek s casem
                    if (trClass == "alheader")
                    {
                        // pridej datum
                        var date = tr.InnerText.Trim();
                        date = date.Substring(0, date.IndexOf("@") - 2);
                        DateTime parsedDate;
                        // Fri, 2006 April 21. @ 17:00 "ddd, yyyy MMMM dd. @ hh:mm"
                        if (DateTime.TryParseExact(date, "ddd, yyyy MMMM dd", CultureInfo.CreateSpecificCulture("en-US"),
                                   DateTimeStyles.None, out parsedDate))
                        {
                            dateString = parsedDate.ToShortDateString();
                        }
                        else
                        {
                            dateString = tr.InnerText.Trim();
                        }
                    }
                    // radek s daty
                    else
                    {
                        // pridam radek
                        if (row != null) dataTable.Rows.Add(row);

                        // novy radek
                        row = dataTable.NewRow();

                        // id & datum
                        row[IDColumnName] = dataTable.Rows.Count;
                        row[DataColumnName] = dateString;

                        int i = 3;
                        var tds = tr.Descendants("td");
                        foreach (var td in tds)
                        {
                            // skore AJAX
                            if (td.Attributes["class"] != null && td.Attributes["class"].Value == "eredmeny")
                            {
                                // sample: ajax:/ajax/scores.php?sport=hockey&id=25581&rid=
                                // http://www.sfstats.net/ajax/scores.php?sport=hockey&id=25581&rid=

                                Uri uri = new Uri(td.Attributes["title"].Value);
                                var p = System.Web.HttpUtility.ParseQueryString(uri.Query);
                                row[IDColumnName] = p.Get("id");
                                row[SportColumnName] = p.Get("sport");

                                var parts = td.InnerText.Split(':');
                                
                                row[i++] = parts[0];    // home
                                row[i++] = td.InnerText;// score 
                                row[i++] = parts[1];    // away
                            }
                            else
                            {
                                row[i] = td.InnerText.Replace(".", ",");
                                i++;
                            }
                        }
                    }
                }
            }

            return dataTable;
        }

        public string[] ParseLinks(string html)
        {
            List<string> list = new List<string>();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var links = doc.DocumentNode.Descendants("a");
            foreach (var link in links)
            {
                list.Add(link.Attributes["href"].Value);

            }

            return list.ToArray();
        }

        public DataTable ParseExtend(DataTable dataTable, Downloader downloader, string ajaxPage, bool skip)
        {
            if (!dataTable.Columns.Contains(ScoreWithoutColumnName))
            {
                dataTable.Columns.Add(ScoreWithoutColumnName);
            }

            if (!dataTable.Columns.Contains(ScoreRawColumnName))
            {
                dataTable.Columns.Add(ScoreRawColumnName);
            }

            if (!dataTable.Columns.Contains(HomeWithoutColumnName))
            {
                dataTable.Columns.Add(HomeWithoutColumnName);
            }

            if (!dataTable.Columns.Contains(AwayWithoutColumnName))
            {
                dataTable.Columns.Add(AwayWithoutColumnName);
            }

            foreach (DataRow row in dataTable.Rows)
            {
                // přeskakování 
                if (skip && Math.Abs(int.Parse(row["Home score"].ToString()) - int.Parse(row["Away score"].ToString())) != 1) continue;

                // sample: ajax:/ajax/scores.php?sport=hockey&id=25581&rid=
                // http://www.sfstats.net/ajax/scores.php?sport=hockey&id=25581&rid=

                    // sestavim url
                    string url = AddUrl(AddUrl(
                    ajaxPage, SportColumnName, row[SportColumnName].ToString()), 
                    IDColumnName, row[IDColumnName].ToString()).ToLower();

                // stahnu html
                string html = downloader.DownloadPage(url);

                // zpracuju html
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                // vytahnu cely skore
                string score = doc.DocumentNode.SelectSingleNode("//p").InnerHtml;

                row[ScoreRawColumnName] = score;

                int home = 0;
                int away = 0;

                string scoreFinal = string.Empty;
                ParseScore(score, out scoreFinal, out home, out away);

                row[ScoreWithoutColumnName] = scoreFinal;
                row[HomeWithoutColumnName] = home;
                row[AwayWithoutColumnName] = away;

                System.Threading.Thread.Sleep(SleepConst);
            }

            return dataTable;
        }

        private void ParseScore(string html, out string score, out int home, out int away)
        {
            var scoreParts = html.Split(SplitterConst, StringSplitOptions.RemoveEmptyEntries);

            home = 0;
            away = 0;

            foreach (var part in scoreParts)
            {
                if (part != null && part.StartsWith("I"))
                {
                    string pureScore = part.Substring(part.IndexOf('(') + 1, part.IndexOf(')') - (part.IndexOf('(') + 1));
                    var parts = pureScore.Split(':');

                    home += int.Parse(parts[0]);    // home
                    away += int.Parse(parts[1]);    // away
                }
            }

            score = home + " : " + away;
        }

        /// <summary>
        /// Přidá do adresy zadaný parametr
        /// </summary>
        public static string AddUrl(string url, string name, string value)
        {
            var query = string.Format("{0}={1}", name, System.Web.HttpUtility.UrlEncode(value));

            if (url.Contains(name + "="))
            {
                // Parametr url obsahuje
                int valuebegin = url.IndexOf(name + "=", 0);
                int valueend = url.IndexOf("&", valuebegin);
                if (valueend == -1) valueend = url.Length;

                return url.Substring(0, valuebegin) + query + url.Substring(valueend);
            }
            else
            {
                // Zjistim, zda obsahuje adresa nejake parametry
                if (url.Contains("?"))
                {
                    // url obsahuje parametry
                    url += "&";
                }
                else
                {
                    // prvni parametr
                    url += "?";
                }
                return url += query;
            }
        }

    }
}
