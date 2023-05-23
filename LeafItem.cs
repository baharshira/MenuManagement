using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class LeafItem : MenuItem
    {
        private readonly List<IInvokeable> r_MethodsToInvoke = new List<IInvokeable>();
        public LeafItem(MenuItem i_Parent, string i_Title, IInvokeable i_MethodToInvoke)
        : base(i_Parent, i_Title)
        {
            i_Parent.AddItem(this);
            MethodsToInvoke.Add(i_MethodToInvoke);
        }

        public List<IInvokeable> MethodsToInvoke
        {
            get { return r_MethodsToInvoke; }
        }

        public void InvokeLeaf()
        {
            foreach (IInvokeable methodToInvoke in MethodsToInvoke)
            {
                Console.Clear();
                methodToInvoke.Invoke();
                Thread.Sleep(2500);
                Console.Clear();
            }
        }
    }
}
