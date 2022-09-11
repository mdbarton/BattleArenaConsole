using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v2.Objects.Weapons
{
	internal class Axe : Weapon
	{
		public Axe() {
			this.Name = nameof(Axe);
			this.Damage = 3;
		}
	}
}
