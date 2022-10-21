using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3
{
	//as a static class, this cannot be instantiated as a new instance - you cannot x = new DisplayPresentation
	//you call the code directly, as such it is more of a "utility" class than one in the object hierarchy
	internal static class DisplayPresentation
	{
		//the ConsoleColor paramter is optional, if none is provided it uses "White"
		public static void DisplayText(string s, ConsoleColor c = ConsoleColor.White)
		{
			//this.Write(s);  < this won't work because we're creating a static class, there are no instantiated instances
			ConsoleColor curr = Console.ForegroundColor;
			Console.ForegroundColor = c;
			Write(s);
			Console.ForegroundColor = curr;
		}
		public static void Write(string txt)
		{
			Console.WriteLine(txt);
		}
	}
}
