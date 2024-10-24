using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskExample
{
    internal class ColorConsoleProgress : IProgress<string>
    {
        public void Report(string value)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(value);
            Console.ResetColor();
        }
    }

    

    // Własna implementacja klasy Progress<T>
    class DelegateProgress<T> : IProgress<T>
    {        
        private readonly Action<T> action;

        public DelegateProgress(Action<T> action)
        {
            this.action = action;
        }

        public void Report(T value)
        {
            action(value);
        }
    }
}
