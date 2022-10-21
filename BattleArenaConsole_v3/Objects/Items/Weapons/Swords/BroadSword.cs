using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects.Items.Weapons//.Swords
{
	internal class BroadSword : Sword
	{
		public BroadSword() {
			this.DamageRoll = "1d8";
			this.Cost = 15;
			this.Name = nameof(BroadSword);
		}
	}
}
