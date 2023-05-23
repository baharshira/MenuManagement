using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public static class TestInterfaceMenu
    {
        public static void InitMenu()
        {
            MainMenu menu = new MainMenu();
            MenuItem interfaceMenu = new MenuItem(null, "***Interface Main Menu***");
            menu.CurrentMenu = interfaceMenu;
            addShowTimeOrDate(interfaceMenu);
            addShowVersionAndCountSpaces(interfaceMenu);
            menu.Show();
        }

        private static void addShowTimeOrDate(MenuItem i_MenuItem)
        {
            MenuItem showDateOrTime = new MenuItem(null, "Show Date/Time");

            i_MenuItem.AddItem(showDateOrTime);
            LeafItem showTime = new LeafItem(showDateOrTime, "Show Time", new ShowTime());
            LeafItem showDate = new LeafItem(showDateOrTime, "Show Date", new ShowDate());
        }

        private static void addShowVersionAndCountSpaces(MenuItem i_MenuItem)
        {
            MenuItem versionAndSpaces = new MenuItem(null, "Version And Spaces");

            i_MenuItem.AddItem(versionAndSpaces);
            LeafItem countSpaces = new LeafItem(versionAndSpaces, "Count Spaces", new CountSpaces());
            LeafItem showVersion = new LeafItem(versionAndSpaces, "Show Version", new ShowVersion());
        }
    }
}
