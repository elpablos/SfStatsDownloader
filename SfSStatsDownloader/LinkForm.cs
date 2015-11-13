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
    public partial class LinkForm : Form
    {
        public LinkForm()
        {
            InitializeComponent();
            txtLinks.DetectUrls = false;
        }

        public void SetUpText(string text)
        {
            txtLinks.Text = text.Replace(";", Environment.NewLine);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Owner is Form1)
            {
                var parent = (Form1)Owner;
                parent.SetUpUrl(txtLinks.Text);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtParse_Click(object sender, EventArgs e)
        {
            string contents = Clipboard.GetText(TextDataFormat.Html);
            string newText = string.Empty;
            try
            {
                var links = new SfsStatsLibrary.Parser().ParseLinks(contents);
                var sb = new StringBuilder();
                foreach (var link in links)
                {
                    sb.Append(link);
                    if (!link.EndsWith("/allresults"))
                    {
                        sb.Append("/allresults");
                    }
                    sb.AppendLine();
                }
                newText = sb.ToString();
            }
            catch
            {
                newText = Clipboard.GetText();
            }

            txtLinks.Text += newText;
        }
    }
}