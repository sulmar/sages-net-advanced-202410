using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExample;

internal class Depot
{
    private IDictionary<string, Stack<string>> _places = new Dictionary<string, Stack<string>>();

    public void AddItem(string item, string place)
    {
        Stack<string> stack;

        if (_places.ContainsKey(place))
        {
            stack = _places[place];          
        }
        else
        {
            stack = new Stack<string>();
            _places.Add(place, stack);
            
        }

        stack.Push(item);

    }

    public string SendItem(string place)
    {
        var stack = _places[place];

        var item = stack.Pop();

        return item;

    }

    public void DisplayDepotContents()
    {
        foreach (var place in _places)
        {
            Console.WriteLine(place.Key);

            var stack = place.Value;

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
