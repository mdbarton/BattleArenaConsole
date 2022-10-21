using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Display = BattleArenaConsole_v3.DisplayPresentation;

namespace BattleArenaConsole_v3.Objects.Locations
{
	internal abstract class ILocation
	{
		public string Name { get; }

		public void Run(Combatants.Combatant player) {	}

		//This is another "less than ideal" way to implement, we'll improve it soon
		//by making this an abstract class, we can add the getInput method here and all derived classes will already have it
		// ideally though, this would be an interface

		public string getInput()
		{
			var typedText = Console.ReadLine();
			return typedText;
		}
	}
}
