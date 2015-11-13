using System;
using System.Windows.Forms;

namespace SfSStatsDownloader
{
    public class WaitCursor : IDisposable
    {
        private Cursor previous;

        public WaitCursor()
        {
            previous = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
        }

        public void Dispose()
        {
            Cursor.Current = previous;
        }
    }
}