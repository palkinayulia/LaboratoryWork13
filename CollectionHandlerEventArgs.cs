using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__13
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

    public class CollectionHandlerEventArgs
    {
        public string ChangeType { get; }
        public object RelatedObject { get; }

        public CollectionHandlerEventArgs(string changeType, object relatedObject)
        {
            ChangeType = changeType;
            RelatedObject = relatedObject;
        }
    }
}
