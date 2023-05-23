using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowVersion : IInvokeable
    {
        public void Invoke()
        {
            Console.WriteLine("Version is 22.2.4.8950");
        }
    }
}
