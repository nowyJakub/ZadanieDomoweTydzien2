using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class RececipServiceHelpers
    {
        public string GiveTypeOfId(int id)
        {
            string ReturnType = null;

            switch (id)
            {
                case 1:
                    ReturnType = "Food";
                    break;
                case 2:
                    ReturnType = "Car";
                    break;
                case 3:
                    ReturnType = "Home";
                    break;
                case 4:
                    ReturnType = "Devices";
                    break;
                case 5:
                    ReturnType = "Bills";
                    break;
                default:
                    ReturnType = "Wrong number";
                    break;
            }

            

            return ReturnType;
        }


        public int tryParseStringToIntFromReadConsole (  )
        {
            int valueIntAfterTryParse=0;
            string stringToTryParse = Console.ReadLine ();
            Int32.TryParse(stringToTryParse, out valueIntAfterTryParse);

            return valueIntAfterTryParse;
        }

        public int LimitForCondition(int lowLimit, int highLimit, int valueToCheck)
        {
            bool exitFromLoop=false;
            int valueAfterTryParseStringToInt=0;
            string nextTryValueToCheck = null;
            while (exitFromLoop==false)
            {


                if (lowLimit > valueToCheck)
                {
                    Console.WriteLine("Value is too low, please repeat");
                    
                    valueToCheck = tryParseStringToIntFromReadConsole();
                }
                else if (highLimit < valueToCheck)
                {
                    Console.WriteLine("Value is too high, please repeat");
                    valueToCheck = tryParseStringToIntFromReadConsole();
                }
                else
                {
                    exitFromLoop = true;
                }
            }
            return valueToCheck;
        }
    }
}
