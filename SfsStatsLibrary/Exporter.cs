using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace SfsStatsLibrary
{
    public class Exporter
    {
        private string delimiter = ";";

        public string Delimiter
        {
            get { return delimiter; }
            set { delimiter = value; }
        }


        public void ExportCsv(string path, DataTable data)
        {
            // save table
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = data.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(delimiter, columnNames));

            foreach (DataRow r in data.Rows)
            {
                IEnumerable<string> fields = r.ItemArray.Select(field =>
                  string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(delimiter, fields));
            }

            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }
    }
}
