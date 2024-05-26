using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__13
{
    internal class Journal
    {
        private List<JournalEntry> entries = new List<JournalEntry>();

        public void Log(JournalEntry entry)
        {
            entries.Add(entry);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }
}
