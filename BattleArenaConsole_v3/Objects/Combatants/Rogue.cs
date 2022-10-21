using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects.Combatants
{
	internal class Rogue : Combatant
	{
		public Rogue() {
			this.CharacterClass = nameof(Rogue);
			this.Strength = 15;
			this.Dexterity = 18;
			this.Hitpoints = 20;
		}
	}
}
