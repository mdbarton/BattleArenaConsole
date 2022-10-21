using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects.Items.Weapons
{
	internal class ShortSword : Sword
	{
		// As Sword inherited from "Weapon", this "ShortSword" inherits from "Sword"
		// and will have the code from both parent classes
		public ShortSword()
		{
			this.DamageRoll = "1d6";
			this.Cost = 10;
			this.Name = nameof(ShortSword);
		}

	}
}
