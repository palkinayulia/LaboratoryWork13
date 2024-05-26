using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary10Lab;
using Лабораторная_работа_12_4;

namespace Лабораторная_работа__13
{
    public class MyObservableCollection<T> : MyCollection<T> where T : IInit, ICloneable, new()
    {
        public event Action<object, CollectionHandlerEventArgs> CollectionCountChanged;
        public event Action<object, CollectionHandlerEventArgs> CollectionReferenceChanged;

        protected virtual void OnCollectionCountChanged(CollectionHandlerEventArgs e)
        {
            CollectionCountChanged?.Invoke(this, e);
        }

        protected virtual void OnCollectionReferenceChanged(CollectionHandlerEventArgs e)
        {
            CollectionReferenceChanged?.Invoke(this, e);
        }

        public override void Add(T item)
        {
            base.Add(item);
            OnCollectionCountChanged(new CollectionHandlerEventArgs("Добавлено", item));
        }

        public override bool Remove(T item)
        {
            var result = base.Remove(item);
            if (result)
            {
                OnCollectionCountChanged(new CollectionHandlerEventArgs("Удалено", item));
            }
            return result;
        }

    }
}
