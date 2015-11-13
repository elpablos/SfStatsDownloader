using SfsStatsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SfSStatsDownloader
{
    public partial class Form1 : Form
    {
        public Parser Parser { get; set; }

        public Downloader Downloader { get; set; }

        public DataTable Table { get; set; }

        public Exporter Exporter { get; set; }

        public Form1()
        {
            InitializeComponent();

            this.Text += " v" + Application.ProductVersion;

            Parser = new Parser();
            Downloader = new Downloader();
            Exporter = new Exporter();
#if DEBUG
            txtUrl.Text = "http://localhost/result.html;";
#else
            txtUrl.Text = "http://www.sfstats.net/hockey/leagues/2_Extraleague/2005-2006/allresults;";
#endif

        }

        public void SetUpUrl(string text)
        {
            txtUrl.Text = text.Replace("\n", ";");
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            using (new WaitCursor())
            {
                Table = null;

                var urls = txtUrl.Text.Split(';');
                foreach (var url in urls)
                {
                    string trimmedUrl = url.Trim();
                    if (string.IsNullOrEmpty(trimmedUrl)) continue;
                    var html = Downloader.DownloadPage(trimmedUrl);
                    Table = Parser.Parse(Table, html);
                    FillListStats(Table);
                }

                btnAjax.Enabled = btnExport.Enabled = true;
            }
        }

        private void FillListStats(DataTable dataTable)
        {
            listStats.BeginUpdate();
            listStats.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                foreach (ColumnHeader c in listStats.Columns)
                {
                    string columnName = c.Tag.ToString();
                    if ((columnName == "ID") || !dataTable.Columns.Contains(columnName)) continue;
                    item.SubItems.Add(row[columnName].ToString());
                }

                listStats.Items.Add(item);
            }

            listStats.EndUpdate();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (new WaitCursor())
            {
                if (saveExportDialog.ShowDialog() == DialogResult.OK)
                {
                    Exporter.ExportCsv(saveExportDialog.FileName, Table);
                    MessageBox.Show("Data byla exportována", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtUrl_Click(object sender, EventArgs e)
        {
            LinkForm form = new LinkForm();
            form.SetUpText(txtUrl.Text);
            form.Show(this);
        }

        private void btnAjax_Click(object sender, EventArgs e)
        {
            using (new WaitCursor())
            {
                Parser.ParseExtend(Table, Downloader, "http://www.sfstats.net/ajax/scores.php", chkSkip.Checked);
                FillListStats(Table);
            }
        }

        private void listStats_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyCode)
            {
                foreach (ListViewItem listViewItem in ((ListView)sender).SelectedItems)
                {
                    listViewItem.Remove();

                    var rows = Table.Select("ID=" + listViewItem.Text);
                    Table.Rows.Remove(rows[0]);
                }
            }
        }
    }
}
