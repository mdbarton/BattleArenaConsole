using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects.Combatants
{
	internal class Bard : Combatant
	{
		public Bard()
		{
			this.CharacterClass = nameof(Bard);
			this.Strength = 10;
			this.Dexterity = 15;

			//We're giving this class lots of Hitpoints because Bards get a bad rap, they're more punk than folk
			this.Hitpoints = 40;
		}
	}
}
