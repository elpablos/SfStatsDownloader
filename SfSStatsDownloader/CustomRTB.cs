using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SfSStatsDownloader
{
    public class CustomRTB : RichTextBox
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if ((keyData == (Keys.Control | Keys.V)))
            {
                IDataObject iData = Clipboard.GetDataObject();
                string contents = Clipboard.GetText(TextDataFormat.Html);

                if (iData.GetDataPresent(DataFormats.Text))
                {
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

                    Clipboard.SetData(DataFormats.Text, newText);
                    this.Paste();
                    Clipboard.SetData(DataFormats.Text, contents);
                }
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

    }
}
