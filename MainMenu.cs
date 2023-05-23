using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
         public MenuItem CurrentMenu { get; set; }
         public MenuItem ParentMenu { get; set; }

         public void Show()
         {
             const bool v_RunLoop = true;
             Stack<MenuItem> stackOfMenus = new Stack<MenuItem>();

             stackOfMenus.Push(CurrentMenu);
             while (v_RunLoop)
             {
                 printMenu(stackOfMenus);
                 int userChoice = getUserChoice();
                 Console.Clear();
                 initDelegateMenu(userChoice, stackOfMenus);
             }
         }

         private void initDelegateMenu(int i_UserChoice, Stack<MenuItem> i_StackOfMenus)
         {
             if (i_StackOfMenus.Count == 1 && i_UserChoice == 0)
             {
                 Environment.Exit(0);
             }

             if (i_StackOfMenus.Count > 1 && i_UserChoice == 0)
             {
                 i_StackOfMenus.Pop();
                 CurrentMenu = i_StackOfMenus.Peek();
             }

             if (i_UserChoice != 0)
             {
                 CurrentMenu.ParentMenu = i_StackOfMenus.Peek();
                 CurrentMenu = CurrentMenu.SubItems[i_UserChoice];
                 i_StackOfMenus.Push(CurrentMenu);
                 if (CurrentMenu is LeafItem)
                 {
                    handleDowncastingAndInvokeLeaf();
                    i_StackOfMenus.Pop();
                    CurrentMenu = i_StackOfMenus.Peek();
                 }
             }
         }

         private int validateUserChoice()
         {
             int choice;
             bool pursingSucceeded = int.TryParse(Console.ReadLine(), out choice);

             if (!pursingSucceeded || choice < 0 || choice > CurrentMenu.SubItems.Count)
             {
                 throw new ArgumentException("Invalid option out of menu, Please try again");
             }

             return choice;
         }

         private int getUserChoice()
         {
             bool invalidChoice = true;
             int userChoice = 0;

             while (invalidChoice)
             {
                 try
                 {
                     userChoice = validateUserChoice();
                     invalidChoice = false;
                 }
                 catch (ArgumentException ex)
                 {
                     Console.WriteLine(ex.Message);
                 }
             }

             return userChoice;
         }

        private void printMenu(Stack<MenuItem> i_StackOfMenus)
        {
            StringBuilder stringMenu = new StringBuilder();
            string numberOfItmes = string.Format("Please enter your choice (1-{0} or 0 to exit):", CurrentMenu.SubItems.Count);

            if (!(CurrentMenu is LeafItem))
            {
                stringMenu.AppendLine(CurrentMenu.Title);
                stringMenu.AppendLine("------------------------------");
                foreach (int key in CurrentMenu.SubItems.Keys)
                {
                    stringMenu.AppendLine(key + " -> " + CurrentMenu.SubItems[key].Title);
                }

                if (i_StackOfMenus.Count > 1)
                {
                    stringMenu.AppendLine("0 -> Back");
                }
                else
                {
                    stringMenu.AppendLine("0 -> Exit");
                }

                stringMenu.AppendLine(numberOfItmes);
            }

            Console.WriteLine(stringMenu.ToString());
        }

        private void handleDowncastingAndInvokeLeaf()
        {
            LeafItem currentLeaf = CurrentMenu as LeafItem;

            currentLeaf.InvokeLeaf();
            CurrentMenu = currentLeaf as MenuItem;
        }
    }
}
