using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects.Items
{
	internal class Hands : Weapon
	{
		public Hands()
		{
			this.DamageRoll = "1d2";
			this.Name = nameof(Hands);
		}
	}
}
