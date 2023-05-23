using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : MainMenu
    {
        private readonly Dictionary<int, MenuItem> r_SubItems = new Dictionary<int, MenuItem>();
        private readonly string r_Title;
        public MenuItem Parent { get; set; }
        private int m_ItemIndex = 1;
        public Dictionary<int, MenuItem> SubItems
        {
            get { return r_SubItems; }
        }

        public string Title
        {
            get { return r_Title; }
        }

        public MenuItem(MenuItem i_Parent, string i_Title)
        {
            Parent = i_Parent;
            r_Title = i_Title;
        }

        public override string ToString()
        {
            return r_Title;
        }

        public void AddItem(MenuItem i_Item)
        {
            r_SubItems.Add(m_ItemIndex++, i_Item);
        }

        public void RemoveItem(MenuItem i_Item)
        {
            r_SubItems.Remove(i_Item.m_ItemIndex);
        }
    }
}
