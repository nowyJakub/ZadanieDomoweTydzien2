using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class ReceiptService
    {
       public List<Receipt> ReceiptList { get; set; }
       RececipServiceHelpers rececipServisHelpers = new RececipServiceHelpers();
       

        public ReceiptService()
        {
            ReceiptList = new List<Receipt>();
        }
        public void AddRececipNow(int type, int cost, string description, int day, int month)
        {
            Receipt receipt = new Receipt();
            receipt.Id = type;
            receipt.Cost = cost;
            receipt.Details = description;
            receipt.Day = day;
            receipt.Month = month;
            ReceiptList.Add(receipt);
        }
        public ConsoleKeyInfo AddReceptView (menuActionService menuAction)
        {

            var AddRececptMenu = menuAction.ReadMenu("TypOfReceipt");
            for (int i = 1; i < AddRececptMenu.Count; i++) // sprawdzi wszystkie elemeny listy i wypisze 
            {
                Console.WriteLine(AddRececptMenu[i].Id + AddRececptMenu[i].Text);
            }

            var KeyDecistion = Console.ReadKey();
            menuAction.AddEmptyLine();
            return KeyDecistion;
        }

        public void AddNewRececip(char rececipId)
        {
            int ReceipId = 0;
            Int32.TryParse(rececipId.ToString(), out ReceipId);
            Receipt receipt = new Receipt();
            Console.WriteLine("Please enter description of receip:");
            string ReceipDescriptin = Console.ReadLine();

            Console.WriteLine("Please enter COST of receip [without rest]:");
            int ReceipCost = rececipServisHelpers.tryParseStringToIntFromReadConsole();
            

            Console.WriteLine("Please enter NUMBER OF DAY in month when you got receip[1-31]:");
            int dayRececip = rececipServisHelpers.tryParseStringToIntFromReadConsole();
            dayRececip = rececipServisHelpers.LimitForCondition(1, 31, dayRececip);


            Console.WriteLine("Please enter MONTH when you got receip [1-12]:");
            int monthRececip = rececipServisHelpers.tryParseStringToIntFromReadConsole();
            monthRececip = rececipServisHelpers.LimitForCondition(1, 12, monthRececip);

            receipt.Id = ReceipId;
            receipt.Details = ReceipDescriptin;
            receipt.Cost = ReceipCost;
            receipt.Day = dayRececip;
            receipt.Month = monthRececip;

            ReceiptList.Add(receipt);
            
        }

        public void ShowAllRececipt ()
        {
            
            string TypeOfRececipToShow;

            for (int i = 1; i < ReceiptList.Count; i++) // sprawdzi wszystkie elemeny listy i wypisze 
            {
                TypeOfRececipToShow= rececipServisHelpers.GiveTypeOfId(ReceiptList[i].Id);

                Console.WriteLine(i+". " + "Type: " + TypeOfRececipToShow + " Cost: " + ReceiptList[i].Cost+ " zl;" + " Details: " + ReceiptList[i].Details 
                                    + " Date: " + ReceiptList[i].Day + "." + ReceiptList[i].Month);
            }

            
        }

        public void ShowOneRececipt(int whichRececipToShow)
        {
            string TypeOfRececipToShow = rececipServisHelpers.GiveTypeOfId(ReceiptList[whichRececipToShow].Id);

            Console.WriteLine(whichRececipToShow + ". " + "Type: " + TypeOfRececipToShow + " Cost: " + ReceiptList[whichRececipToShow].Cost + " zl;" + " Details: " + ReceiptList[whichRececipToShow].Details
                                    + " Date: " + ReceiptList[whichRececipToShow].Day + "." + ReceiptList[whichRececipToShow].Month);
            
        }


        public void DeleteRececipt()
        {
            Console.WriteLine("Which rececip do you want to delete from the list ?");
            Console.WriteLine("Write the details: ");
            string typeRececipToDelete = Console.ReadLine();

            Console.WriteLine("Write the cost of this rececip: ");
            string costRececipToDeleteString = Console.ReadLine();
            int costRececipToDeleteInt = 0;
            Int32.TryParse(costRececipToDeleteString, out costRececipToDeleteInt);

            string ConfirmDecisionToDeleteRececip;

           // 

            for (int i = 0; i < ReceiptList.Count; i++) // sprawdzi wszystkie elemeny listy i wypisze 
            {


                if ((ReceiptList[i].Details == typeRececipToDelete) && (ReceiptList[i].Cost == costRececipToDeleteInt))
                {
                    Console.WriteLine("Are you sure to delete this rececip (yes/no) ?");
                    ConfirmDecisionToDeleteRececip = Console.ReadLine();
                    if (ConfirmDecisionToDeleteRececip == "yes")
                    {
                        ReceiptList.RemoveAt(i);
                        Console.WriteLine("Your Rececip was deleted from the list");
                    }
                }
                else if (i==ReceiptList.Count-1)
                {
                   Console.WriteLine("This rececip didnt exist in your list. You made some mistakes");
                }
            }

        }
        
        public void ChangeRececipData()
        {
            string chooseCategory;
            bool exitLoop=false;
            string changeData;
            string changeData2;
            int changeDataInt;
            int changeDataInt2;

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Write number of Rececipt which you want to edit: ");
            string chooseRececipt = Console.ReadLine();
            int chooseRececiptInt= 1000;
            Int32.TryParse(chooseRececipt, out chooseRececiptInt);
            ShowOneRececipt(chooseRececiptInt);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Which category do you want to edit ? ");

           

            while (exitLoop==false)
            {
                
                chooseCategory = Console.ReadLine();

                if ((chooseCategory == "Cost")|| (chooseCategory == "cost"))
                {
                    Console.WriteLine("Write correct data to - Cost");
                    changeData = Console.ReadLine();
                    Int32.TryParse(changeData, out changeDataInt);
                    ReceiptList[chooseRececiptInt].Cost = changeDataInt;
                    Console.WriteLine("You change data succesfully");
                    exitLoop =true;
                }
                else if ((chooseCategory == "Type") || (chooseCategory == "type"))
                {
                    while (exitLoop == false)
                    {
                        Console.WriteLine("Write correct data to - Type");
                        changeData = Console.ReadLine();
                        if (changeData == "Food" || (changeData == "food"))
                        {
                            ReceiptList[chooseRececiptInt].Id = 1;
                            Console.WriteLine("You change data succesfully");
                            exitLoop = true;
                        }
                        else if (changeData == "Chemicals" || (changeData == "chemicals"))
                        {
                            ReceiptList[chooseRececiptInt].Id = 2;
                            Console.WriteLine("You change data succesfully");
                            exitLoop = true;
                        }
                        else if (changeData == "Home" || (changeData == "home"))
                        {
                            ReceiptList[chooseRececiptInt].Id = 3;
                            Console.WriteLine("You change data succesfully");
                            exitLoop = true;
                        }
                        else if (changeData == "Devices" || (changeData == "devices"))
                        {
                            ReceiptList[chooseRececiptInt].Id = 4;
                            Console.WriteLine("You change data succesfully");
                            exitLoop = true;
                        }
                        else if ((changeData == "Bills") || (changeData == "bills"))
                        {
                            ReceiptList[chooseRececiptInt].Id = 5;
                            Console.WriteLine("You change data succesfully");
                            exitLoop = true;
                        }
                        else
                            Console.WriteLine("This type didint exist");

                    }
                }
                else if ((chooseCategory == "Details") || (chooseCategory == "details"))
                {
                    Console.WriteLine("Write correct data to - Details");
                    changeData = Console.ReadLine();
                    ReceiptList[chooseRececiptInt].Details = changeData;
                    Console.WriteLine("You change data succesfully");
                    exitLoop = true;
                }
                else if ((chooseCategory == "Date") || (chooseCategory == "date"))
                {
                    Console.WriteLine("Write correct data to - Day");
                    changeData = Console.ReadLine();
                    Console.WriteLine("Write correct data to - Month");
                    changeData2 = Console.ReadLine();

                    Int32.TryParse(changeData, out changeDataInt);
                    Int32.TryParse(changeData2, out changeDataInt2);

                    ReceiptList[chooseRececiptInt].Day = changeDataInt;
                    ReceiptList[chooseRececiptInt].Month = changeDataInt2;
                    Console.WriteLine("You change data succesfully");
                    exitLoop = true;
                }
                else if((chooseCategory == "x") || (chooseCategory == "X"))
                {
                    exitLoop = true;
                }
                else
                {
                    Console.WriteLine("You write wrong word. Please repeat.");
                    Console.WriteLine(" If you want to exit this opction press x.");
                }
                
            }
            
        }
        
        public int SumOfCost (char keyDecision)
        {
            int TypeOfRececip = 100;
            int SumOfCostInType = 0;
            Int32.TryParse(keyDecision.ToString(), out TypeOfRececip);

            for (int i = 1; i < ReceiptList.Count; i++)
            {
                if (TypeOfRececip == ReceiptList[i].Id)
                {
                    SumOfCostInType += ReceiptList[i].Cost;
                }
            }
            Console.WriteLine("Total cost by type is : " + SumOfCostInType);
            return SumOfCostInType;
               
        }

        


    }
}
