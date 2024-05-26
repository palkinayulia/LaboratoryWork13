using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__13
{
    internal class JournalEntry
    {
        public string CollectionName { get; }
        public string ChangeType { get; }
        public string Data { get; }

        public JournalEntry(string collectionName, string changeType, string data)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            Data = data;
        }

        public override string ToString()
        {
            return $"[{CollectionName}] - {ChangeType} - {Data}";
        }
    }
}
