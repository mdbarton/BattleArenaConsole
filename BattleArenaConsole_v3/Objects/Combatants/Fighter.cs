using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleArenaConsole_v3.Objects.Items.Weapons;

namespace BattleArenaConsole_v3.Objects.Combatants
{
	internal class Fighter : Combatant
	{
		public Fighter()
		{
			this.CharacterClass = nameof(Fighter);
			//this.CharacterClass = "Figther"; // <look close, this is the reason to use nameof()
			this.Strength = 12;
			this.Dexterity = 10;
			this.Hitpoints = 20;
			this.XPAwarded = 100;

			ShortSword s = new ShortSword();
			this.Inventory.Add(s);
			this.Arm(s);
		}

		public new Int16 DefensiveCounter() // "new" is akin to "overriding" the base method
		{
			Int16 defensiveCounter = 2;
			return defensiveCounter;
		}
	}
}
