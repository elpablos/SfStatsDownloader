using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Parser
{
    public class Program
    {
        public static readonly string DataColumnName = "Date";

        public static void Main(string[] args)
        {
            string result = null;
            result = File.ReadAllText("../../../result.html", Encoding.UTF8);
            var doc = new HtmlDocument();
            doc.LoadHtml(result);

            var content = doc.DocumentNode.Descendants("div").FirstOrDefault(d => d.Attributes.Contains("id") && d.Attributes["id"].Value == "content");
            var header = content.Descendants("h1").FirstOrDefault();

            var table = content.Descendants("table").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "meccstabla");
            var trs = table.Descendants("tr");

            var dataTable = new DataTable();
            dataTable.Columns.Add(DataColumnName);

            DataRow row = null;
            foreach (var tr in trs)
            {
                var trClass = tr.Attributes.Contains("class") ? tr.Attributes["class"].Value : string.Empty;

                if (trClass == "tablaheader")
                {
                    var tds = tr.Descendants("td");
                    foreach (var td in tds)
                    {
                        dataTable.Columns.Add(td.InnerText.Trim());
                    }
                }
                else
                {
                    // radek s casem
                    if (trClass == "alheader")
                    {
                        // pridam radek
                        if (row != null) dataTable.Rows.Add(row);

                        // novy radek
                        row = dataTable.NewRow();
                        // pridej datum
                        row[DataColumnName] = tr.InnerText.Trim(); // todo prevezt na datum
                    }
                    // radek s daty
                    else
                    {
                        int i = 1;
                        var tds = tr.Descendants("td");
                        foreach (var td in tds)
                        {
                            row[i] = td.InnerText;
                            i++;
                        }
                    }
                }
            }
        }
    }
}
