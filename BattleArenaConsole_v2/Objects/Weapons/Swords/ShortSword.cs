using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v2.Objects.Weapons
{
	internal class ShortSword : Sword
	{
		// As Sword inherited from "Weapon", this "ShortSword" inherits from "Sword"
		// and will have the code from both parent classes
		public ShortSword() {
			this.Damage = 4; // a tad more deadly than a default Sword
			this.Name = nameof(ShortSword);
		}
	}
}
