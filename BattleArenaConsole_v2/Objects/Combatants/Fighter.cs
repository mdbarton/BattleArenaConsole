using BattleArenaConsole_v2.Objects.Weapons;
using BattleArenaConsole_v2.Objects.Weapons.Axes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v2.Objects.Combatants
{
	internal class Fighter : Combatant
	{

		public Fighter() {
			this.CharacterClass = nameof(Fighter);
			//this.CharacterClass = "Figther"; //look close, this is the reason to use nameod()
			//these are the default for this CharacterClass:
			this.Strength = 12;
			this.Dexterity = 10;
			this.Hitpoints = 20;

			this.Inventory.Add(new ShortSword());
			this.Inventory.Add(new BattleAxe());
		}

		public Int16 DefensiveCounter()
		{
			Int16 defensiveCounter = 2;
			return defensiveCounter;
		}

	}
}
