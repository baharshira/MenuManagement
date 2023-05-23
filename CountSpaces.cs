using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountSpaces : IInvokeable
    {
        public void Invoke()
        {
            Console.WriteLine("Please enter a sentence");
            string sentence = Console.ReadLine();
            int counter = 0;

            foreach (char c in sentence)
            {
                if (c == ' ')
                {
                    counter++;
                }
            }

            string msg = string.Format(
@"Number of spaces is {0}", counter);

            Console.WriteLine(msg);
        }
    }
}
