using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v2
{
	//This class is marked "static" as it is not intended to be used like other class objects
	//static classes cannot be "instantiated" (var instanceOfClass = new WhateverClass()) this would throw an error
	//instead, static classes are usually like utilities that just get called directly
	internal static class PresentationUtility
	{
		//methods must also be marked "static"
		//The second paramter is optional, if not provided, "Black" will be used
		public static void DisplayText(string text, ConsoleColor color = ConsoleColor.White)
		{
			ConsoleColor currentColor = Console.ForegroundColor;
			Console.ForegroundColor = color;
			Console.WriteLine(text);
			Console.ForegroundColor = currentColor;
		}
	}
}
