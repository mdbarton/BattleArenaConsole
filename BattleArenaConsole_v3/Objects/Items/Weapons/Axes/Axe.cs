using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects.Items.Weapons
{
	internal class Axe : Weapon
	{
		public Axe()
		{
			this.Name = nameof(Axe);
			this.DamageRoll="1d8";
		}

	}
}
