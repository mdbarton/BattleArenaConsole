using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v2.Objects.Weapons.Axes
{
	internal class BattleAxe : Axe
	{
		public BattleAxe() {
			this.Name = nameof(BattleAxe);
			this.Damage = 5;
		}
	}
}
