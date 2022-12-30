using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    // A. Dodanie paragonu:
    //// A1. O podanej kwocie
    //// A2. O danej kategori
    // B. Sprawdzenie wydatków:
    //// B1. Podanie czasu
    //// B2. Podanie kategorii
    //// B3. Całe koszty dla kategorii
    //// B4. Całe koszty dla danego czasu
    // C. Usuniecie paragonu

    internal class Program
    {
        
        static void Main(string[] args)

        {   
            
            menuActionService menuAction = new menuActionService();
            menuAction = Start(menuAction);  // nadpisujemy pusta liste 
            ReceiptService receiptService = new ReceiptService();

            receiptService.AddRececipNow(0, 0, "empty", 0, 0);
            receiptService.AddRececipNow(1, 40, "market Dino", 11, 11);
            receiptService.AddRececipNow(2, 320, "ON", 20 ,11);
            receiptService.AddRececipNow(1, 120, "Mieso", 20 ,11);
    
                 static menuActionService Start(menuActionService menuAction)
                 {
                     menuAction.AddElement(1, " Add cost", "Main");
                     menuAction.AddElement(2, " Show all cost:", "Main");
                     menuAction.AddElement(3, " Delete cost:", "Main");
                     menuAction.AddElement(4, " Change parameters:", "Main");
                     menuAction.AddElement(5, " Sum cost by type:", "Main");

                     menuAction.AddElement(0, " Empty:", "TypOfReceipt");
                     menuAction.AddElement(1, " Food:", "TypOfReceipt");
                     menuAction.AddElement(2, " Car:", "TypOfReceipt");
                     menuAction.AddElement(3, " Home:", "TypOfReceipt");
                     menuAction.AddElement(4, " Devices:", "TypOfReceipt");
                     menuAction.AddElement(5, " Bills:", "TypOfReceipt"); // rachunki

                     return menuAction;
                 }


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" ");
                Console.WriteLine("Hello, I'm your budget menager");
                Console.WriteLine("What can I do for you ?");
                Console.WriteLine("--------------------------------");

                

                List<MenuAction> mainMenu = menuAction.ReadMenu("Main");

                for (int i = 0; i < mainMenu.Count; i++) // sprawdzi wszystkie elemeny listy i wypisze 
                {
                    Console.WriteLine(mainMenu[i].Id + mainMenu[i].Text);
                }
                Console.ForegroundColor = ConsoleColor.White;

                var KeyDecistion = Console.ReadKey();
                menuAction.AddEmptyLine();

                switch (KeyDecistion.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Which TYPE is your receip ? [write number]");
                        var keyInfo = receiptService.AddReceptView(menuAction);
                        receiptService.AddNewRececip(keyInfo.KeyChar);
                        break;
                    case '2':
                        receiptService.ShowAllRececipt();

                        break;
                    case '3':
                        receiptService.ShowAllRececipt();
                        menuAction.AddEmptyLine();
                        receiptService.DeleteRececipt();
                        break;
                    case '4':
                        receiptService.ShowAllRececipt();
                        menuAction.AddEmptyLine();
                        receiptService.ChangeRececipData();
                        break;
                    case '5':
                        Console.WriteLine("Which TYPE cost do you want to sum ?  [write number]");
                        var keyInfoSumOfCost = receiptService.AddReceptView(menuAction);
                        int SumOfCostByType = receiptService.SumOfCost(keyInfoSumOfCost.KeyChar);
                        break;
                    default:
                        break;
                }


                







            }

        }
    }
}


