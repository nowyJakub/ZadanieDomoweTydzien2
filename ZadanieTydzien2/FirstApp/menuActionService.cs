using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    
     class menuActionService
    {
        List<MenuAction> menuActions = new List<MenuAction>();

        public void AddEmptyLine()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void AddElement (int id, string text, string type)
        {
            MenuAction menu = new MenuAction() { Id = id, Text = text, Type = type };
            menuActions.Add(menu);
        }

        public List<MenuAction> ReadMenu ( string type)
        {
            List<MenuAction> WhatToShow = new List<MenuAction>(); 
            foreach(MenuAction menu in menuActions)
            {
                if (menu.Type == type)
                {
                    WhatToShow.Add(menu);
                }
            }

            return WhatToShow;
        }

    }
}














