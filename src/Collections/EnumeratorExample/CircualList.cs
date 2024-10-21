using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorExample;

public class CircualList<T> : IEnumerable<T>
{
    private List<T> _items = new List<T>();

    private int _head;

    public int Count 
    {
        get
        {
            return _items.Count;
        }
    }

    public void Add(T item)
    {
        _items.Add(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        int currentIndex = _head;

        while(true)
        {
            yield return _items[currentIndex];
            currentIndex = (currentIndex + 1) % _items.Count;
        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
