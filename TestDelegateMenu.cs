using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;
using static Ex04.Menus.Delegates.LeafItem;

namespace Ex04.Menus.Test
{
    public static class TestDelegateMenu
    {
        public static void InitMenu()
        {
            MainMenu menu = new MainMenu();
            MenuItem delegateMenu = new MenuItem(null, "***Delegate Main Menu***");
            menu.CurrentMenu = delegateMenu;
            addShowTimeOrDate(delegateMenu);
            addShowVersionAndCountSpaces(delegateMenu);
            menu.Show();
        }

        private static void addShowTimeOrDate(MenuItem i_MenuItem)
        {
            MenuItem showDateOrTime = new MenuItem(null, "Show Date/Time");

            i_MenuItem.AddItem(showDateOrTime);
            LeafItem showTime = new LeafItem(showDateOrTime, "Show Time", showTime_Clicked);
            LeafItem showDate = new LeafItem(showDateOrTime, "Show Date", showDate_Clicked);
        }

        private static void addShowVersionAndCountSpaces(MenuItem i_MenuItem)
        {
            MenuItem versionAndSpaces = new MenuItem(null, "Version And Spaces");

            i_MenuItem.AddItem(versionAndSpaces);
            LeafItem countSpaces = new LeafItem(versionAndSpaces, "Count Spaces", countSpaces_Clicked);
            LeafItem showVersion = new LeafItem(versionAndSpaces, "Show Version", showVersion_Clicked);
        }

        private static void showTime_Clicked()
        {
            Console.Write(DateTime.Now.ToString("hh:mm tt"));
        }

        private static void showDate_Clicked()
        {
            Console.Write(DateTime.Now.ToString("dddd, dd MMMM yyyy"));
        }

        private static void showVersion_Clicked()
        {
            Console.WriteLine("Version is 22.2.4.8950");
        }

        private static void countSpaces_Clicked()
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
